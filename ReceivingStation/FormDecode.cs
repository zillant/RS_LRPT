using MaterialSkin.Controls;
using ReceivingStation.Other;
using ReceivingStation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReceivingStation.MessageBoxes;

namespace ReceivingStation
{
    public partial class FormDecode : MaterialForm
    {
        private string _fileName;
        private bool _isDecodeStarting;
        private bool _isFileOpened;

        private bool _isDecodeTimeVisible; // Для скрытия времени декодирования.

        private int _callingUpdateImageCounter; // Сколько раз был вызван метод UpdateGui. Нужно для сохранения изображений на диск.
        private long _imageCounter; // Счетчик сохранненых изображений.
      
        private Decode _decode;

        private Panel[] _allChannelsPanels = new Panel[6]; // Панели на которых находятся FLP для всех каналов.
        private Panel[] _channelsPanels = new Panel[6]; // Панели на которых находятся FLP для каждого канала.
        private FlowLayoutPanel[] _channels = new FlowLayoutPanel[6]; // FLP для хранения полосок изображения для каждого канала.
        private FlowLayoutPanel[] _allChannels = new FlowLayoutPanel[6]; // FLP для хранения полосок изображения для всех каналов.
        private List<Bitmap>[] _listImagesForSave = new List<Bitmap>[6]; // Список для хранения полосок изображения, нужно для сохранения.
      
        private DateTime _worktimestart; // Сколько времени ушло на декодирование (потом удалить).

        public FormDecode()
        {
            InitializeComponent();
        }

        private void FormDecode_Load(object sender, EventArgs e)
        {
            GuiUpdater.SmoothLoadingForm(this);

            GuiUpdater.DecodeRichTextBoxInit(rtbMkoTitle, rtbMkoData, rtbDateTimeTitle, rtbDateTime);

            materialTabControl1.SelectedTab = tabPage14;

            _isDecodeStarting = false;
            _isFileOpened = false;
            _isDecodeTimeVisible = false;

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

            for (int i = 0; i < 6; i++)
            {
                _allChannels[i] = GuiUpdater.GetFlp(new Size(242, 8));
                _channels[i] = GuiUpdater.GetFlp(new Size(1556, 40));
                _allChannelsPanels[i].Controls.Add(_allChannels[i]);
                _channelsPanels[i].Controls.Add(_channels[i]);
                _listImagesForSave[i] = new List<Bitmap>();
            }

            slTime.Text = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            timer1.Start();
        }     

        private void FormDecode_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = FormDialogMessageBox.Show("Выход", "Вы уверены, что хотите закрыть программу?", Resources.door_exit_icon);

            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void FormDecode_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnStartStopDecode_Click(object sender, EventArgs e)
        {
            StartStopDecoding();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Title = "Выбор файла телеметрии";
                openFileDialog1.Filter = "Telemetry files (*.dat)|*.dat";
                openFileDialog1.FilterIndex = 1;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    _fileName = openFileDialog1.FileName;
                    lblFileName.Text = openFileDialog1.SafeFileName;
                    _isFileOpened = true;
                    lblFileName.ForeColor = Color.FromArgb(222, 0, 0, 0);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            slTime.Text = DateTime.Now.ToString(CultureInfo.CurrentCulture);
        }

        private void bwImageSaver_DoWork(object sender, DoWorkEventArgs e)
        {
            ImageSaver.SaveImage(_listImagesForSave, _fileName, _imageCounter);
            _imageCounter += 1;
        }

        private void FormDecode_KeyDown(object sender, KeyEventArgs e)
        {
            // Ctrl + L  
            if (e.Control && e.KeyCode == Keys.L)
            {
                if (!_isDecodeTimeVisible)
                {
                    slDecodeTime.Visible = true;
                    _isDecodeTimeVisible = true;
                }
                else
                {
                    slDecodeTime.Visible = false;
                    _isDecodeTimeVisible = false;
                }

                e.SuppressKeyPress = true;
            }
        }

        #region Начать декодирование.
        private async void StartStopDecoding()
        {
            if (_isFileOpened)
            {
                if (!_isDecodeStarting)
                {
                    bool reedSoloFlag = rbRSYes.Checked;
                    bool nrzFlag = rbNRZYes.Checked;
                    _imageCounter = 0;
                    _callingUpdateImageCounter = 0;

                    _isDecodeStarting = true;
                    btnStartStopDecode.Text = "Остановить";

                    _decode = new Decode(_fileName, reedSoloFlag, nrzFlag)
                    {
                        ThreadSafeUpdateGui = UpdateGuiDecodeData
                    };

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

                    tlpDecodingParameters.Enabled = false;

                    _worktimestart = DateTime.Now;
                    UserLog.WriteToLogUserActions($"Начата расшифровка файла - {_fileName}");

                    await Task.Run(() => _decode.StartDecode());
                    StopDecoding();

                }
                else
                {
                    ForcedStopDecoding();
                }
            }
            else
            {
                lblFileName.ForeColor = GuiUpdater.ErrorColor;
            }
        }

        #endregion

        #region Принудительная остановка декодирования.
        private void ForcedStopDecoding()
        {
            _decode.stopDecoding = true;
        }

        #endregion

        #region Остановка декодирования.
        private void StopDecoding()
        {
            bwImageSaver.RunWorkerAsync();

            _isDecodeStarting = false;

            btnStartStopDecode.Text = "Начать";
            tlpDecodingParameters.Enabled = true;

            DateTime worktimefinish = DateTime.Now;
            TimeSpan deltaWorkingTime = worktimefinish - _worktimestart;

            slDecodeTime.Text = deltaWorkingTime.ToString();

            UserLog.WriteToLogUserActions($"Завершена расшифровка файла - {_fileName}");
        }

        #endregion

        #region Обновление данных декодирования на GUI.
        private void UpdateGuiDecodeData(DateTime linesDate, string linesTd, string linesOshv, string linesBshv, string linesPcdm, DirectBitmap[] imagesLines)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => GuiUpdater.UpdateGuiDecodeData(linesTd, linesOshv, linesBshv, linesPcdm,
                    linesDate, rtbDateTime, rtbMkoData, _channels, _allChannels, _channelsPanels, _allChannelsPanels,
                    _listImagesForSave, imagesLines)));
            }
            else
            {
                GuiUpdater.UpdateGuiDecodeData(linesTd, linesOshv, linesBshv, linesPcdm,
                    linesDate, rtbDateTime, rtbMkoData, _channels, _allChannels, _channelsPanels, _allChannelsPanels,
                    _listImagesForSave, imagesLines);
            }

            _callingUpdateImageCounter++;

            // Набрал 480 строчек изображения (8 * 60).
            if (_callingUpdateImageCounter == 60)
            {
                bwImageSaver.RunWorkerAsync();
                _callingUpdateImageCounter = 0;
            }
        }

        #endregion
    }
}
