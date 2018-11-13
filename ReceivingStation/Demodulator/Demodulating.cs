using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDRSharp.RTLSDR;
using SDRSharp.Radio;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using ReceivingStation.Demodulator;
using ReceivingStation;
using Platform.IO;




namespace ReceivingStation.Demodulator
{
    delegate void TimeHandler();
    public unsafe partial class Demodulating
    {
        static event TimeHandler onTime;
        public delegate void GuiLabelUpdater(Label label, string text);
        public static GuiLabelUpdater ThreadGuiLabelsUpdater;

        static MainForm _form;
        static byte _FrequencyMode;
        static byte _Interliving;


        // параметры приемника
        const int Gain = 14; // Усиление свистка 15дБ
        const int TotalSamples = 10000;
        const int BL = 401;// Matlabs FIR Order
        const double SampleRate_FIR = 1024000;
        const int _symbolRate = 72000 ;
        const uint _Frequency = 137883170;
        const uint _SampleRate = 1024000;

        // инициализация потока
        static Thread _workerThread;
        static Thread _outputThread;
        static Thread _DisplayThread;
        static FileWriter _rawWriter;
        static FileWriter _bitsWriter;
        static FifoStream _beforeSyncBitStream;
        static FifoStream _AfterSyncBitStream;

        //флаги состотояния 
        static bool _processIsStarted;
        static bool _outputIsStarted;
        static bool _View;
        static bool _syncronization;
        static bool _recording;

        static int Samples = 0;
        static int _lostBuffers;

        static RtlSdrIO IO = new RtlSdrIO();// создание объекта свистка
        static BeforeViterbiSync _correctstream = new BeforeViterbiSync(); // объект корректировки потока, смотри одноименный файл

        // создание объектов фильтров, используемых при обработка
        static IQFirFilter _LowPassFirFilter;
        static FirFilter _syncFirFilter;
        static IirFilter* _syncFilter;
        static float[] _coeffs;

        // создание объектов буфферов, содержащих в себе отсчеты на различных этапах цифровой обработки сигнала. Смотри матлабовский скрипт, я пытался там максимально объяснить процесс обработки.
        static UnsafeBuffer _syncFilterBuffer;
        static UnsafeBuffer _buffer;
        static UnsafeBuffer _resamplerInBuffer;
        static UnsafeBuffer _bitBuffer;
        static byte* _bitBufferPtr;
        static Complex* _resampleInBufferPtr;
        static Complex* _bufferPtr;
        static Complex* _bufferPtrLP;
        static ComplexFifoStream _FifoBuffer;
        static ComplexFifoStream _inputfifoBuffer;
        static UnsafeBuffer _syncBuffer;
        static float* _syncBufferPtr;
        static Complex _prevBuffer;
        static UnsafeBuffer _recordBuffer;
        static unsafe Complex* _recordBufferPtr;

        //static Stream _outSamplesStream;


        static byte[] _bits;
        static byte[] _correctedarray;

        
        static byte[] _outputBuffer;
        static float _writeLength;

        // параметры ФАПЧ
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


        static UnsafeBuffer _bufferAfterLowPass;//after matched, по сути не нужно, делал для отладки
        static Complex* _bufferPtrAfterLowPass;


        static SamplesAvailableEventArgs _inputbuffer = new SamplesAvailableEventArgs(); // нужно для получения отсчетов с приемника

        // параметры АРУ
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

        private static int _droppedBuffers; // для отладки

        static Complex _lastData;

        private const float ByteToMb = 1f / 1024f / 1024f;
        private const int BufferSizeToRecord = 16384*10;
        static int _bitbufferlength = 16384;//длина буффера байтов, для пересылки на декодер

        static string filename = (string)"";

        static StreamCorrection StreamCorrection ;

        #region Конструктор со свойствами класса
        public Demodulating(byte freqmode)
        {
            _FrequencyMode = freqmode;
            _bitBuffer = UnsafeBuffer.Create(_bitbufferlength, sizeof(Complex));
            _bitBufferPtr = (byte*)_bitBuffer;
            // создаем потоки
            _beforeSyncBitStream = new FifoStream(65534);
            _AfterSyncBitStream = new FifoStream(65534);
        }

        public bool isLocked
        {
            get
            {
                return _carrierPhaseLocked;
            }
        }

        public bool recordingStarted
        {
            get
            {
                return _recording;
            }
        }

        public bool processIsStarted
        {
            get
            {
                return _processIsStarted;
            }
        }

        #endregion

        #region Настройка приемника
        public void Dongle_Configuration(uint SampleRate)// Настройка свистка    
        {
            uint Frequency = 0;

            if (_FrequencyMode == 0x1) Frequency = 137080000;
            if (_FrequencyMode == 0x2) Frequency = 137883170;

            
            IO.Open();
            IO.Device.Start();
            IO.Device.SamplesAvailable += Samples_Available;
            IO.Device.Frequency = Frequency;
            IO.Device.UseRtlAGC = true;
            IO.Device.UseTunerAGC = true;
            IO.Device.Samplerate = SampleRate;
            IO.Device.UseRtlAGC = true;
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

        #endregion

        static void SaveData(Complex* BuftoSave, int buflength, bool BufName)
        {
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
        #region Запуск Демодулятора
        public void DSP_Process(MainForm form, byte[] correctedArray) // Метод запускает поток демодулятора и поток, записывающий файл. _beforeSyncBitStream  возвращаем в класс обращения к данному методу, чтобы потом скорректировать поток к нужному созвездию.
        {
            _recordBuffer = UnsafeBuffer.Create(BufferSizeToRecord, sizeof(Complex));
            _recordBufferPtr = (Complex*)_recordBuffer;


            //Dongle_Configuration(1024000);// инициализируем свисток, в нем отсчеты записываются в поток
            _form = form;

            if (IO.Device != null) ThreadGuiLabelsUpdater(_form.label7, "Приемник настроен");
            if (_FifoBuffer == null) _FifoBuffer = new ComplexFifoStream(BlockMode.None);
            _form.label9.Text = "Нет захвата...";

            _droppedBuffers = 0;

            _processIsStarted = true;

            BufferProcess(); // запускаем ЦОС

            var length = 16384 * 4;
            _FifoBuffer.Read(_recordBufferPtr, length);// читаем демодулированные отсчеты из потока

            ConvertComplexToByte(_outputBuffer, _recordBufferPtr, length);// демодулированные отсчеты превращаем в byte, по сути это значения амплитуд IQ на каждом отсчете в 8-битовой форме

            StreamCorrection.StreamCorrect(_outputBuffer, _outputBuffer.Length, _correctedarray);

            correctedArray = _correctedarray;          


        }
        #endregion

        #region Остановка демодулятора
        public void StopDemodulating()
        {
           

            if (IO.Device != null)
            {
                IO.Device.Stop();
                IO.Close();
                ThreadGuiLabelsUpdater(_form.label7, "Приемник выключен");
            }

            if (_workerThread != null)
            {
                //_workerThread.Join(); тут почему то зависает
                _workerThread = null;
                ThreadGuiLabelsUpdater(_form.label8, "Демодулятор выключен");
            }

            _inputfifoBuffer.Close();
            _inputfifoBuffer.Dispose();

            _outputIsStarted = false;

            if (_outputThread != null)
            {
               _outputThread.Join();
                _outputThread = null;
            }

            //if (_DisplayThread != null)
            //{
            //    _DisplayThread.Join();
            //    _DisplayThread = null;
            //}

            // _DisplayThread = null;
            _recordBuffer.Dispose();
            _recordBuffer = null;
            _recordBufferPtr = null;
            _rawWriter.Close();
            //_rawWriter = null;
            _recording = false;

            _processIsStarted = false;

            //if (StreamCorrection == null)  StreamCorrection = new StreamCorrection();
            //if (!_recording) StreamCorrection.StreamCorrect(filename); // отправляем сюда .s файл для корректировки и превращения в битовый поток

        }
        #endregion

        #region Процесс демодуляции, ЦОС во всей красе
        public void PLLReset()
        {
            _carrierPhase = 0;
            _carrierFrequencyRadian = 0;
            _carrierPhaseErrorAvg = TwoPi;
        }
        public static void BufferProcess()
        {
            var bufferLength = 2048;
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
                if (_inputfifoBuffer == null || _inputfifoBuffer.Length < bufferLength)
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
                    _bufferPtrLP = (Complex*)_buffer;

                    _resamplerInBuffer = UnsafeBuffer.Create(bufferLength, sizeof(Complex));
                    _resampleInBufferPtr = (Complex*)_resamplerInBuffer;

                    _bufferAfterLowPass = UnsafeBuffer.Create(bufferLength, sizeof(Complex));
                    _bufferPtrAfterLowPass = (Complex*)_bufferAfterLowPass;

                    _syncFilterBuffer = UnsafeBuffer.Create(sizeof(IirFilter));
                    _syncFilter = (IirFilter*)_syncFilterBuffer;

                    _syncBuffer = UnsafeBuffer.Create(length, sizeof(float));
                    _syncBufferPtr = (float*)_syncBuffer;

                    _filterLength = Math.Max((int)(_SampleRate / _symbolRate) | 1, 5);

                    var coeff = FilterBuilder.MakeSinc(_SampleRate, _symbolRate, _filterLength);
                    _syncFirFilter = new FirFilter(coeff);

                    coeff = FilterBuilder.MakeSinc(_SampleRate, _symbolRate, _filterLength);
                    _LowPassFirFilter = new IQFirFilter(coeff, false, 1);//// TRUE OR FALSE?????


                    _bufferPtrAfterLowPass = _bufferPtr;
                    _coeffs = coeff; // сохранение КИХ коэффициентов

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
                    _form.Invoke(new Action(() => { _form.label9.Text = "Захвачено"; }));
                    _LockView = true;
                    _View = true;

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
                        //if (needNewDisplayBuffer && (i > 0) && (i < DisplayBufferLength))
                        //{
                        //    _displayOutputBufferPtr[i - 1] = resultDisplay;
                        //}
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

                if (!_carrierPhaseLocked && _LockView) //если созвездие было захвачено и рассыпалось
                {
                    //_form.Invoke(new Action(() => { _form.label9.Text = "Захват потерян"; }));
                    ThreadGuiLabelsUpdater(_form.label9, "Захват потерян");
                    _LockView = false;
                } 

            }

        }
        #endregion

        #region Recording
        static void RecordingThread()
        {
           
            _recordBuffer = UnsafeBuffer.Create(BufferSizeToRecord, sizeof(Complex));
            _recordBufferPtr = (Complex*)_recordBuffer;

            _outputBuffer = new byte[BufferSizeToRecord*2];
            _bits = new byte[BufferSizeToRecord * 2];
            while (_outputIsStarted)
            {
                _recording = true;
                if (_FifoBuffer == null || _FifoBuffer.Length < BufferSizeToRecord)
                {
                    Thread.Sleep(10);
                    continue;
                }

                _FifoBuffer.Read(_recordBufferPtr, BufferSizeToRecord);

                ConvertComplexToByte(_outputBuffer, _recordBufferPtr, BufferSizeToRecord);

                StreamCorrection.StreamCorrect(_outputBuffer, _outputBuffer.Length, _correctedarray);// Может прям тут и корректировать _outputBuffer????
                //_beforeSyncBitStream.Write(_outputBuffer, 0, _outputBuffer.Length); // делаем запись в байтовый буффер, в нем лежат величины амплитуд в sbyte 

                _writeLength += _outputBuffer.Length * ByteToMb;

                _rawWriter.Write(_outputBuffer, _outputBuffer.Length);
                
            }

            while (_FifoBuffer.Length > 0)
            {
                var length = Math.Min(_FifoBuffer.Length, BufferSizeToRecord);

                _FifoBuffer.Read(_recordBufferPtr, length);

                 ConvertComplexToByte(_outputBuffer, _recordBufferPtr, length);

                StreamCorrection.StreamCorrect(_outputBuffer, _outputBuffer.Length, _correctedarray);

                _rawWriter.Write(_outputBuffer, length);

                _beforeSyncBitStream.Write(_outputBuffer,0,_outputBuffer.Length); // делаем запись в байтовый буффер, в нем лежат величины амплитуд в sbyte 

                _writeLength += length * ByteToMb;

                //_form.Invoke(new Action(() => { _form.label10.Text = "Запись началась"; }));
                ThreadGuiLabelsUpdater(_form.label10, "Запись началась");
            }

         
        }
        #endregion

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

        static void AmpSaveData(Complex* BuftoSave, int buflength)
        {
            //var buflength = _inputbuffer.Length;
            //var buflength = TotalSamples;
            var dateString = DateTime.Now.ToString("yyyy_MM_dd");
            var timeString = DateTime.Now.ToString("HH-mm-ss");

            var filename = (string)"";

            filename = string.Format("{0}_Final_IQ_Samples_{1}", dateString, timeString) + ".txt";

            string[] Result = new string[buflength];
            for (int i = 0; i < buflength; i++)
            {
                Result[i] = String.Format("{0:0.000000}\t{1:0.000000}", BuftoSave[i].Real, BuftoSave[i].Imag);
                
            }
            System.IO.File.WriteAllLines(filename, Result);
        }

        static byte FloatToByte(float sample)
        {
            sample *= 127;
            if (sample > 127) sample = 127;
            else if (sample < -127) sample = -127;
            return (byte)sample;
        }

        static byte SymbToByte(float sample)
        {
            return (byte)sample;
        }

        static void ViewSize()
        {
            onTime += new TimeHandler(one);

            run();

            if (_syncronization)
            {
                StreamCorrection.StreamCorrect(filename);
            }
        }

        static void run()
        {

            while (true)
            {
                if (!_carrierPhaseLocked)
                {
                    System.Threading.Thread.Sleep(1000);


                }

                if (_carrierPhaseLocked)
                {
                    //Console.WriteLine("Recording...");
                    onTime();
                    System.Threading.Thread.Sleep(500);
                    _syncronization = true;
                }
            }
        }

        static void one()
        {
            float newSize = _writeLength;
        }

        //static void StartRecieving()
        //{
        //    Dongle_Configuration(_SampleRate);
        //    StartDecoding();
        //    SaveData(_bufferPtrAfterLowPass, 2048, false);
        //    SaveData(_bufferPtrLP, 2048, true);
        //    AmpSaveData(_recordBufferPtr, 8192);

        //    if (!_syncronization)
        //    {
        //        StopRecieving();
        //    }

        //    StreamCorrection = new StreamCorrection();
        //    if (!_recording) StreamCorrection.StreamCorrect(filename); // отправляем сюда .s файл для корректировки и превращения в битовый поток

        //}
    }
}



