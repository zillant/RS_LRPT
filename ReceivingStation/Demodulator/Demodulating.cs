using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SDRSharp.RTLSDR;
using SDRSharp.Radio;
using SDRSharp.Radio.PortAudio;
using System.Threading;
using MaterialSkin.Controls;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;
using ReceivingStation.Other;

namespace ReceivingStation.Demodulator
{
    unsafe class Demodulating // comment in dev2
    {
       
        private uint _SampleRate;
      
        private int _SymbolRate;

        private Thread _workerThread;
        private Thread _waveReadThread;
        private Thread _outputThread;

        private bool _processIsStarted;
        private bool _outputIsStarted;


        private IQFirFilter _iqFilter;

        private RtlSdrIO IO = new RtlSdrIO();
        private WaveFile _wavFile;

        private FirFilter _syncFirFilter;
        private IirFilter _syncFilter;
        private IQFirFilter _matchedFilter;

        private UnsafeBuffer _syncFilterBuffer;
        private UnsafeBuffer _buffer;
        private UnsafeBuffer _resamplerInBuffer;

        private Complex* _resampleInBufferPtr;
        private Complex* _bufferPtr;

        private ComplexFifoStream _FifoBuffer;
        private ComplexFifoStream _iqStream;

        private UnsafeBuffer _syncBuffer;
        private float* _syncBufferPtr;
        private UnsafeBuffer _recordBuffer;
        private unsafe Complex* _recordBufferPtr;
        private UnsafeBuffer _recordBufferInt;
        private unsafe Complex* _recordBufferIntPtr;
        private UnsafeBuffer _PacketsBuffer;
        private unsafe Complex* _PacketsBufferPtr;
        private UnsafeBuffer ElementBuffer;
        private unsafe Complex* ElementBufferPtr;

        private FileWriter _rawWriter;


        private byte[] _outputBuffer;
        private byte[] _outputBuffer_wInt;

        private bool _needPLLConfigure;

        private float _carrierPhase;
        private float _carrierFrequencyRadian;
        private float _minCarrierFrequencyRadian;
        private float _maxCarrierFrequencyRadian;
        private float _carrierPhaseStep;
        private float _norm;
        private float _carrierFrequencyStep;
        public bool _carrierPhaseLocked;
        public bool _LockView { get; set; }
        private float _carrierPhaseErrorAvg;
        private float SearchPhaseBandwidth;
        private float _oneMinusPhaseErrCoeff;
        private float _phaseErrorCoeff;
        private int _watchDogCounter;
        private float _carrierShift;

        private SamplesAvailableEventArgs _inputbuffer = new SamplesAvailableEventArgs();

        private float _agcGain;
        private float _lastSync;
        private float _averageGain;
        private float _agcCoeff;
        private float _oneMinusAgcCoeff;

        private bool _prevIsUp;
        private bool IsPlaying;


        private int _filterLength;
        const int MaxBufferLength = 1024 * 10;

        const float Pi = (float)Math.PI;
        const float TwoPi = (float)(2.0 * Math.PI);
        const float PiDivTwo = (float)(Math.PI * 0.5);
        const float PiDivFor = (float)(Math.PI * 0.25);
        const float LockThreshold = 0.196f;
        const float LockThresholdOut = 0.2f;

        private  int _droppedBuffers;


        private const float ByteToMb = 1f / 1024f / 1024f;
        private const int BufferSizeToRecord = 16384; // без интерливинга
        //private const int BufferSizeToRecord = 4096;
        private const int BufferSizeToRecord_withInt = 128000; // c интерливинга, длина одной посылки 40 * 2

        private string filename = (string)"";

        private StreamCorrection StreamCorrection;
        private Decode.Decode _decode;
        private BeforeViterbiSync BVS;

        private byte _FrequencyMode;
        private bool _Interliving;
        private byte _Modulation;
        private byte[] _correctedarray;
        private byte[] _correctedarray_Int;
        private byte[] arrayToDecode_Int;
        private byte[] PacketsArray;

        public bool PSPFinded;
        private int mode = 0;

        private bool FirstRead;


        private bool _NRZ;
        private bool _qpskModulation;
        private bool _oqpskModulation;
        private bool _isSelfTest;

        private Complex* _fftPtr;
        private UnsafeBuffer _fftBuffer;
        private float* _fftSpectrumPtr;
        private float[] _fftSpectrumArray;
        private UnsafeBuffer _fftSpectrum;
        private int _fftBins = 16384;
        private Complex[] samplesForFFT;

        private Complex[] samplesForConstellation;

        private UnsafeBuffer _displayOutputBuffer;
        private Complex* _displayOutputBufferPtr;

        private UnsafeBuffer _displayInputBuffer;
        private Complex* _displayInputBufferPtr;

        private bool _needDisplayBufferUpdate;
        private const int DisplayBufferLength = 8192;


        private bool iqFilter;
        private bool matchedFilter;

        private bool _dispayBufferReady;

        double[] dfftPower;
        int fftPointSpacingHz;
        private float _lastSignal;
        private float _syncCenter;

        private  bool _sWriter;
        private  bool _datWriter;

        private string _PathName;

        private  bool _HardPSP;

        private FileWriter _DemodDatfile;
        private  int _FindedBitsInPSP;
        private  int _InterlivingFindedBits;

        /// <summary>
        /// Обработчик ВЧ сигнала, используется SDR приемник
        /// </summary>
        /// <param name="filename">Имя .dat файла после демодулятора</param>
        /// <param name="freqmode">Режим несущей частоты</param>
        /// <param name="interliving">Режим интерливинга</param>
        /// <param name="modulation">Тип модуляции 0х1-QPSK; 0x2-OQPSK</param>
        /// <param name="decode">Класс декодера данных</param>
        /// <param name="SatelliteModel">Модель КА</param>
        /// <param name="sWriter">.s файл, быть ему или нет</param>
        /// <param name="datWriter">.dat файл после демодулятора, быть ему или нет</param>
        /// <param name="HardPSP">Режим поиска синхромера, при Hard ищется только один раз и больше не проверяется</param>
        /// <param name="sessionName"></param>
        /// <param name="FindedBitsInPSP">Количество найденых битов в синхромаркере, по которым можно считть маркер найденным</param>
        /// <param name="FindedBitsInInterliving">Количество найденых битов в синхромаркере интерливинга, по которым можно считть маркер найденным</param>
        public Demodulating( string filename, byte freqmode, byte interliving, byte modulation, Decode.Decode decode, string SatelliteModel, 
                                bool sWriter, bool datWriter,bool HardPSP, string sessionName, int FindedBitsInPSP, int FindedBitsInInterliving)
        {
            _FrequencyMode = freqmode;
            
            _Modulation = modulation;
            _decode = decode;
            _sWriter = sWriter;
            _datWriter = datWriter;
            _HardPSP = HardPSP;
            _FindedBitsInPSP = FindedBitsInPSP;
            _InterlivingFindedBits = FindedBitsInInterliving;
            PLLReset();
            if (interliving == 0x1)
            {
                _Interliving = true;
                _SymbolRate = 80000;
            }
            if (interliving == 0x2)
            {
                _Interliving = false;
                _SymbolRate = 72000;
            }

            if (SatelliteModel.Equals("Meteor-M2.2")) _NRZ = true;
            else if (SatelliteModel.Equals("Meteor-M2")) _NRZ = false;
                     

            var recordingfilename = filename;

            _PathName = ApplicationDirectory.GetCurrentSessionDirectory(sessionName);
            //var logfilename = "onlinelogs";
            StreamCorrection = new StreamCorrection(interliving, recordingfilename);
            BVS = new BeforeViterbiSync();

            if (_Modulation == 0x1)
            {
                _qpskModulation = true;
                _oqpskModulation = false;
            }
            else if (_Modulation == 0x2)
            {
                _oqpskModulation = true;
                _qpskModulation = false;
            }
        }
        /// <summary>
        /// Конструктор для самопроверки
        /// </summary>
        /// <param name="freqmode"></param>
        /// <param name="interliving"></param>
        /// <param name="modulation"></param>
        /// <param name="decode"></param>
        public Demodulating(byte freqmode, byte interliving, byte modulation, Decode.Decode decode) 
        {
            _FrequencyMode = freqmode;
            _Modulation = modulation;
            _decode = decode;

            if (interliving == 0x1)
            {
                _Interliving = true;
                _SymbolRate = 80000;
            }
            if (interliving == 0x2)
            {
                _Interliving = false;
                _SymbolRate = 72000;
            }

            SearchPhaseBandwidth = 275;
            _FindedBitsInPSP = 85;
            _NRZ = true;
            _InterlivingFindedBits = 26;
            

            StreamCorrection = new StreamCorrection(interliving);
            BVS = new BeforeViterbiSync();

            if (_Modulation == 0x1)
            {
                _qpskModulation = true;
                _oqpskModulation = false;
            }
            else if (_Modulation == 0x2)
            {
                _oqpskModulation = true;
                _qpskModulation = false;
            }
        }

        public int SampleRate
        {
            get
            {
                return (int)_SampleRate;
            }

            set
            {
                _SampleRate = (uint)SampleRate;
            }
        }

        
        /// <summary>
        /// Настройка SDR приемника
        /// </summary>
        /// <param name="Frequency">Несущая частота сигнала</param>
        /// <param name="SampleRate">Частота дискретизации</param>
        /// <param name="Gain">Усиление сигнала, индекс массива усилений (стандартные для приемника)</param>
        public void Dongle_Configuration(uint Frequency, uint SampleRate, int Gain)// Настройка свистка    
        {
            _SampleRate = SampleRate;
            try
            {
                IO.Open();
                IO.Device.Start();
                IO.Device.Frequency = Frequency;
                IO.Device.UseRtlAGC = false;
                IO.Device.UseTunerAGC = false;
                IO.Device.Gain = IO.Device.SupportedGains[Gain];//есть массив этих усилений, по сути здесь выбирается элемент этого массива
                IO.Device.Samplerate = SampleRate;
                IO.Device.SamplesAvailable += Samples_Available;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        /// <summary>
        /// Приемщик дискретизированных отсчетов сигнала от SDR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="inputbuffer"></param>
        public  unsafe void Samples_Available(object sender, SamplesAvailableEventArgs inputbuffer)
        {
            if (_iqStream == null)
            {
                _iqStream = new ComplexFifoStream(BlockMode.None);

            }

            if (_iqStream.Length < _SampleRate)
            {
                _iqStream.Write(inputbuffer.Buffer, inputbuffer.Length);
            }
            else
            {
                _droppedBuffers++;
                //Thread.Sleep(5);
            }

            //Тут мы только копируем данные в наш входной буфер и все.
        }

        public  void GainChanged(int Gain)
        {
            if (IO.Device != null) IO.Device.Gain = IO.Device.SupportedGains[Gain];
        }

        internal void FindedBitsChanged(int value)
        {
            _FindedBitsInPSP = value;
        }
        internal void InterlivingFindedBitsChanged(int value)
        {
            _InterlivingFindedBits = value;
        }

        internal void HardPSPChanged(bool @checked)
        {
            _HardPSP = @checked;
        }

        /// <summary>
        /// Сохранение IQ отсчетов
        /// </summary>
        /// <param name="BuftoSave">Массив отсчетов</param>
        /// <param name="buflength">Размер массива</param>
        /// <param name="BufName">Данные ДО/ПОСЛЕ согласованного фильтра</param>
        private void SaveData(Complex* BuftoSave, int buflength, bool BufName)
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

            filename = string.Format("{0}_IQ_Samples_", dateString) + BufNameStr + ".txt";

            string[] Result = new string[buflength];
            for (int i = 0; i < buflength; i++)
            {
                Result[i] = String.Format("{0:0.000000}\t{1:0.000000}", BuftoSave[i].Real, BuftoSave[i].Imag);
            }
            System.IO.File.AppendAllLines(filename, Result);
           
        }

        /// <summary>
        /// Запуск потока цифровой обработки сигнала
        /// </summary>
        public void StartDecoding()
        {
            _FifoBuffer = new ComplexFifoStream(BlockMode.None);
            _LockView = false;
            _needPLLConfigure = true;
            _droppedBuffers = 0;
            _processIsStarted = true;
            _workerThread = new Thread(new ThreadStart(DSPProc));
            _workerThread.Name = "PSK demodulator";
            _workerThread.Priority = ThreadPriority.Highest;
            _workerThread.Start();
        
            var dateString = DateTime.Now.ToString("yyyy_MM_dd");
            var timeString = DateTime.Now.ToString("HH-mm-ss");

            if (_Interliving) filename = _PathName + $"{timeString}_LRPT_INT_.s";
            if (!_Interliving) filename = _PathName + $"{timeString}_LRPT_.s";

            if (_sWriter)
            {
                _rawWriter = new Demodulator.FileWriter(filename);
                _rawWriter.Open();
            }
        }
        #region Stop Demodulating and Decoding
        /// <summary>
        /// Остановка всех потоков обработки
        /// </summary>
        public void StopDecoding()
        {
            PLLReset();
            _processIsStarted = false;
            _outputIsStarted = false;
            
            if (!IsPlaying)
            {
                try
                {
                    IO.Device.Stop();
                    IO.Device.Dispose();
                    IO.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            if (_workerThread != null)
            {
                _workerThread.Abort();
                _workerThread = null;
            }
            if (!IsPlaying && _iqStream != null)
            {
                _iqStream.Flush();
                _iqStream.Dispose();
                _iqStream.Close();
            }
            

            if (_outputThread != null)
            {
                _outputThread.Abort();
                _outputThread = null;
            }
                                    
            StreamCorrection.StopCorrect();
                     
            if (IsPlaying)
            {
                if (_waveReadThread != null)
                {
                    IsPlaying = false;
                    _waveReadThread.Abort();
                    _waveReadThread = null;
                }
            }
            
            PSPFinded = false;
            FirstRead = false;

            if (_rawWriter != null) _rawWriter.Close();
           
            _outputBuffer = null;
            _outputBuffer_wInt = null;

            if (_recordBuffer != null) _recordBuffer.Dispose();
            _recordBuffer = null;
            _recordBufferPtr = null;
            

            StreamCorrection = null;
            _buffer = null;
            if (_FifoBuffer != null)
            {
                _FifoBuffer.Flush();
                _FifoBuffer.Dispose();
                _FifoBuffer = null;
            }
            
            BVS = null;
            if (_wavFile != null)
            {
                _wavFile.Close();
                _wavFile = null;
            }
            _rawWriter = null;

            if (_DemodDatfile != null)
            {
                _DemodDatfile.Close();
                _DemodDatfile = null;
            }


        }
        #endregion

        #region Demodulating
        /// <summary>
        /// Сброс параметров петли ФАПЧ
        /// </summary>
        public  void PLLReset()
        {
            _carrierPhase = 0;
            _carrierFrequencyRadian = 0;
            _carrierPhaseErrorAvg = TwoPi;
            _needPLLConfigure = true;
            _carrierPhaseLocked = false;
        }
       
        /// <summary>
        /// Процесс ЦОС
        /// </summary>
        private void DSPProc()
        {

            var bufferLength = 4096;
            var samplerate = (double)0;
            var length = 0;
            var samplerateIn = samplerate;
            var interpolation = 1;
            var phaseError = 0.0f;
            var syncVal = 0.0f;
            var indexout = 0;
            var resultDisplay = (Complex)0;
            var data = new Complex();
            //var iqBandwidth = 80000;
            var needNewDisplayBuffer = false;


            while (_processIsStarted)
            {
                if (_iqStream == null || _iqStream.Length < bufferLength || _SampleRate == 0)
                {
                    Thread.Sleep(10);
                    continue;
                }

                #region Buffers and filters

                if (_buffer == null || samplerateIn != _SampleRate)
                {
                    samplerateIn = _SampleRate;

                    interpolation = 1;

                    while (samplerateIn * interpolation < _SymbolRate * 4)
                    {
                        interpolation = 2;
                    }

                    samplerate = samplerateIn * interpolation;
                    length = bufferLength * interpolation;

                    _buffer = UnsafeBuffer.Create(length, sizeof(Complex));
                    _bufferPtr = (Complex*)_buffer;

                    _fftBuffer = UnsafeBuffer.Create(_fftBins, sizeof(Complex));
                    _fftSpectrum = UnsafeBuffer.Create(_fftBins, sizeof(float));

                    _fftPtr = (Complex*)_fftBuffer;
                    _fftSpectrumPtr = (float*)_fftSpectrum;

                    var coeffs = FilterBuilder.MakeLowPassKernel(_SampleRate, 10, 160000, WindowType.Hamming);
                    _iqFilter = new IQFirFilter(coeffs, true, 1);
                   
                    _resamplerInBuffer = UnsafeBuffer.Create(bufferLength, sizeof(Complex));
                    _resampleInBufferPtr = (Complex*)_resamplerInBuffer;

                    _syncFilterBuffer = UnsafeBuffer.Create(sizeof(IirFilter));
                    _syncFilter = new IirFilter();

                    _syncBuffer = UnsafeBuffer.Create(length, sizeof(float));
                    _syncBufferPtr = (float*)_syncBuffer;

                    _filterLength = Math.Max((int)(samplerate / _SymbolRate) | 1, 5);

                    var coeff = FilterBuilder.MakeSinc(samplerate, _SymbolRate, _filterLength);
                    _syncFirFilter = new FirFilter(coeff);

                    coeff = FilterBuilder.MakeSinc(samplerate, _SymbolRate, _filterLength);
                    _matchedFilter = new IQFirFilter(coeff, true, 1);

                    _syncFilter.Init(IirFilterType.BandPass, _SymbolRate, samplerate, 2000);

                    _agcCoeff = _SymbolRate / (float)samplerate * 0.01f;
                    _oneMinusAgcCoeff = 1f - _agcCoeff;

                    _phaseErrorCoeff = 10.0f / (float)samplerate;
                    _oneMinusPhaseErrCoeff = 1.0f - _phaseErrorCoeff;

                    _carrierPhaseErrorAvg = TwoPi;

                    _needPLLConfigure = true;

                    _fftSpectrumArray = new float[length];
                    samplesForFFT = new Complex[length];

                    samplesForConstellation = new Complex[length];
                    _needDisplayBufferUpdate = true;


                    _displayInputBuffer = UnsafeBuffer.Create(length, sizeof(Complex));
                    _displayInputBufferPtr = (Complex*)_displayInputBuffer;

                    _displayOutputBuffer = UnsafeBuffer.Create(length, sizeof(Complex));
                    _displayOutputBufferPtr = (Complex*)_displayOutputBuffer;
                }

                if (_needPLLConfigure)
                {
                    _needPLLConfigure = false;
                    _norm = (float)(TwoPi / samplerate);
                    _minCarrierFrequencyRadian = -10000 * _norm;
                    _maxCarrierFrequencyRadian = 10000 * _norm;

                    _carrierPhaseStep = SearchPhaseBandwidth * _norm;
                    _carrierFrequencyStep = (_carrierPhaseStep * _carrierPhaseStep);
                }

                #endregion

                needNewDisplayBuffer = _needDisplayBufferUpdate;
                _needDisplayBufferUpdate = false;

                #region Interpolator and Matched filter

                if (interpolation > 1)
                {
                    _iqStream.Read(_resampleInBufferPtr, bufferLength);

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
                    _iqStream.Read(_bufferPtr, length);//прочли из потока пакет отсчетов
                }

             
                if (iqFilter)
                {
                    _iqFilter.Process(_bufferPtr, length); // пытаюсь в ФНЧ
                }


                if (matchedFilter) _matchedFilter.Process(_bufferPtr, length);

                for (int i = 0; i < length; i++)
                {
                    _fftPtr[i].Real = _bufferPtr[i].Real;
                    _fftPtr[i].Imag = _bufferPtr[i].Imag;
                }

                #endregion

                Fourier.ForwardTransform(_fftPtr, length);

                for (int i = 0; i < samplesForFFT.Length; i++)
                {
                    samplesForFFT[i].Real = _fftPtr[i].Real;
                    samplesForFFT[i].Imag = _fftPtr[i].Imag;
                }

                Fourier.SpectrumPower(samplesForFFT, _fftSpectrumArray, length, 0);

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

                _carrierPhaseLocked = (!_carrierPhaseLocked && _carrierPhaseErrorAvg < LockThreshold) || (_carrierPhaseLocked && _carrierPhaseErrorAvg < LockThresholdOut);
                _carrierShift = (int)(_carrierFrequencyRadian / _norm);

                if (_carrierPhaseLocked) _watchDogCounter = (int)(samplerate / length * 5);
                if (_watchDogCounter > 0) _watchDogCounter--;

                if (_carrierPhaseLocked)
                {
                    _carrierPhaseStep = _carrierPhaseErrorAvg * 0.0025f;

                }
                else
                {
                    _carrierPhaseStep = SearchPhaseBandwidth * _norm;
                }
                _carrierFrequencyStep = (_carrierPhaseStep * _carrierPhaseStep);

                
                indexout = 0;
                for (int i = 0; i < length; i++)
                {
                   
                    #region AGC
                    data = _bufferPtr[i];

                    var imag = data.Imag;
                    _averageGain = _averageGain * _oneMinusAgcCoeff + Math.Abs(imag) * _agcCoeff;
                    _agcGain = (0.5f / _averageGain);
                    data *= _agcGain;

                    #endregion

                    if (_needDisplayBufferUpdate && i < DisplayBufferLength) _displayInputBufferPtr[i] = data;

                    var flag = imag > 0 && _lastSignal < 0 || imag < 0 && _lastSignal > 0;
                    _lastSignal = imag;

                    syncVal = _syncFilter.Process(flag ? 1f : 0.0f);
                    _syncCenter = syncVal <= 0 || _lastSync >= 0 ? (syncVal >= 0 || _lastSync <= 0 ? 0 : -1) : 1;
                    _lastSync = syncVal;
                    //copy sync
                    if (needNewDisplayBuffer && i < DisplayBufferLength) _displayOutputBufferPtr[i] = 0;

                    if (_qpskModulation && _carrierPhaseLocked)
                    {
                        if (_syncCenter == -1)
                        {
                            _bufferPtr[indexout] = data;
                            resultDisplay = data;
                            indexout++;
                            if (needNewDisplayBuffer && (i > 0) && (i < DisplayBufferLength))
                            {
                                _displayOutputBufferPtr[i] = resultDisplay;
                            }
                        }
                    }
                    else if (_oqpskModulation)
                    {
                        if (_syncCenter == 1)
                        {
                            _bufferPtr[indexout].Real = data.Real;//_lastData.Real;
                            resultDisplay.Real = data.Real;//_lastData.Real;
                        }
                        if (_syncCenter == -1)
                        {
                            _bufferPtr[indexout].Imag = data.Imag;
                            resultDisplay.Imag = data.Imag;
                            indexout++;
                            if (needNewDisplayBuffer && (i > 0) && (i < DisplayBufferLength))
                            {
                                _displayOutputBufferPtr[i] = resultDisplay;
                            }
                        }
                    }
                }
                if (needNewDisplayBuffer) _dispayBufferReady = true;
                                
                if (_outputIsStarted && _watchDogCounter > 0)
                {
                    if (_FifoBuffer.Length < samplerate && _carrierPhaseLocked)
                    {
                        _FifoBuffer.Write(_bufferPtr, indexout);
                    }
                    else
                    {
                        //_lostBuffers++;
                    }
                }

                PlotData(_fftSpectrumArray, _fftSpectrumArray.Length, (int)_SampleRate);
            }
        }
        
        #endregion
        
        /// <summary>
        /// Обновление ГУИ 
        /// </summary>
        /// <param name="display1">Экран созвездия</param>
        /// <param name="Eye">Вкл/выкл глазковая диаграмма</param>
        /// <param name="Constellation">вкл/выкл созвездие</param>
        /// <param name="Input">отображения входных данных</param>
        /// <param name="Output">отображение выходных данных</param>
        /// <param name="scottPlotUC1">график для спектра</param>
        /// <param name="shiftLabel">поле для отображения смещения ФАПЧ</param>
        /// <param name="lbl_PSPmode">режим корректировки потока, устранения фазовой неоднозначности</param>
        public void RefreshGUIfromDemod(Display display1, bool Eye, bool Constellation, bool Input, bool Output, ScottPlot.ScottPlotUC scottPlotUC1, Label shiftLabel, Label lbl_PSPmode)
        {
            display1.Eye = Eye;
            display1.Constellation = Constellation;
            display1.Input = Input;
            display1.Output = Output;

            if (_fftSpectrumArray != null)
            {
                var graphPointCount = _fftSpectrumArray.Length;
                fftPointSpacingHz = SampleRate / graphPointCount;

                if (SampleRate == 1024000) fftPointSpacingHz = fftPointSpacingHz / 56;
                if (SampleRate == 1400000) fftPointSpacingHz = fftPointSpacingHz / 64;
                if (SampleRate == 1920000) fftPointSpacingHz = fftPointSpacingHz / 80;
                if (SampleRate == 2048000) fftPointSpacingHz = fftPointSpacingHz / 112;
                if (SampleRate == 8000000) fftPointSpacingHz = fftPointSpacingHz / 480;
            }

            if (_dispayBufferReady)
            {
                _dispayBufferReady = false;
                display1.SamplesPerSymbol = _filterLength;
                if (_displayInputBufferPtr != null || _displayOutputBufferPtr != null)
                {
                    display1.Perform(_displayInputBufferPtr, _displayOutputBufferPtr, _displayInputBuffer.Length);
                }
                display1.Refresh();
                _needDisplayBufferUpdate = true;
            }

            if (dfftPower != null)
            {
                scottPlotUC1.Clear();
                scottPlotUC1.PlotSignal(dfftPower, fftPointSpacingHz, Color.Black);
                scottPlotUC1.SizeUpdate();
            }

            shiftLabel.Text = string.Format("Смещение по частоте {0:F4}", _carrierShift);
            lbl_PSPmode.Text = string.Format("Мод корректировки потока {0}", mode);
        }

        

        /// <summary>
        /// Подготовка данных для спектра
        /// </summary>
        /// <param name="fftPower"></param>
        /// <param name="frameSize"></param>
        /// <param name="SampleRate"></param>
        public void PlotData(float[] fftPower, int frameSize, int SampleRate)
        {
            int graphPointCount = frameSize;

            dfftPower = new double[fftPower.Length];
            for (int i = 0; i < fftPower.Length; i++)
            {
                dfftPower[i] = (double)fftPower[i];
            }

        }

        
        /// <summary>
        /// Обновление параметров фильтров и ФАПЧ
        /// </summary>
        /// <param name="IQFilterSelected"></param>
        /// <param name="IQBandwidth">Ширина полосы фильтра</param>
        /// <param name="MatchedFilterSelected"></param>
        /// <param name="SearchBandwidth">Ширина полосы ФАПЧ</param>
        public void UpdateFilterParameters(bool IQFilterSelected ,int IQBandwidth, bool MatchedFilterSelected, int SearchBandwidth)
        {

            var coeffs = FilterBuilder.MakeLowPassKernel(_SampleRate, 10, IQBandwidth, WindowType.Hamming); // TO DO Сделать SetCoeff при изменении ширирны полосы фильтра
            if (_iqFilter != null) _iqFilter.SetCoefficients(coeffs);

            iqFilter = IQFilterSelected;
            matchedFilter = MatchedFilterSelected;

            if (SearchPhaseBandwidth != SearchBandwidth)
            {
                SearchPhaseBandwidth = SearchBandwidth;
                PLLReset();
            }

        }

        #region Output/Decode

        /// <summary>
        /// Запуск записи и устранения фазовой неоднозначности сигнала
        /// </summary>
        /// <param name="isSelfTest"></param>
        public void RecordStart(bool isSelfTest)
        {
            FirstRead = false;
            PSPFinded = false;


           
            _recordBuffer = UnsafeBuffer.Create(BufferSizeToRecord, sizeof(Complex));
            _recordBufferPtr = (Complex*)_recordBuffer;
            _isSelfTest = isSelfTest;

            _PacketsBuffer = UnsafeBuffer.Create(16384, sizeof(Complex));
            _PacketsBufferPtr = (Complex*)_PacketsBuffer;

            ElementBuffer = UnsafeBuffer.Create(1, sizeof(Complex));
            ElementBufferPtr = (Complex*)ElementBuffer;

            _outputBuffer = new byte[BufferSizeToRecord * 2];
            _outputBuffer_wInt = new byte[BufferSizeToRecord_withInt * 2];
            _correctedarray = new byte[32768 / 8];
            //arrayToDecode = new byte[32768];

            _correctedarray_Int = new byte[_outputBuffer_wInt.Length / 8];
            arrayToDecode_Int = new byte[2048];

            var Element = new byte[2];

            
            PacketsArray = new byte[32768];
            var timeString = DateTime.Now.ToString("HH-mm-ss");
            if (_datWriter)
            {
                _DemodDatfile = new FileWriter(_PathName + $"{timeString}_AfterDemod.dat");
                _DemodDatfile.Open();
            }
            _outputIsStarted = true;
            _outputThread = new Thread(RecordingThread);
            _outputThread.Priority = ThreadPriority.Lowest;
            _outputThread.Name = "QPSKOutputThread";
            _outputThread.Start();
         
        }
        #region Decoding

        /// <summary>
        /// Запуск декодера и корректировки потока с демодулятора
        /// </summary>

        private void RecordingThread()
        {

            var Element = new byte[2];
            var count = 0;
            var count2 = 0;
            bool offset = false;

            #region Without Interliving
            if (!_Interliving)
            {
                _recordBuffer = UnsafeBuffer.Create(BufferSizeToRecord, sizeof(Complex));
                _recordBufferPtr = (Complex*)_recordBuffer;
                while (_outputIsStarted)
                {
                    if (_FifoBuffer == null || _FifoBuffer.Length < BufferSizeToRecord)
                    {
                        Thread.Sleep(5);
                        continue;
                    }
                    if (!FirstRead && !_sWriter)
                    {
                        _FifoBuffer.Read(_recordBufferPtr, BufferSizeToRecord);
                        ConvertComplexToByte(_outputBuffer, _recordBufferPtr, BufferSizeToRecord);
                        PSPFinded = BVS.PSPSearch(_outputBuffer, _FindedBitsInPSP, _wavFile != null);
                        FirstRead = true;
                        Console.WriteLine("First Read");
                    }

                    if (FirstRead && !PSPFinded && _outputBuffer != null && !_sWriter) 
                    {

                        if (!PSPFinded)
                        {
                            _outputBuffer = Delete(_outputBuffer, 0); //удаляем первый элемент в массиве

                            _FifoBuffer.Read(ElementBufferPtr, 1); //тут считывается одно комплексное значение
                            ConvertComplexToByte(Element, ElementBufferPtr, Element.Length / 2);

                            _outputBuffer = AddElement(_outputBuffer, Element[0], _outputBuffer.Length - 1); // добавляем в конец один бит из потока, получая тем самым смещение
                           
                            if (BVS != null && _NRZ) PSPFinded = BVS.PSPSearch(_outputBuffer, _FindedBitsInPSP, _wavFile != null);
                            else if (BVS != null && !_NRZ) PSPFinded = BVS.PSPSearch_withoutNRZ(_outputBuffer, mode);// если не нашли, то смещаемся на еще один

                            if (PSPFinded) offset = true; // тесли маркер не нашелся, то есть смещение на один бит, а так из потока читается по 1 символу, состоящему из двух бит, то придется постоянно смещать на один бит

                            if (!PSPFinded)
                            {
                                _outputBuffer = Delete(_outputBuffer, 0);
                                _outputBuffer = AddElement(_outputBuffer, Element[1], _outputBuffer.Length - 1); // тут перезаписываем массив, 

                                if (BVS != null && _NRZ) PSPFinded = BVS.PSPSearch(_outputBuffer, _FindedBitsInPSP, _wavFile != null);
                                else if (BVS != null && !_NRZ) PSPFinded = BVS.PSPSearch_withoutNRZ(_outputBuffer, mode);
                                if (PSPFinded) offset = false;
                            }

                            if (PSPFinded)
                            {
                                Console.WriteLine($"Finded; Offset{offset}");;
                                count = 0;
                            }
                            else
                            {
                                count++;
                                if (count > 16384 * 6)
                                {
                                    // PLLReset();
                                    FirstRead = false;
                                    count = 0;
                                }
                            }
                        }
                    }

                    if (FirstRead && PSPFinded && _outputBuffer != null && !_sWriter) 
                    {
                        StreamCorrection.fromAmplitudesToBits(_outputBuffer, _correctedarray); // подготавливаем данные для декодера
                        if (_DemodDatfile != null) _DemodDatfile.Write(_correctedarray, _correctedarray.Length);

                        if (!_isSelfTest) _decode.StartDecode(_correctedarray, _NRZ, _Interliving);
                        else _decode.SFStartDecode(_correctedarray, _NRZ, _Interliving);
                       
                        if (_FifoBuffer != null) _FifoBuffer.Read(_recordBufferPtr, BufferSizeToRecord);
                        if (_outputBuffer != null) ConvertComplexToByte(_outputBuffer, _recordBufferPtr, BufferSizeToRecord);
                        
                        if (offset)
                        {
                            _outputBuffer = Delete(_outputBuffer, _outputBuffer.Length - 1);
                            _outputBuffer = AddElement(_outputBuffer, Element[1], 0);
                        }
                                                
                        if (BVS != null && _NRZ) PSPFinded = BVS.PSPSearch(_outputBuffer,  _FindedBitsInPSP, _wavFile != null);
                        else if (BVS != null && !_NRZ) PSPFinded = BVS.PSPSearch_withoutNRZ(_outputBuffer, mode);
                                                
                        if (BVS != null) mode = BVS.outmode;

                        if (!PSPFinded)
                        {
#if DEBUG
                            Console.WriteLine("LOST");
#endif
                            count2++;
                        }
                        else
                        {
                            count2 = 0;
                            PSPFinded = true;
                        }

                        if (_HardPSP)
                        {
                            if (count2 < 20)
                            {
                                PSPFinded = true;
                                count2 = 0;
                            }
                            else PSPFinded = false;
                        }
                        
                    }

                    if  (!_carrierPhaseLocked)
                    {
                        _FifoBuffer.Flush();
                    }

                    if (_sWriter)
                    {
                        _FifoBuffer.Read(_recordBufferPtr, BufferSizeToRecord);
                        ConvertComplexToByte(_outputBuffer, _recordBufferPtr, BufferSizeToRecord);
                        _rawWriter.Write(_outputBuffer, _outputBuffer.Length);
                    }

                }
            }
            #endregion

            #region With Interliving
            if (_Interliving)
            {
                _recordBufferInt = UnsafeBuffer.Create(BufferSizeToRecord_withInt, sizeof(Complex));
                _recordBufferIntPtr = (Complex*)_recordBufferInt;

                while (_outputIsStarted)
                {
                    if (_carrierPhaseLocked)
                    {
                        if (_FifoBuffer == null || _FifoBuffer.Length < BufferSizeToRecord_withInt )
                        {
                            Thread.Sleep(5);
                            continue;
                        }

                        if (!FirstRead && !_sWriter)
                        {
                            Console.WriteLine("First Read");
                            _FifoBuffer.Read(_recordBufferIntPtr, BufferSizeToRecord_withInt);
                            ConvertComplexToByte(_outputBuffer_wInt, _recordBufferIntPtr, BufferSizeToRecord_withInt);
                            PSPFinded = BVS.PSPSearch_wInt(_outputBuffer_wInt, _InterlivingFindedBits, false);
                            FirstRead = true;
                        }

                        if (FirstRead && !PSPFinded && _outputBuffer_wInt != null && !_sWriter)
                        {

                            _outputBuffer_wInt = Delete(_outputBuffer_wInt, 0); //удаляем первый элемент в массиве

                            _FifoBuffer.Read(ElementBufferPtr, 1); //тут считывается одно комплексное значение
                            ConvertComplexToByte(Element, ElementBufferPtr, Element.Length / 2);

                            _outputBuffer_wInt = AddElement(_outputBuffer_wInt, Element[0], _outputBuffer_wInt.Length - 1); // добавляем в конец один бит из потока, получая тем самым смещение
                            
                            if (BVS != null) PSPFinded = BVS.PSPSearch_wInt(_outputBuffer_wInt, _InterlivingFindedBits, false);

                            if (PSPFinded) offset = true; // тесли маркер не нашелся, то есть смещение на один бит, а так из потока читается по 1 символу, состоящему из двух бит, то придется постоянно смещать на один бит

                            if (!PSPFinded)
                            {
                                _outputBuffer_wInt = Delete(_outputBuffer_wInt, 0);
                                _outputBuffer_wInt = AddElement(_outputBuffer_wInt, Element[1], _outputBuffer_wInt.Length - 1); // тут перезаписываем массив, 

                                if (BVS != null) PSPFinded = BVS.PSPSearch_wInt(_outputBuffer_wInt, _InterlivingFindedBits, false);
                                if (PSPFinded) offset = false;
                            }

                            if (PSPFinded)
                            {
                                Console.WriteLine("Finded");
                                count = 0;
                            }
                            else
                            {
                                count++;
                                if (count > 256)  // если не нашелся маркер, сбрасываемся и перезахватываемся
                                {
                                    PLLReset();
                                    SearchPhaseBandwidth +=  15;
                                    FirstRead = false;
                                    count = 0;
                                }
                                Console.WriteLine("Not Finded");
                            }
                           
                        }

                        if (FirstRead && PSPFinded && _outputBuffer != null && !_sWriter) // как пришло, накапливаем к 400 пакетов, в correctedarray 4 пакета
                        {
                            //Console.WriteLine("finded");
                            StreamCorrection.fromAmplitudesToBits(_outputBuffer_wInt, _correctedarray_Int);
                            if (_DemodDatfile != null) _DemodDatfile.Write(_correctedarray_Int, _correctedarray_Int.Length);
                            if (!_isSelfTest) _decode.StartDecode(_correctedarray_Int, _NRZ, _Interliving); // режим штатной работы
                            else _decode.SFStartDecode(_correctedarray_Int, _NRZ, _Interliving);// режим самопроверки
                            _FifoBuffer.Read(_recordBufferIntPtr, BufferSizeToRecord_withInt);
                            ConvertComplexToByte(_outputBuffer_wInt, _recordBufferIntPtr, BufferSizeToRecord_withInt);
                           
                            if (offset)
                            {
                                _outputBuffer_wInt = Delete(_outputBuffer_wInt, _outputBuffer_wInt.Length - 1);
                                _outputBuffer_wInt = AddElement(_outputBuffer_wInt, Element[1], 0);
                            }

                            if (BVS != null)
                            {
                                PSPFinded = BVS.PSPSearch_wInt(_outputBuffer_wInt, _InterlivingFindedBits, _HardPSP);
                                mode = BVS.mode;
                            }
                            if (!PSPFinded) Console.WriteLine("LOST");
                            else Console.WriteLine($"Finded, offset {offset}");

                            if (!PSPFinded)
                            {
                                count2++;
                            }
                            else
                            {
                                count2 = 0;
                                PSPFinded = true;
                            }
                            if (_HardPSP)
                            {
                                if (count2 < 20)
                                {
                                    PSPFinded = true;
                                    count2 = 0;
                                }
                                else PSPFinded = false;
                            }
                            count = 0;
                        }

                        if (!_carrierPhaseLocked)
                        {
                            _FifoBuffer.Flush();
                        }


                        if (_sWriter)
                        {
                            _FifoBuffer.Read(_recordBufferPtr, BufferSizeToRecord);
                            ConvertComplexToByte(_outputBuffer, _recordBufferPtr, BufferSizeToRecord);
                            _rawWriter.Write(_outputBuffer, _outputBuffer.Length);
                        }

                    }
                }
            }
            #endregion
        }

        public bool[] UpdateDataGui()
        {
            bool[] flags = new bool[2];

            flags[0] = PSPFinded;
            flags[1] = _carrierPhaseLocked;

            return flags;
        }


        private void ConvertComplexToByte(byte[] dest, Complex* source, int sourceLength)
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


        private byte FloatToByte(float sample)
        {
            sample *= 127;
            if (sample > 127) sample = 127;
            else if (sample < -127) sample = -127;
            return (byte)sample;
        }

        private  byte SymbToByte(float sample)
        {
            return (byte)sample;
        }

        private  byte[] Delete(byte[] array, int indexToDelete)// удаляет элементы из массива
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


        private  byte[] AddElement(byte[] array, byte element, int index)//добавляет элемент в конец массива
        {
            if (array.Length == 0) return array;
            if (array.Length <= index) return array;

            var output = new byte[array.Length + 1];
            int counter = 0;
            for (int i = 0; i < output.Length; i++)
            {
                if (i == index)
                {
                    output[i] = element;
                    continue;
                }
                output[i] = array[counter];
                counter++;
            }
            return output;
        }

        private void fromAmplitudesToBits(byte[] indata, byte[] outarray)
        {
            BinaryWriter datfile = new BinaryWriter(File.Open(@"AfterSync_HEX.dat", FileMode.OpenOrCreate));
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
            var bytedata = 0;
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
            datfile.Write(outarray, 0, outarray.Length);
            datfile.Close();
        }

        #endregion
        #endregion

        private void Decimation(Complex* SamplesPtr, Complex* SamplesOutPtr, int buflength, int DecimationCoeff)
        {
            var outlength = (int)(buflength / DecimationCoeff);

            var k = 0;

            for (int n = 1; n < outlength; n++)
            {
                SamplesOutPtr[n].Real = SamplesPtr[k].Real;
                SamplesOutPtr[n].Imag = SamplesPtr[k].Imag;
                k += DecimationCoeff;
            }
            
        }

        private void FrequencyOffset(Complex* SamplesPtr, Complex* SamplesOutPtr, int buflength, int Offset, uint SampleRate)
        {
            double T = 1 / SampleRate;
            var Pi = Math.PI;
            var arg = 2 * Pi * Offset;
            double i = 0;
            double wavePer = T * buflength / SampleRate;
            for (int n = 1; n < buflength; n++)
            {
                    SamplesOutPtr[n].Real = (float)Math.Cos(arg * i);
                    SamplesOutPtr[n].Imag = (float)Math.Sin(arg * i);
                    i = wavePer * n;
            }

            for (int k = 0; k < buflength; k++)
            {
                SamplesOutPtr[k].Real = SamplesOutPtr[k].Real * SamplesPtr[k].Real;
                SamplesOutPtr[k].Imag = SamplesOutPtr[k].Imag * SamplesPtr[k].Imag;
            }
        }

        public void wav_samples(string filename, int bufferSizeInMs, bool isSelfTest)
        {
            _wavFile = new WaveFile(filename);
            _SampleRate = (uint)_wavFile.SampleRate;
            _iqStream = new ComplexFifoStream(BlockMode.BlockingRead);
            StartWAVReading();
            StartDecoding();
            RecordStart(isSelfTest);
        }



        private void StartWAVReading()
        {
            IsPlaying = true;
            _waveReadThread = new Thread(new ThreadStart(wavToStream));
            _waveReadThread.Priority = ThreadPriority.Normal;
            _waveReadThread.Start();
        }

        private void wavToStream()
        {
            var WaveBufferSize = 4096;
            var waveInBuffer = new Complex[WaveBufferSize];
            fixed (Complex* waveInPtr = waveInBuffer)
            {
                while (IsPlaying)
                {
                    if (_iqStream.Length < WaveBufferSize * 4 && _wavFile != null)
                    {
                        _wavFile.Read(waveInPtr, waveInBuffer.Length);
                        _iqStream.Write(waveInPtr, waveInBuffer.Length);
                    }
                    else
                    {
                        Thread.Sleep(5);
                    }
                }
            }
        }
    }
}



