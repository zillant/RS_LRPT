using System;
using System.Collections.Generic;
using SDRSharp.RTLSDR;
using SDRSharp.Radio;
using System.Threading;
using MaterialSkin.Controls;

namespace ReceivingStation
{
    delegate void TimeHandler();
    unsafe class Demodulating
    {
        static event TimeHandler onTime;

        const int Gain = 14; // Усиление свистка 15дБ
        const int TotalSamples = 10000;
        const int BL = 401;// Matlabs FIR Order
        const double SampleRate_FIR = 1024000;
        const int _symbolRate = 72000;
        const uint _Frequency = 137883170;
        const uint _SampleRate = 1024000;
        uint Frequency;

        static Thread _workerThread;
        static Thread _outputThread;
        static Thread _DisplayThread;

        static bool _processIsStarted;
        static bool _outputIsStarted;
        static bool _View;
        static bool _syncronization;
        static bool _recording;

        static int Samples = 0;
        static int _lostBuffers;
        static RtlSdrIO IO = new RtlSdrIO();

        static List<float> _DataI = new List<float>();
        static List<float> _DataQ = new List<float>();
        static List<float> DataI_FIR = new List<float>();
        static List<float> DataQ_FIR = new List<float>();


        static IQFirFilter _LowPassFirFilter;
        static FirFilter _syncFirFilter;
        static IirFilter* _syncFilter;
        static float[] _coeffs;

        static UnsafeBuffer _syncFilterBuffer;
        static UnsafeBuffer _buffer;
        static UnsafeBuffer _buffer1;
        static UnsafeBuffer _resamplerInBuffer;
        static Complex* _resampleInBufferPtr;
        static Complex* _bufferPtr;
        static Complex* _bufferPtr1;
        static Complex* _bufferPtrLP;
        static ComplexFifoStream _FifoBuffer;
        static ComplexFifoStream _inputfifoBuffer;
        static UnsafeBuffer _syncBuffer;
        static float* _syncBufferPtr;
        static Complex _prevBuffer;
        static UnsafeBuffer _recordBuffer;
        static unsafe Complex* _recordBufferPtr;
        static UnsafeBuffer _PacketsBuffer;
        static unsafe Complex* _PacketsBufferPtr;
        static UnsafeBuffer ElementBuffer;
        static unsafe Complex* ElementBufferPtr;

        static byte[] _bits;
        static Demodulator.FileWriter _rawWriter;


        static byte[] _outputBuffer;
        static float _writeLength;

        static bool _needPLLConfigure;

        static float _carrierPhase;
        static float _carrierFrequencyRadian;
        static float _minCarrierFrequencyRadian;
        static float _maxCarrierFrequencyRadian;
        static float _carrierPhaseStep;
        static float _norm;
        static float _carrierFrequencyStep;
        static bool _carrierPhaseLocked;
        static bool _LockView;
        static float _carrierPhaseErrorAvg;
        static float SearchPhaseBandwidth;
        static float _oneMinusPhaseErrCoeff;
        static float _phaseErrorCoeff;
        static int _watchDogCounter;
        static int _carrierShift;


        static UnsafeBuffer _bufferAfterLowPass;//after matched
        static Complex* _bufferPtrAfterLowPass;


        static SamplesAvailableEventArgs _inputbuffer = new SamplesAvailableEventArgs();

        static float _agcGain;
        static int _inputFifoBufferLength;
        static float _lastSync;
        static float _averageGain;
        static float _agcCoeff;
        static float _oneMinusAgcCoeff;

        static bool _prevIsUp;


        static int _filterLength;
        const int MaxBufferLength = 1024 * 10;

        const float Pi = (float)Math.PI;
        const float TwoPi = (float)(2.0 * Math.PI);
        const float PiDivTwo = (float)(Math.PI * 0.5);
        const float PiDivFor = (float)(Math.PI * 0.25);
        const float LockThreshold = 0.196f;
        const float LockThresholdOut = 0.2f;

        private static int _droppedBuffers;

        static Complex _lastData;

        private const float ByteToMb = 1f / 1024f / 1024f;
        private const int BufferSizeToRecord = 16384; // 

        static string filename = (string)"";

        static StreamCorrection StreamCorrection;
        static Decode _decode;
        static BeforeViterbiSync BVS;

        static FormReceive _formrcv;
        static byte _FrequencyMode;
        static byte _Interliving;
        static byte[] _correctedarray;
        static byte[] arrayToDecode;
        static byte[] PacketsArray;

        static bool PSPFinded;
        static int mode = 0;

        static bool FirstRead;
        private int bytedata;



        public Demodulating(FormReceive rcvform, byte freqmode, byte interliving, Decode decode)
        {
            _FrequencyMode = freqmode;

            _formrcv = rcvform;
            _decode = decode;

            var logfilename = "onlinelogs";
            StreamCorrection = new StreamCorrection(0x2);
            BVS = new BeforeViterbiSync();
        }

        public void Dongle_Configuration(uint SampleRate)// Настройка свистка    
        {
            if (_FrequencyMode == 0x1) Frequency = 137080000;
            if (_FrequencyMode == 0x2) Frequency = 137883170;

            IO.Open();
            IO.Device.Start();
            IO.Device.SamplesAvailable += Samples_Available;
            IO.Device.Frequency = Frequency;
            IO.Device.UseRtlAGC = true;
            IO.Device.UseTunerAGC = true;
            // IO.Device.Gain = IO.Device.SupportedGains[4];
            IO.Device.Samplerate = SampleRate;

        }
        public static unsafe void Samples_Available(object sender, SamplesAvailableEventArgs inputbuffer)
        {
            if (_inputfifoBuffer == null)
            {
                _inputfifoBuffer = new ComplexFifoStream(BlockMode.None);

            }

            if (_inputfifoBuffer.Length < _SampleRate)
            {
                _inputfifoBuffer.Write(inputbuffer.Buffer, inputbuffer.Length);
            }
            else
            {
                _droppedBuffers++;
            }

            //Тут мы только копируем данные в наш входной буфер и все.
        }

        static void SaveData(Complex* BuftoSave, int buflength, bool BufName)
        {
            //var buflength = _inputbuffer.Length;
            //var buflength = TotalSamples;
            var dateString = DateTime.Now.ToString("yyyy_MM_dd");
            var timeString = DateTime.Now.ToString("HH-mm-ss");
            var BufNameStr = "";
            if (BufName)
            {
                BufNameStr = "Before Matched";
            }
            else
            {
                BufNameStr = "After Matched";
            }
            var filename = (string)"";

            filename = string.Format("{0}_IQ_Samples_{1}", dateString, timeString) + BufNameStr + ".txt";

            string[] Result = new string[buflength];
            for (int i = 0; i < buflength; i++)
            {
                Result[i] = String.Format("{0:0.000000}\t{1:0.000000}", BuftoSave[i].Real, BuftoSave[i].Imag);
            }
            System.IO.File.WriteAllLines(filename, Result);
        }

        public void StartDecoding()
        {
            _FifoBuffer = new ComplexFifoStream(BlockMode.None);
            _LockView = false;
            _needPLLConfigure = true;
            _droppedBuffers = 0;
            _processIsStarted = true;
            _workerThread = new Thread(BufferProcess);
            _workerThread.Name = "PSK demodulator";
            _workerThread.Priority = ThreadPriority.Highest;
            _workerThread.Start();
            if (IO.Device != null) _formrcv.Invoke(new Action(() => { _formrcv.DongOnlbl.Text = "Приемник настроен"; }));
            _formrcv.Invoke(new Action(() => { _formrcv.DemOnlbl.Text = "Демодулятор запущен"; }));

            var dateString = DateTime.Now.ToString("yyyy_MM_dd");
            var timeString = DateTime.Now.ToString("HH-mm-ss");

            filename = string.Format("{0}_LRPT_{1}", dateString, timeString) + ".s";
            _rawWriter = new Demodulator.FileWriter(filename);
            _rawWriter.Open();

            _outputIsStarted = true;

        }

        public void StopDecoding()
        {
            _processIsStarted = false;
            //IO.Device.Stop();
           // IO.Close();

            if (_workerThread != null)
            {
                //_workerThread.Join();
                _workerThread = null;
            }

            _inputfifoBuffer.Close();
            _inputfifoBuffer.Dispose();

            _outputIsStarted = false;

            if (_outputThread != null)
            {
                // _outputThread.Join();
                _outputThread = null;
            }
            StreamCorrection.StopCorrect();
            _recordBuffer.Dispose();
            _recordBuffer = null;
            _recordBufferPtr = null;
            _outputBuffer = null;
            _recording = false;
            StreamCorrection = null;
            
            if (IO.Device == null) _formrcv.Invoke(new Action(() => { _formrcv.DongOnlbl.Text = "Приемник выключен"; }));
            _formrcv.Invoke(new Action(() => { _formrcv.DemOnlbl.Text = "Демодулятор выключен"; }));
            _formrcv.Invoke(new Action(() => { _formrcv.LockOnlbl.Text = ""; }));
            _buffer = null;
            _FifoBuffer.Dispose();
            _FifoBuffer = null;

            _decode.FinishDecode();

        }

        public void PLLReset()
        {
            _carrierPhase = 0;
            _carrierFrequencyRadian = 0;
            _carrierPhaseErrorAvg = TwoPi;
        }
        static unsafe void BufferProcess()
        {
            // var readLength = 1024;
            var bufferLength = 4096;
            var samplerate = (double)0;
            var length = 0;
            var samplerateIn = _SampleRate;
            var interpolation = 1;
            var modulus = 0f;
            var phaseError = 0.0f;
            var syncVal = 0.0f;
            var indexout = 0;
            var resultDisplay = (Complex)0;
            var data = new Complex();

            while (_processIsStarted)
            {
                //Если входной буфер пуст отдыхаем
                if (_inputfifoBuffer == null || _inputfifoBuffer.Length < bufferLength || _SampleRate == 0)
                {
                    Thread.Sleep(10);
                    continue;
                }

                //Проверяем наличие рабочего буфера и создаем при необходимости
                if (_buffer == null || _SampleRate != samplerateIn)
                {
                    samplerateIn = _SampleRate;

                    interpolation = 1;

                    while (samplerateIn * interpolation < _symbolRate * 4)
                    {
                        interpolation = 2;
                    }

                    samplerate = samplerateIn * interpolation;
                    length = bufferLength * interpolation;

                    _buffer = UnsafeBuffer.Create(bufferLength, sizeof(Complex));
                    _bufferPtr = (Complex*)_buffer;

                    _resamplerInBuffer = UnsafeBuffer.Create(bufferLength, sizeof(Complex));
                    _resampleInBufferPtr = (Complex*)_resamplerInBuffer;

                    _syncFilterBuffer = UnsafeBuffer.Create(sizeof(IirFilter));
                    _syncFilter = (IirFilter*)_syncFilterBuffer;

                    _syncBuffer = UnsafeBuffer.Create(length, sizeof(float));
                    _syncBufferPtr = (float*)_syncBuffer;

                    _filterLength = Math.Max((int)(_SampleRate / _symbolRate) | 1, 5);

                    var coeff = FilterBuilder.MakeSinc(_SampleRate, _symbolRate, _filterLength);
                    _syncFirFilter = new FirFilter(coeff);

                    coeff = FilterBuilder.MakeSinc(_SampleRate, _symbolRate, _filterLength);
                    _LowPassFirFilter = new IQFirFilter(coeff, false, 1);//// TRUE OR FALSE?????

                    _syncFilter->Init(IirFilterType.BandPass, _symbolRate, _SampleRate, 2000);

                    _phaseErrorCoeff = 10.0f / (float)samplerate;
                    _oneMinusPhaseErrCoeff = 1.0f - _phaseErrorCoeff;

                    _carrierPhaseErrorAvg = TwoPi;

                    _needPLLConfigure = true;
                }

                _bufferPtrLP = _bufferPtr;

                #region Interpolator and Matched filter

                if (interpolation > 1)
                {
                    _inputfifoBuffer.Read(_resampleInBufferPtr, bufferLength);

                    //interpolator x2
                    var index = 0;

                    for (var i = 0; i < bufferLength; i++)
                    {
                        _bufferPtr[index++] = _resampleInBufferPtr[i];
                        _bufferPtr[index++] = 0;
                    }
                }
                else
                {
                    _inputfifoBuffer.Read(_bufferPtr, length);
                }

                _LowPassFirFilter.Process(_bufferPtr, length);

                #endregion

                #region AGC
                _agcCoeff = _symbolRate / (float)samplerate * 0.01f;
                _oneMinusAgcCoeff = 1f - _agcCoeff;

                for (int i = 0; i < length; i++)
                {
                    modulus = _bufferPtr[i].Modulus();
                    _averageGain = _averageGain * _oneMinusAgcCoeff + modulus * _agcCoeff;
                    _agcGain = (0.7f / _averageGain);
                    _bufferPtr[i] *= _agcGain;

                    //copy sync
                    _syncBufferPtr[i] = (_bufferPtr[i] * _prevBuffer.Conjugate()).ArgumentFast();
                    _prevBuffer = _bufferPtr[i];
                }

                #endregion

                #region Synchronization

                _syncFirFilter.Process(_syncBufferPtr, length);

                for (var i = 0; i < length; i++)
                {
                    syncVal = _syncFilter->Process(_syncBufferPtr[i] < 0 ? _syncBufferPtr[i] : 0.0f);

                    if (_prevIsUp && syncVal < _lastSync)
                    {
                        _syncBufferPtr[i] = 1;
                    }
                    else if (!_prevIsUp && syncVal > _lastSync)
                    {
                        _syncBufferPtr[i] = -1;
                    }
                    else
                    {
                        _syncBufferPtr[i] = 0;
                    }

                    _prevIsUp = syncVal > _lastSync;

                    _lastSync = syncVal;
                }
                #endregion

                #region PLL

                if (_needPLLConfigure)
                {
                    _needPLLConfigure = false;
                    _norm = (float)(TwoPi / samplerate);
                    SearchPhaseBandwidth = 500.0f;// PLL Bandwith
                    _minCarrierFrequencyRadian = -10000 * _norm;
                    _maxCarrierFrequencyRadian = 10000 * _norm;

                    _carrierPhaseStep = SearchPhaseBandwidth * _norm;
                    _carrierFrequencyStep = (_carrierPhaseStep * _carrierPhaseStep);


                }

                for (var i = 0; i < length; i++)
                {
                    _bufferPtr[i] *= Complex.FromAngleFast(-_carrierPhase);

                    phaseError = (_bufferPtr[i].ArgumentFast()) + Pi;
                    phaseError = (phaseError % PiDivTwo) - PiDivFor;

                    _carrierPhaseErrorAvg = _carrierPhaseErrorAvg * _oneMinusPhaseErrCoeff + phaseError * phaseError * _phaseErrorCoeff;

                    _carrierFrequencyRadian += _carrierFrequencyStep * phaseError;

                    if (_carrierFrequencyRadian > _maxCarrierFrequencyRadian)
                    {
                        _carrierFrequencyRadian = _maxCarrierFrequencyRadian;
                    }
                    else if (_carrierFrequencyRadian < _minCarrierFrequencyRadian)
                    {
                        _carrierFrequencyRadian = _minCarrierFrequencyRadian;
                    }

                    _carrierPhase += _carrierFrequencyRadian + _carrierPhaseStep * phaseError;
                    _carrierPhase %= TwoPi;


                }

                _carrierPhaseLocked = (!_carrierPhaseLocked && (_carrierPhaseErrorAvg < LockThreshold)) || (_carrierPhaseLocked && (_carrierPhaseErrorAvg < LockThresholdOut));
                _carrierShift = (int)(_carrierFrequencyRadian / _norm);

                if (_carrierPhaseLocked)
                {
                    _formrcv.Invoke(new Action(() => { _formrcv.LockOnlbl.Text = "Захват"; }));
                    // Console.WriteLine("Locked!");
                    _LockView = true;
                    _View = true;

                }

                if (!_carrierPhaseLocked && _LockView) //если созвездие было захвачено и рассыпалось
                {
                    _formrcv.Invoke(new Action(() => { _formrcv.LockOnlbl.Text = "Захват потерян"; }));
                    _LockView = false;
                }

                if (_carrierPhaseLocked)
                {
                    _watchDogCounter = (int)(samplerate / length * 5);
                }
                if (_watchDogCounter > 0) _watchDogCounter--;//WTF?????????????????????????????????

                if (_carrierPhaseLocked)
                {
                    _carrierPhaseStep = _carrierPhaseErrorAvg * 0.0025f;
                }
                else
                {
                    _carrierPhaseStep = SearchPhaseBandwidth * _norm;
                }
                _carrierFrequencyStep = (_carrierPhaseStep * _carrierPhaseStep);

                #endregion

                #region Resampler

                indexout = 0;

                for (int i = 0; i < length; i++)
                {
                    //resampler
                    data = _bufferPtr[i];

                    if (_syncBufferPtr[i] == -1)
                    {
                        _bufferPtr[indexout] = _lastData;
                        resultDisplay = _lastData;
                        indexout++;
                    }
                    _lastData = data;
                }

                #endregion

                if (_outputIsStarted && _watchDogCounter > 0)
                {
                    if (_FifoBuffer.Length < samplerate)
                    {
                        _FifoBuffer.Write(_bufferPtr, indexout);
                    }
                    else
                    {
                        _lostBuffers++;
                    }
                }

            }
        }
        public void RecordStart()
        {
            FirstRead = false;
            _recording = true;
            _recordBuffer = UnsafeBuffer.Create(BufferSizeToRecord, sizeof(Complex));
            _recordBufferPtr = (Complex*)_recordBuffer;

            _PacketsBuffer = UnsafeBuffer.Create(16384, sizeof(Complex));
            _PacketsBufferPtr = (Complex*)_PacketsBuffer;

            ElementBuffer = UnsafeBuffer.Create(1, sizeof(Complex));
            ElementBufferPtr = (Complex*)ElementBuffer;

            _outputBuffer = new byte[BufferSizeToRecord * 2];
            _correctedarray = new byte[32768 / 8];
            arrayToDecode = new byte[32768];

            var Element = new byte[2];
            var count = 0;

            PSPFinded = false;
            PacketsArray = new byte[32768];


            _outputThread = new Thread(RecordingThread);
            _outputThread.Priority = ThreadPriority.Lowest;
            _outputThread.Name = "QPSKOutputThread";
            _outputThread.Start();
        }


        static void RecordingThread()
        {
            _recording = true;
            _recordBuffer = UnsafeBuffer.Create(BufferSizeToRecord, sizeof(Complex));
            _recordBufferPtr = (Complex*)_recordBuffer;

            _outputBuffer = new byte[BufferSizeToRecord * 2];
            _correctedarray = new byte[BufferSizeToRecord / 4];
            var PartialPacketLength = 32768;
            var Element = new byte[2];
            var count = 0;
            while (_outputIsStarted)
            {
                if (_FifoBuffer == null || _FifoBuffer.Length < BufferSizeToRecord)
                {
                    Thread.Sleep(10);
                    continue;
                }
                if (!FirstRead)
                {
                    _FifoBuffer.Read(_recordBufferPtr, BufferSizeToRecord);
                    ConvertComplexToByte(_outputBuffer, _recordBufferPtr, BufferSizeToRecord);
                    PSPFinded = BVS.PSPSearch(_outputBuffer, mode);
                    FirstRead = true;
                }

                if (FirstRead && !PSPFinded)
                {
                    _FifoBuffer.Read(ElementBufferPtr, 1); //тут считывается одно комплексное значение
                    ConvertComplexToByte(Element, ElementBufferPtr, Element.Length / 2);
                    _outputBuffer = Delete(_outputBuffer, 0);
                    _outputBuffer = Delete(_outputBuffer, 0);
                    _outputBuffer = AddElement(_outputBuffer, Element[0]);
                    _outputBuffer = AddElement(_outputBuffer, Element[1]); // тут перезаписываем массив, пока не наткнемся на синхромаркер
                    PSPFinded = BVS.PSPSearch(_outputBuffer, mode);
                }

                if (FirstRead && PSPFinded)
                {
                    StreamCorrection.fromAmplitudesToBits(_outputBuffer, _correctedarray);
                    _decode.StartDecode(_correctedarray);
                    Console.WriteLine("Finded");
                    _formrcv.Invoke(new Action(() => { _formrcv.SignDetectlbl.Text = "Синхромаркер найден"; }));
                    _FifoBuffer.Read(_recordBufferPtr, BufferSizeToRecord);
                    ConvertComplexToByte(_outputBuffer, _recordBufferPtr, BufferSizeToRecord);
                    //_rawWriter.Write(_outputBuffer, _outputBuffer.Length);
                    PSPFinded = BVS.PSPSearch(_outputBuffer, mode);
                }

                if (FirstRead && !PSPFinded)
                {
                    _FifoBuffer.Read(ElementBufferPtr, 1); //тут считывается одно комплексное значение
                    ConvertComplexToByte(Element, ElementBufferPtr, Element.Length / 2);
                    _outputBuffer = Delete(_outputBuffer, 0);
                    _outputBuffer = Delete(_outputBuffer, 0);
                    _outputBuffer = AddElement(_outputBuffer, Element[0]);
                    _outputBuffer = AddElement(_outputBuffer, Element[1]); // тут перезаписываем массив, пока не наткнемся на синхромаркер
                    PSPFinded = BVS.PSPSearch(_outputBuffer, mode);
                }


            }


        }




        static void ConvertComplexToByte(byte[] dest, Complex* source, int sourceLength)
        {
            var index = 0;
            for (var i = 0; i < sourceLength; i++)
            {
                dest[index] = FloatToByte(source[i].Real);
                index++;
                dest[index] = FloatToByte(source[i].Imag);
                index++;
            }
        }


        static byte FloatToByte(float sample)
        {
            sample *= 127;
            if (sample > 127) sample = 127;
            else if (sample < -127) sample = -127;
            return (byte)sample;
        }

        private static byte SymbToByte(float sample)
        {
            return (byte)sample;
        }

        private static byte[] Delete(byte[] array, int indexToDelete)// удаляет элементы из массива
        {
            if (array.Length == 0) return array;
            if (array.Length <= indexToDelete) return array;

            var output = new byte[array.Length - 1];
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (i == indexToDelete) continue;
                output[counter] = array[i];
                counter++;
            }
            return output;
        }

        private static byte[] AddElement(byte[] array, byte element)//добавляет элемент в конец массива
        {
            var output = new byte[array.Length + 1];
            Array.Copy(array, output, array.Length);
            output[output.Length - 1] = element;
            return output;
        }

        public void fromAmplitudesToBits(byte[] indata, byte[] outarray)
        {

            sbyte[] data = new sbyte[indata.Length];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (sbyte)indata[i];
            }

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] > 0) data[i] = 0;
                if (data[i] < 0) data[i] = 1;
            }

            var m = 0;
            int count = 0;
            bytedata = 0;
            for (int i = 0; i < data.Length; i++) // преобразуем биты в байты
            {
                bytedata += data[i];
                bytedata = bytedata << 1;
                count = count + 1;
                if (count == 8)
                {
                    outarray[m] = (byte)bytedata;
                    m++;
                }

            }
        }
    }
}



