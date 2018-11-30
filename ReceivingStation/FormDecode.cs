using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReceivingStation.Other;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using MaterialSkin.Controls;
using ReceivingStation.Properties;

namespace ReceivingStation
{
    public partial class FormDecode : MaterialForm
    {
        private string _fileName;
        private bool _isDecodeStarting;
        private bool _isFileOpened;
        private int _callingUpdateImageCounter;

        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;

        private long _frameCounter;


        private  MaterialLabel[] mkoDataLabels = new MaterialLabel[13];
        private Panel[] _allChannelsPanels = new Panel[6];
        private Panel[] _channelsPanels = new Panel[6];
        private FlowLayoutPanel[] _channels = new FlowLayoutPanel[6];
        private FlowLayoutPanel[] _allChannels = new FlowLayoutPanel[6];

        private List<Bitmap>[] _listImagesForSave = new List<Bitmap>[6];

        private DateTime _worktimestart; // Сколько времени ушло на декодирование (потом удалить).

        public FormDecode()
        {
            InitializeComponent();            
        }

        private void FormDecode_Load(object sender, EventArgs e)
        {
            GuiUpdater.SmoothLoadingForm(this);

            materialTabControl1.SelectedTab = tabPage14;

            _isDecodeStarting = false;
            _isFileOpened = false;

            _allChannelsPanels[0] = panel7;
            _allChannelsPanels[1] = panel8;
            _allChannelsPanels[2] = panel9;
            _allChannelsPanels[3] = panel10;
            _allChannelsPanels[4] = panel11;
            _allChannelsPanels[5] = panel12;

            _channelsPanels[0] = pScroll1;
            _channelsPanels[1] = pScroll2;
            _channelsPanels[2] = pScroll3;
            _channelsPanels[3] = pScroll4;
            _channelsPanels[4] = pScroll5;
            _channelsPanels[5] = pScroll6;

            mkoDataLabels[0] = materialLabel12;
            mkoDataLabels[1] = materialLabel14;
            mkoDataLabels[2] = materialLabel16;
            mkoDataLabels[3] = materialLabel18;
            mkoDataLabels[4] = materialLabel20;
            mkoDataLabels[5] = materialLabel22;
            mkoDataLabels[6] = materialLabel24;
            mkoDataLabels[7] = materialLabel26;
            mkoDataLabels[8] = materialLabel31;
            mkoDataLabels[9] = materialLabel30;
            mkoDataLabels[10] = materialLabel27;
            mkoDataLabels[11] = materialLabel36;
            mkoDataLabels[12] = materialLabel33;


            for (int i = 0; i < 6; i++)
            {
                _allChannels[i] = GetFlp($"flpAllChannels{i}", new Size(242, 8));
                _channels[i] = GetFlp($"flpChannel{i}", new Size(1556, 40));
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
            Parallel.For(0, _listImagesForSave.Length, i => { SaveImage(i); });
            _frameCounter += 1;
        }       

        #region Начать декодирование.
        private void StartStopDecoding()
        {
            if (_isFileOpened)
            {
                if (!_isDecodeStarting)
                {
                    bool reedSoloFlag = rbRSYes.Checked;
                    bool nrzFlag = rbNRZYes.Checked;
                    _frameCounter = 0;
                    _callingUpdateImageCounter = 0;

                    _cancellationTokenSource = new CancellationTokenSource();
                    _cancellationToken = _cancellationTokenSource.Token;
                    _isDecodeStarting = true;
                    btnStartStopDecode.Text = "Остановить";

                    var decode = new Decode(this, _fileName, reedSoloFlag, nrzFlag)
                    {
                        ThreadSafeUpdateFrameCounterValue = UpdateFrameCounterValue,
                        ThreadSafeUpdateMko = UpdateMko,
                        ThreadSafeUpdateImagesContent = UpdateChannelsImages,
                        ThreadSafeStopDecoding = StopDecoding
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
                    Task.Run(() => decode.StartDecode(_cancellationToken));
                    WriteToLogUserActions($"Начата расшифровка файла - {_fileName}");
                }
                else
                {
                    ForcedStopDecoding();
                }
            }
            else
            {
                lblFileName.ForeColor = Color.FromArgb(222, 211, 47, 47);              
            }
        }

        #endregion

        #region Обновление счетчика кадров при декодировании.
        private void UpdateFrameCounterValue(uint counter)
        {
            if (lblFramesCounter.InvokeRequired)
                lblFramesCounter.Invoke((Action)(() => { GuiUpdater.SetLabelText(lblFramesCounter, counter.ToString()); }));
            else
                GuiUpdater.SetLabelText(lblFramesCounter, counter.ToString());
        }

        #endregion

        #region Обновление изображений при декодировании.
        private void UpdateChannelsImages(DirectBitmap[] images)
        {
            _callingUpdateImageCounter++;

            if (_allChannels[0].Height >= _allChannelsPanels[0].Height)
            {
                for (int i = 0; i < 6; i++)
                {
                    _allChannels[i].Dispose();
                    _allChannels[i] = GetFlp($"flpAllChannels{i}", new Size(242, 8));
                    _allChannelsPanels[i].Controls.Add(_allChannels[i]);

                    _channels[i].Dispose();
                    _channels[i] = GetFlp($"flpChannel{i}", new Size(1556, 40));
                    _channelsPanels[i].Controls.Add(_channels[i]);                              
                }                             
            }

            // Набрал 480 строчек изображения (8 * 60).
            if (_callingUpdateImageCounter == 60)
            {
                bwImageSaver.RunWorkerAsync();
                _callingUpdateImageCounter = 0;
            }
            

            if (_channelsPanels[0].InvokeRequired & _allChannelsPanels[0].InvokeRequired)
                Invoke((Action)(() => { GuiUpdater.AddImages(_channels, _allChannels, _listImagesForSave, images); }));
            else
                GuiUpdater.AddImages(_channels, _allChannels, _listImagesForSave, images);
        }

        #endregion

        #region Обновление МКО при декодировании.
        private void UpdateMko(string td, string oshv, string bshv, string pdcm)
        {
            if (tableLayoutPanel4.InvokeRequired)
                tableLayoutPanel4.Invoke((Action)(() => { GuiUpdater.UpdateMko(mkoDataLabels, td, oshv, bshv, pdcm); }));
            else
                GuiUpdater.UpdateMko(mkoDataLabels, td, oshv, bshv, pdcm);
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

            WriteToLogUserActions($"Завершена расшифровка файла - {_fileName}");         
        }

        #endregion

        #region Принудительная остановка декодирования.
        private void ForcedStopDecoding()
        {
            _cancellationTokenSource.Cancel();
        }

        #endregion
     
        #region Запись в лог файл действий пользователя.
        private void WriteToLogUserActions(string logMessage)
        {
            using (StreamWriter sw = new StreamWriter("log.txt", true, Encoding.UTF8, 65536))
            {
                sw.WriteLine($"{DateTime.Now} - {logMessage}");
            }
        }

        #endregion

        #region Создание контейнера для изображений.
        private FlowLayoutPanel GetFlp(string name, Size size)
        {
            FlowLayoutPanel flp = new FlowLayoutPanel
            {
                Name = name,
                FlowDirection = FlowDirection.TopDown,
                Size = size,
                AutoSize = true,
                Location = new Point(0, 0)
            };

            return flp;
        }

        #endregion

        #region Сохранение изображений.
        private void SaveImage(int i)
        {

            List<Bitmap> listImages = new List<Bitmap>(_listImagesForSave[i]);
            _listImagesForSave[i].Clear();

            using (Bitmap bmp = new Bitmap(Constants.WDT, listImages.Count * Constants.HGT))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    int yOffset = 0;

                    for (int j = 0; j < listImages.Count; j++)
                    {
                        g.DrawImage(listImages[j], new Rectangle(0, yOffset, Constants.WDT, Constants.HGT));
                        yOffset += Constants.HGT;
                    }
                }

                bmp.Save($"{Path.GetDirectoryName(_fileName)}\\{Path.GetFileNameWithoutExtension(_fileName)}_Channel_{i + 1}\\{Path.GetFileNameWithoutExtension(_fileName)}_{i + 1}_{_frameCounter}.bmp");
            }
        }

        #endregion

        #region Создание полного изображения (Работает на маленьких изображениях, создать картинку 15ХХ х Over9000 конечно не получится).
        private void CreateFullImage(int i)
        {
            DirectoryInfo di = new DirectoryInfo($"{Path.GetDirectoryName(_fileName)}\\{Path.GetFileNameWithoutExtension(_fileName)}_Channel_{i + 1}");
            List<Bitmap> images = new List<Bitmap>();

            foreach (FileInfo file in di.GetFiles())
            {
                images.Add(new Bitmap(file.FullName));
            }

            using (Bitmap bmp = new Bitmap(Constants.WDT, images.Count * 960))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    int yOffset = 0;

                    for (int j = 0; j < images.Count; j++)
                    {
                        g.DrawImage(images[j], new Rectangle(0, yOffset, Constants.WDT, images[j].Height));
                        yOffset += images[j].Height;
                    }
                }

                bmp.Save($"{Path.GetDirectoryName(_fileName)}\\{Path.GetFileNameWithoutExtension(_fileName)}_{i + 1}.bmp");
            }
        }


        #endregion
    }
}
