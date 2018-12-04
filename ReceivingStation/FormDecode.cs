using MaterialSkin.Controls;
using ReceivingStation.Other;
using ReceivingStation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private long _imageCounter;

        private string[] _td = new string[4];
        private string[] _oshv = new string[2];
        private string[] _bshv = new string[10];
        private string[] _pcdm = new string[14];
        private DirectBitmap[] _images = new DirectBitmap[6];

        private Decode decode;

        private Panel[] _allChannelsPanels = new Panel[6];
        private Panel[] _channelsPanels = new Panel[6];
        private FlowLayoutPanel[] _channels = new FlowLayoutPanel[6];
        private FlowLayoutPanel[] _allChannels = new FlowLayoutPanel[6];
        private List<Bitmap>[] _listImagesForSave = new List<Bitmap>[6];

        private DateTime _lineDate; // Время пришедшей полосы.

        private DateTime _worktimestart; // Сколько времени ушло на декодирование (потом удалить).

        public FormDecode()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void FormDecode_Load(object sender, EventArgs e)
        {
            GuiUpdater.SmoothLoadingForm(this);
            GuiUpdater.LoadFont();

            RichTextBoxInit();

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

            for (int i = 0; i < 6; i++)
            {
                _allChannels[i] = GuiUpdater.GetFlp($"flpAllChannels{i}", new Size(242, 8));
                _channels[i] = GuiUpdater.GetFlp($"flpChannel{i}", new Size(1556, 40));
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
            Parallel.For(0, _listImagesForSave.Length, SaveImage);
            _imageCounter += 1;
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

                    _cancellationTokenSource = new CancellationTokenSource();
                    _cancellationToken = _cancellationTokenSource.Token;
                    _isDecodeStarting = true;
                    btnStartStopDecode.Text = "Остановить";

                    decode = new Decode(this, _fileName, reedSoloFlag, nrzFlag)
                    {
                        ThreadSafeUpdateDateTime = UpdateDateTime,
                        ThreadSafeUpdateMko = UpdateMko,
                        ThreadSafeUpdateImagesContent = UpdateChannelsImages,
                        ThreadSafeUpdateGui = UpdateGui,
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
                    WriteToLogUserActions($"Начата расшифровка файла - {_fileName}");

                    await Task.Run(() => decode.StartDecode(_cancellationToken));

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

        #region Обновление даты и времени при декодировании.
        private void UpdateDateTime(DateTime date)
        {
            _lineDate = date;
        }

        #endregion

        #region Обновление изображений при декодировании.
        private void UpdateChannelsImages(DirectBitmap[] images)
        {
            _images = images;

            _callingUpdateImageCounter++;

            // Набрал 480 строчек изображения (8 * 60).
            if (_callingUpdateImageCounter == 60)
            {
                bwImageSaver.RunWorkerAsync();
                _callingUpdateImageCounter = 0;
            }
        }

        #endregion

        #region Обновление МКО при декодировании.

        private void UpdateMko(string tdd, string oshvv, string bshvv, string pcdmm)
        {
            _td = tdd.Split(' ');
            _oshv = oshvv.Split(' ');
            _bshv = bshvv.Split(' ');
            _pcdm = pcdmm.Split(' ');
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

                bmp.Save($"{Path.GetDirectoryName(_fileName)}\\{Path.GetFileNameWithoutExtension(_fileName)}_Channel_{i + 1}\\{Path.GetFileNameWithoutExtension(_fileName)}_{i + 1}_{_imageCounter}.bmp");
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

        #region Обновление GUI.
        private void UpdateGui()
        {
            // Собираем данные в richTextBox. Стремновато, но так быстрее. Если использовать 15 лейблов, то время декодирования увеличится где то на 20%.
            var mkoData = $"{_td[0]} {_td[1]}\n\n{_td[2]}\n\n{_td[3]}\n\n{_oshv[0]} {_oshv[1]}\n\n{_bshv[0]} {_bshv[1]}\n\n{_bshv[2]} {_bshv[3]}\n\n{_bshv[4]} {_bshv[5]}\n\n{_bshv[6]} {_bshv[7]}\n\n{_bshv[8]} {_bshv[9]}\n\n{_pcdm[0]} {_pcdm[1]}\n\n{_pcdm[2]} {_pcdm[3]} {_pcdm[4]} {_pcdm[5]}\n\n{_pcdm[6]} {_pcdm[7]} {_pcdm[8]} {_pcdm[9]}\n\n{_pcdm[10]} {_pcdm[11]} {_pcdm[12]} {_pcdm[13]}";
            var date = $"{_lineDate.Day}/{_lineDate.Month}/{_lineDate.Year}";
            var time = $"{_lineDate.Hour.ToString("D2")}:{_lineDate.Minute.ToString("D2")}:{_lineDate.Second.ToString("D2")}";
            var dateTime = $"\n{date}\n\n{time}";

            rtbDateTime.SetPropertyThreadSafe(() => rtbDateTime.Text, dateTime);        
            rtbMkoData.SetPropertyThreadSafe(() => rtbMkoData.Text, mkoData);

            // Изображение.
            _allChannelsPanels[5].Invoke(new Action(() => { GuiUpdater.CreateNewFlps(_channels, _allChannels, _channelsPanels, _allChannelsPanels); }));
            _allChannels[5].Invoke(new Action(() => { GuiUpdater.AddImages(_channels, _allChannels, _listImagesForSave, _images); }));
        }

        #endregion

        #region Инициализация кастомного richTextBox.
        private void RichTextBoxInit()
        {
            GuiUpdater.AllocFont(GuiUpdater.font, rtbMko, 11);
            GuiUpdater.AllocFont(GuiUpdater.font, rtbMkoData, 11);
            GuiUpdater.AllocFont(GuiUpdater.font, rtbDateTimeTitle, 11);
            GuiUpdater.AllocFont(GuiUpdater.font, rtbDateTime, 11);

            var MkoTitle = "Время конца формирования ТД (БШВ)\n\n" +
                "Первый год в текущем четырехлетии\n\n" +
                "Номер текущих суток четырехлетия\n\n" +
                "Оцифрованная бортовая шкала времени (БШВ)\n\n" +
                "Время конца формирования ППО (БШВ)\n\n" +
                "Параметры кватерниона L0\n\n" +
                "Параметры кватерниона L1\n\n" +
                "Параметры кватерниона L2\n\n" +
                "Параметры кватерниона L3\n\n" +
                "Время конца формирования ПЦДМ (БШВ)\n\n" +
                "Положение КА по оси X в формате IEEE-754 двойной\n\n" +
                "Положение КА по оси Y в формате IEEE-754 двойной\n\n" +
                "Положение КА по оси Z в формате IEEE-754 двойной";
            rtbMko.Text = MkoTitle;
            rtbMko.BorderStyle = BorderStyle.None;

            var mkoData = "0\n\n0\n\n0\n\n0\n\n0\n\n0\n\n0\n\n0\n\n0\n\n0\n\n0\n\n0\n\n0";
            rtbMkoData.Text = mkoData;
            rtbMkoData.BorderStyle = BorderStyle.None;

            var dateTimeTitle = "\nДата\n\nВремя";
            rtbDateTimeTitle.Text = dateTimeTitle;
            rtbDateTimeTitle.BorderStyle = BorderStyle.None;

            var dateTime = "\n0/0/0\n\n0:0:0";
            rtbDateTime.Text = dateTime;
            rtbDateTime.BorderStyle = BorderStyle.None;
        }

        #endregion
    }
}
