using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ReceivingStation.Other;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using MaterialSkin.Controls;
using ReceivingStation.MessageBoxes;
using ReceivingStation.Properties;
using ReceivingStation.Decode;

namespace ReceivingStation
{
    public unsafe partial class FormReceive : MaterialForm
    {
        public static TimeSpan MainFcpWorkingTime;
        public static TimeSpan ReserveFcpWorkingTime;
        public static TimeSpan MainPrdWorkingTime;
        public static TimeSpan ReservePrdWorkingTime;
        public static TimeSpan FullWorkingTime; // Общее время работы системы. (Не используем в релизе)        

        private const int TimeForSaveWorkingTime = 1800; // Время для таймера (сек), через которое нужно сохранять наработку в файл. 
        private int _counterForSaveWorkingTime; // Счетчик для таймера, через которое нужно сохранять время наработки в файл.

        private string _fileName;

        private long _imageCounter; // Счетчик сохранненых изображений.

        private Panel[] _allChannelsPanels = new Panel[6]; // Панели на которых находятся FLP для всех каналов.
        private Panel[] _channelsPanels = new Panel[6]; // Панели на которых находятся FLP для каждого канала.
        private FlowLayoutPanel[] _channels = new FlowLayoutPanel[6]; // FLP для хранения полосок изображения для каждого канала.
        private FlowLayoutPanel[] _allChannels = new FlowLayoutPanel[6]; // FLP для хранения полосок изображения для всех каналов.
        private List<Bitmap>[] _listImagesForSave = new List<Bitmap>[6]; // Список для хранения полосок изображения, нужно для сохранения.

        private DateTime _startWorkingTime; // Время начала работы борта.

        private Demodulator.Demodulating _receiver;
        private Server.Server _server;
        private Thread _serverThread;
        private Decode.Decode _decode;

        // Параметры приема битового потока.
        private byte _fcp;
        private byte _prd;
        private byte _freq;
        private byte _interliving;
        private byte _modulation;

        private string _waveFile;

        private bool _isSignalPhaseSync = false;

        // private Demodulator.FFT_Form FFT_Form;

        /// <summary>
        /// Типы источника отсчетов сигнала
        /// </summary>
        private enum InputType
        {
            RTLSDR,
            WavFile
        }
        private InputType _inputType;

        private bool[] flags = new bool[2]; // Массив состояний демодулятора flag[0] = синхронизация фазы синхропосылки; flag[1] = захват петли ФАПЧ

        public FormReceive()
        {
            InitializeComponent();
        }

        #region gui

        private void FormReceive_Load(object sender, EventArgs e)
        {
            numUpD_FindedBitsInPSP.Value = Properties.Settings.Default.PSP_FindedBits;
            numUpD_FindedBitsInInterliving.Value = Settings.Default.Interliving_FindedBits;
            numUpD_PLLBw.Value = Properties.Settings.Default.PLL_Bandwidth;
            cBx_HardPSP.Checked = Settings.Default.HardPSP;
            //FFT_Form = new Demodulator.FFT_Form();

            GuiUpdater.SmoothLoadingForm(this);

            GuiUpdater.DecodeRichTextBoxInit(rtbMkoTitle, rtbMkoData, rtbDateTimeTitle, rtbDateTime, rtbServiceTitle, rtbServiceData);

            materialTabControl1.SelectedTab = tabPage7;

            _counterForSaveWorkingTime = TimeForSaveWorkingTime;

            LogFiles.ReadWorkingTimeValues(out MainFcpWorkingTime, out ReserveFcpWorkingTime, out MainPrdWorkingTime, out ReservePrdWorkingTime);

            _channelsPanels[0] = pImage1;
            _channelsPanels[1] = pImage2;
            _channelsPanels[2] = pImage3;
            _channelsPanels[3] = pImage4;
            _channelsPanels[4] = pImage5;
            _channelsPanels[5] = pImage6;

            _allChannelsPanels[0] = pImage7;
            _allChannelsPanels[1] = pImage8;
            _allChannelsPanels[2] = pImage9;
            _allChannelsPanels[3] = pImage10;
            _allChannelsPanels[4] = pImage11;
            _allChannelsPanels[5] = pImage12;

            materialTabControl1.TabPages.Remove(tabPage10);

            for (int i = 0; i < 6; i++)
            {
                _allChannels[i] = GuiUpdater.GetFlp(new Size(242, 8));
                _channels[i] = GuiUpdater.GetFlp(new Size(1556, 40));
                _allChannelsPanels[i].Controls.Add(_allChannels[i]);
                _channelsPanels[i].Controls.Add(_channels[i]);
                _listImagesForSave[i] = new List<Bitmap>();
            }

            slTime.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);

            _server = new Server.Server(false)
            {
                ReceivingStartedFlag = false,
                ThreadSafeChangeMode = ChangeMode,
                ThreadSafeSetReceiveParameters = SetReceiveParameters,
                ThreadSafeStartStopReceiving = StartStopReceiving,
                ThreadSafeGetSyncsStates = GetSyncsStates,
            };
            Server.Server.RemoteModeFlag = false;

            _serverThread = new Thread(_server.StartServer) { IsBackground = true };
            _serverThread.Start();

            ConfigSecretTab();
            timer1.Start();
        }

        private void FormReceive_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = FormDialogMessageBox.Show("Выход", "Вы уверены, что хотите закрыть программу?", Resources.door_exit_icon);

            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void FormReceive_FormClosed(object sender, FormClosedEventArgs e)
        {
            _server.StopThread = true;
            _serverThread.Join(100);

            Application.Exit();
        }

        private void FormReceive_KeyDown(object sender, KeyEventArgs e)
        {
            int currentWidth = Size.Width;
            int currentHeight = Size.Height;

            // Alt + L  
            if (e.Alt && e.KeyCode == Keys.L)
            {
                if (pModulation.Visible)
                {
                    pModulation.Visible = false;
                    pSourcePanel.Visible = false;
                    materialTabControl1.TabPages.Remove(tabPage10);
                }
                else
                {
                    pModulation.Visible = true;
                    pSourcePanel.Visible = true;
                    materialTabControl1.TabPages.Add(tabPage10);
                }
                e.SuppressKeyPress = true;
            }
            if (e.Alt && e.KeyCode == Keys.J)
            {
                if (this.Size.Width > GuiUpdater.MinFormWidth && this.Size.Height > GuiUpdater.MinFormHeight)
                {
                    this.Size = new Size(currentWidth - GuiUpdater.FormWidthValue, currentHeight - GuiUpdater.FormHeightValue);
                }
                e.SuppressKeyPress = true;
            }
            else if (e.Alt && e.KeyCode == Keys.K)
            {
                if (this.Size.Width < GuiUpdater.MaxFormWidth && this.Size.Height < GuiUpdater.MaxFormHeight)
                {
                    this.Size = new Size(currentWidth + GuiUpdater.FormWidthValue, currentHeight + GuiUpdater.FormHeightValue);
                }
                e.SuppressKeyPress = true;
            }
        }

        private void btnStartRecieve_Click(object sender, EventArgs e)
        {
            StartStopReceiving();

        }

        private void slMode_DoubleClick(object sender, EventArgs e)
        {
            using (FormModeSettings modeSettingsForm = new FormModeSettings())
            {
                modeSettingsForm.ChangeMode = ChangeMode;
                modeSettingsForm.ShowDialog();
            }
        }

        private void slWorkingTimeOnboard_DoubleClick(object sender, EventArgs e)
        {
            using (FormWorkingTimes workingTimesForm = new FormWorkingTimes())
            {
                workingTimesForm.ShowDialog();
            }
        }

        private void slMode_MouseLeave(object sender, EventArgs e)
        {
            slMode.BackColor = SystemColors.Window;
        }

        private void slWorkingTimeOnboard_MouseLeave(object sender, EventArgs e)
        {
            slWorkingTimeOnboard.BackColor = SystemColors.Window;
        }

        private void slWorkingTimeOnboard_MouseMove(object sender, MouseEventArgs e)
        {
            slWorkingTimeOnboard.BackColor = SystemColors.ControlLight;
        }

        private void slMode_MouseMove(object sender, MouseEventArgs e)
        {
            slMode.BackColor = SystemColors.ControlLight;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            slTime.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);

            _counterForSaveWorkingTime -= 1;

            if (_counterForSaveWorkingTime == 0)
            {
                if (_server.ReceivingStartedFlag)
                {
                    CountWorkingTime();
                    _startWorkingTime = DateTime.Now;
                    LogFiles.WriteWorkingTimeValues(MainFcpWorkingTime, ReserveFcpWorkingTime, MainPrdWorkingTime, ReservePrdWorkingTime);
                }
                _counterForSaveWorkingTime = TimeForSaveWorkingTime;
            }

            if (_server.ReceivingStartedFlag && _receiver != null)
            {
                flags = _receiver.UpdateDataGui();
                UpdateGuiDemodulationData(flags);
            }
        }

        private void bwImageSaver_DoWork(object sender, DoWorkEventArgs e)
        {
            ImageSaver.SaveImage(_listImagesForSave, _fileName, _imageCounter);
            _imageCounter += 1;
        }

        #endregion

        #region Установка параметров записи потока.

        private void SetReceiveParameters()
        {
            _fcp = Convert.ToByte(rbFCPMain.Checked ? 0x1 : 0x2);
            _prd = Convert.ToByte(rbPRDMain.Checked ? 0x1 : 0x2);
            _freq = Convert.ToByte(rbFreq1.Checked ? 0x1 : 0x2);
            _interliving = Convert.ToByte(rbInterlivingReceiveOn.Checked ? 0x1 : 0x2);
        }

        private void SetReceiveParameters(byte fcp, byte prd, byte freq, byte interliving)
        {
            // Пауза для тестирования "Выполнение предыдущей команды не завершено"
            // for (int i = 0; i < 999999999; i++) { }

            _fcp = fcp;
            _prd = prd;
            _freq = freq;
            _interliving = interliving;

            Invoke(new Action(() => { SetRadioButtons(_fcp, rbFCPMain, rbFCPReserve); }));
            Invoke(new Action(() => { SetRadioButtons(_prd, rbPRDMain, rbPRDReserve); }));
            Invoke(new Action(() => { SetRadioButtons(_freq, rbFreq1, rbFreq2); }));
            Invoke(new Action(() => { SetRadioButtons(_interliving, rbInterlivingReceiveOn, rbInterlivingReceiveOff); }));
        }

        private void SetRadioButtons(byte param, RadioButton rb1, RadioButton rb2)
        {
            if (param == 0x1)
            {
                rb1.Checked = true;
            }
            else
            {
                rb2.Checked = true;
            }
        }

        #endregion

        #region Начать/Остановить прием потока.


        public void StartStopReceiving()
        {
            if (!_server.ReceivingStartedFlag)
            {
                if (!Server.Server.RemoteModeFlag)
                {
                    SetReceiveParameters();
                }

                _server.ReceivingStartedFlag = true;
                btnStartRecieve.SetPropertyThreadSafe(() => btnStartRecieve.Text, "Остановить");
                tlpReceivingParameters.SetPropertyThreadSafe(() => tlpReceivingParameters.Enabled, false);

                string fcps = "";
                string prds = "";
                string inters = "";
                string freqs = "";

                if (_fcp == 0x1) fcps = "O";
                else if (_fcp == 0x2) fcps = "P";

                if (_prd == 0x1) prds = "O";
                else if (_prd == 0x2) prds = "P";

                if (_freq == 0x1)
                {
                    freqs = "137.1";
                }
                else if (_freq == 0x2) freqs = "137.9";

                if (_interliving == 0x1) inters = "с_инт";
                else if (_interliving == 0x2) inters = "без_инт";

                if (rbFUNcube.Checked) _inputType = InputType.RTLSDR;
                if (rbWav.Checked) _inputType = InputType.WavFile;

                var timeString = DateTime.Now.ToString("HH-mm-ss");
                var sessionName = $"{timeString}_{fcps}_{prds}_{freqs}_{inters}";
                _fileName = $"{ApplicationDirectory.GetCurrentSessionDirectory($"{sessionName}")}\\{sessionName}.dat";


                ShowSignalSyncErr();
                ShowInterSyncErr();

                // Очистка всего перед новым запуском.
                for (int i = 0; i < 6; i++)
                {
                    _allChannels[i].Controls.Clear();
                    _channels[i].Controls.Clear();
                    _listImagesForSave[i].Clear();

                    Directory.CreateDirectory($"{Path.GetDirectoryName(_fileName)}\\{Path.GetFileNameWithoutExtension(_fileName)}_Channel_{i + 1}");
                    DirectoryInfo di = new DirectoryInfo($"{Path.GetDirectoryName(_fileName)}\\{Path.GetFileNameWithoutExtension(_fileName)}_Channel_{i + 1}");

                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                }

                _startWorkingTime = DateTime.Now;
                _imageCounter = 0;

                LogFiles.WriteUserActions($"Установлены параметры: ФПЦ - {_fcp}, ПРД - {_prd}, Частота - {_freq}, Интерливинг - {_interliving}");
                LogFiles.WriteUserActions("Запись потока начата");

                if (rbOqpsk.Checked) _modulation = 0x2;
                if (rbQpsk.Checked) _modulation = 0x1;

                lblLocked.Visible = false;

                var isSelfTest = false;
                var SampleRate = UInt32.Parse(comBx_SampleRate.Text);

                _decode = new Decode.Decode(_fileName) { ThreadSafeUpdateGui = UpdateGuiDecodeData };
                _receiver = new Demodulator.Demodulating(_fileName, _freq, _interliving, _modulation, _decode, comBxModulation.SelectedItem.ToString(), chBx_sWriter.Checked, cBx_datWriter.Checked, cBx_HardPSP.Checked, sessionName, (int)numUpD_FindedBitsInPSP.Value, (int)numUpD_FindedBitsInInterliving.Value);

                SetupGraphLabels((int)SampleRate);

                if (_inputType == InputType.RTLSDR)
                {
                    var freq = Decimal.Parse(comBx_carrier.Text);
                    var Frequency = (uint)(freq * 1000000);

                    var gain = (int)GainNM.Value;

                    _receiver.Dongle_Configuration(Frequency, SampleRate, gain);// инициализируем свисток, в нем отсчеты записываются в поток                    StartDecoding();
                    _receiver.StartDecoding();
                    _receiver.RecordStart(isSelfTest);
                }
                if (_inputType == InputType.WavFile) // если хотим считать с файла
                {

                    try
                    {
                        SelectWaveFile();
                        if (!File.Exists(_waveFile))
                        {
                            throw new ApplicationException("Не выбран файл");
                        }
                        _receiver.wav_samples(_waveFile, 2048);
                    }
                    catch (ApplicationException ex)
                    {
                        MessageBox.Show(ex.Message);
                        StopReceiving();
                    }
                }
                cBx_HardPSP.CheckedChanged += CBx_HardPSP_CheckedChanged;
                GainNM.ValueChanged += GainNM_ValueChanged;
                numUpD_FindedBitsInPSP.ValueChanged += NumUpD_FindedBitsInPSP_ValueChanged;
                numUpD_FindedBitsInInterliving.ValueChanged += NumUpD_FindedBitsInInterliving_ValueChanged;
                //FFT_Form.SetupGraphLabels(_receiver.SampleRate);
            }
            else
            {
                StopReceiving();
            }

        }

        private void NumUpD_FindedBitsInInterliving_ValueChanged(object sender, EventArgs e)
        {
            _receiver.InterlivingFindedBitsChanged((int)numUpD_FindedBitsInInterliving.Value);
        }

        private void CBx_HardPSP_CheckedChanged(object sender, EventArgs e)
        {
            _receiver.HardPSPChanged(cBx_HardPSP.Checked);
        }

        private void NumUpD_FindedBitsInPSP_ValueChanged(object sender, EventArgs e)
        {
            _receiver.FindedBitsChanged((int)numUpD_FindedBitsInPSP.Value);
        }

        private void GainNM_ValueChanged(object sender, EventArgs e)
        {
            _receiver.GainChanged((int)GainNM.Value);
        }



        private void SelectWaveFile()
        {
            if (opnDlg.ShowDialog() == DialogResult.OK)
            {
                _waveFile = opnDlg.FileName;
            }
        }


        private void StopReceiving()
        {
            _server.ReceivingStartedFlag = false;
            _receiver.StopDecoding();

            _decode.UpdateDataGui();

            try
            {
                bwImageSaver.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


            btnStartRecieve.SetPropertyThreadSafe(() => btnStartRecieve.Text, "Начать");
            //lblDemOn.SetPropertyThreadSafe(() => lblDemOn.Text, "Демодулятор выключен");
            // lblDongOn.SetPropertyThreadSafe(() => lblDongOn.Text, "Приемник выключен");

            ShowSignalSyncErr();
            ShowInterSyncErr();
            tlpReceivingParameters.SetPropertyThreadSafe(() => tlpReceivingParameters.Enabled, true);

            CountWorkingTime();
            LogFiles.WriteWorkingTimeValues(MainFcpWorkingTime, ReserveFcpWorkingTime, MainPrdWorkingTime, ReservePrdWorkingTime);
            LogFiles.WriteUserActions("Запись потока завершена");

            try
            {
                _decode.FinishDecode();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            // Чтобы при удаленной работе не выскакивало информационное окно.
            if (!Server.Server.RemoteModeFlag)
            {
                FormInformationMessageBox.Show("Сообщение", "Прием потока завершен.", Resources.done_icon, "Перейти в", "каталог с результатами", _fileName);
            }


            Settings.Default.Interliving_FindedBits = (int)numUpD_FindedBitsInInterliving.Value;
            Properties.Settings.Default.PSP_FindedBits = (int)numUpD_FindedBitsInPSP.Value;
            Properties.Settings.Default.PLL_Bandwidth = (int)numUpD_PLLBw.Value;
            Settings.Default.HardPSP = cBx_HardPSP.Checked;
            Properties.Settings.Default.Save();
        }

        #endregion

        #region gui2

        private void ChangeMode(byte modeNumber)
        {
            if (modeNumber == 0)
            {
                // Дистанционное управление
                tlp1.SetPropertyThreadSafe(() => tlp1.Enabled, false);
                Invoke(new Action(() => { slMode.Text = Resources.RemoteControlString; }));

                LogFiles.WriteUserActions(Resources.RemoteControlString);
            }
            else if (modeNumber == 1)
            {
                // Местное управление
                tlp1.SetPropertyThreadSafe(() => tlp1.Enabled, true);
                Invoke(new Action(() => { slMode.Text = Resources.LocalControlString; }));

                LogFiles.WriteUserActions(Resources.LocalControlString);
            }
        }


        private void CountWorkingTime()
        {
            DateTime finishWorkingTime = DateTime.Now;
            TimeSpan deltaWorkingTime = finishWorkingTime - _startWorkingTime;
            FullWorkingTime += deltaWorkingTime; // Общее время наработки (не используется).

            if (rbFCPMain.Checked)
            {
                MainFcpWorkingTime += deltaWorkingTime;
            }
            else
            {
                ReserveFcpWorkingTime += deltaWorkingTime;
            }

            if (rbPRDMain.Checked)
            {
                MainPrdWorkingTime += deltaWorkingTime;
            }
            else
            {
                ReservePrdWorkingTime += deltaWorkingTime;
            }
        }


        public bool[] GetSyncsStates()
        {
            bool[] syncsStatesValues = new bool[2];
            syncsStatesValues[0] = _isSignalPhaseSync;
            syncsStatesValues[1] = flags[0];

            return syncsStatesValues;
        }

        #endregion

        #region Обновление GUI.


        private void UpdateGuiDecodeData(DateTime linesDate, string linesService, string linesTd, string linesOshv, string linesBshv, string linesPcdm, DirectBitmap[] imagesLines, int delegateCallCounter)
        {
            // Набрал 6400 строчек изображения (8 * 800).
            if (delegateCallCounter == Constants.DELEGATE_CALL_COUNTER)
            {
                bwImageSaver.RunWorkerAsync();
            }

            if (InvokeRequired)
            {
                Invoke(new Action(() => GuiUpdater.UpdateGuiDecodeData(linesService, linesTd, linesOshv, linesBshv, linesPcdm, linesDate,
                    rtbDateTime, rtbMkoData, rtbServiceData, _channels, _allChannels, _channelsPanels, _allChannelsPanels, _listImagesForSave, imagesLines)));
            }
        }

        /// <summary>
        /// Обрабатывает возвращаемые значение из формы, тупой костыль в идеале переделать
        /// </summary>
        /// <param name="flags">flag[0] синхромаркер найден, flag[1] ФАПЧ захвачена</param>
        private void UpdateGuiDemodulationData(bool[] flags)
        {
            //if (flags[1]) lblIntDetect.SetPropertyThreadSafe(() => lblIntDetect.Text, "Захвачено");
            //else
            //{
            //    lblIntDetect.SetPropertyThreadSafe(() => lblIntDetect.Text, "Захват...");
            //    lblSignDetect.SetPropertyThreadSafe(() => lblSignDetect.Text, "");
            //}
            if (flags[0] && flags[1] && rbInterlivingReceiveOn.Checked)
            {
                ShowInterSyncOk();
            }
            else if (flags[0] && flags[1] && !rbInterlivingReceiveOn.Checked)
            {
                ShowInterSyncErr();       
            }

            if (_isSignalPhaseSync)
            {
                ShowSignalSyncOk();
            }
            else
            {
                ShowSignalSyncErr();
            }

        }

        #endregion

        #region  Demodulator


        private void ConfigSecretTab()
        {
            scottPlotUC1.fig.labelTitle = "File FFT Data";
            scottPlotUC1.fig.labelY = "Power ";
            scottPlotUC1.fig.labelX = "Frequency (Hz)";
            scottPlotUC1.Redraw();

            comBxModulation.SelectedItem = "Meteor-M2.2";

            lblFinded.Visible = true;

            if (rbFreq1.Checked) comBx_carrier.SelectedItem = "137.100";
            else if (rbFreq2.Checked) comBx_carrier.SelectedItem = "137.900";
            comBx_SampleRate.SelectedItem = "1024000";
        }

        public void SetupGraphLabels(int SampleRate)
        {

            scottPlotUC1.fig.AxisSet(0, SampleRate / 1000, -40, 60);
            scottPlotUC1.Redraw();
            //scottPlotUC2.fig.AxisSet(-3, 3, -3, 3);
            //scottPlotUC2.Redraw();

        }

        #endregion

        private void DemodTimer_Tick(object sender, EventArgs e)
        {
            if (_receiver != null)
            {
                _receiver.RefreshGUIfromDemod(display1, rbEYE.Checked, rbConstel.Checked, cBx_Input.Checked, cBx_output.Checked, scottPlotUC1, lblShift, lbl_PSPMode);
                // TO DO Обновление ГУИ на этот вроде бы все
                _receiver.UpdateFilterParameters(cBx_iqFilter.Checked, (int)NumUpDown_Bandwidth.Value, cBx_matchedFilter.Checked, (int)numUpD_PLLBw.Value);
                flags = _receiver.UpdateDataGui();
            }

            if (_decode != null)
            {
                _isSignalPhaseSync = _decode.IsSignalPhaseSync;
            }

            if (flags[1]) lblLocked.Visible = true;
            else lblLocked.Visible = false;

            if (flags[0]) lblFinded.Visible = true;
            else lblFinded.Visible = false;
        }

        private void btnSave_S_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                // _RecorderPath = folderBrowserDialog1.SelectedPath;
            }
        }

        private void rbFreq1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFreq1.Checked)
            {
                comBx_carrier.SelectedIndex = 0;
            }
            if (rbFreq2.Checked)
            {
                comBx_carrier.SelectedIndex = 1;
            }
        }

        private void comBx_carrier_SelectedValueChanged(object sender, EventArgs e)
        {
            double freq;
            var parsed = double.TryParse((string)comBx_carrier.SelectedItem, out freq);
            if (137.5 > freq)
            {
                rbFreq1.Checked = true;
            }

            if (137.5 < freq)
            {
                rbFreq2.Checked = true;
            }
        }

        #region Status pictures control visible

        private void ShowSignalSyncErr()
        {
            pbSignalSyncErr.SetPropertyThreadSafe(() => Visible, true);
            pbSignalSyncOk.SetPropertyThreadSafe(() => Visible, false);
        }

        private void ShowSignalSyncOk()
        {
            pbSignalSyncErr.SetPropertyThreadSafe(() => Visible, false);
            pbSignalSyncOk.SetPropertyThreadSafe(() => Visible, true);
        }

        private void ShowInterSyncErr()
        {
            pbInterSyncErr.SetPropertyThreadSafe(() => Visible, true);
            pbInterSyncOk.SetPropertyThreadSafe(() => Visible, false);
        }

        private void ShowInterSyncOk()
        {
            pbInterSyncErr.SetPropertyThreadSafe(() => Visible, false);
            pbInterSyncOk.SetPropertyThreadSafe(() => Visible, true);
        }

        #endregion
    }
}
