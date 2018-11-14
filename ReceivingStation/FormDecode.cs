using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReceivingStation.Other;
using System.Text;
using ReceivingStation.Decode;
using System.Collections.Generic;
using System.ComponentModel;
using ReceivingStation.Properties;

namespace ReceivingStation
{
    public partial class FormDecode : Form
    {
        private GuiUpdater guiUpdater;

        private string _fileName;
        private bool _isDecodeStarting;        

        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
        
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
            tabControl1.SelectedTab = tabPage7;

            _isDecodeStarting = false;

            guiUpdater = new GuiUpdater();

            for (int i = 0; i < 6; i++)
            {
                _listImagesForSave[i] = new List<Bitmap>();
            }

            _channels[0] = flpChannel1;
            _channels[1] = flpChannel2;
            _channels[2] = flpChannel3;
            _channels[3] = flpChannel4;
            _channels[4] = flpChannel5;
            _channels[5] = flpChannel6;

            _allChannels[0] = flpAllChannels1;
            _allChannels[1] = flpAllChannels2;
            _allChannels[2] = flpAllChannels3;
            _allChannels[3] = flpAllChannels4;
            _allChannels[4] = flpAllChannels5;
            _allChannels[5] = flpAllChannels6;

            slTime.Text = DateTime.Now.ToString();
            timer1.Start();
        }

        private void FormDecode_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Точно выйти?", "Внимание",
                          MessageBoxButtons.YesNo,
                          MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void FormDecode_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Close();           
        }

        private void tsmiFileOpen_Click(object sender, EventArgs e)
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

                    btnStartStopDecode.Enabled = true;
                    tsmiStartDecoding.Enabled = true;
                }                
            }          
        }

        private void tsmiStartDecoding_Click(object sender, EventArgs e)
        {
            StartStopDecoding();
        }

        private void tsmiStopDecoding_Click(object sender, EventArgs e)
        {
            ForcedStopDecoding();           
        }

        private void btnStartStopDecode_Click(object sender, EventArgs e)
        {
            StartStopDecoding();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            slTime.Text = DateTime.Now.ToString();
        }

        private void bwImageSaver_DoWork(object sender, DoWorkEventArgs e)
        {
            Parallel.For(0, _listImagesForSave.Length, i =>
            {
                using (Bitmap bmp = new Bitmap(Constants.WDT, _listImagesForSave[i].Count * Constants.HGT))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        int yOffset = 0;

                        for (int j = 0; j < _listImagesForSave[i].Count; j++)
                        {
                            g.DrawImage(_listImagesForSave[i][j], new Rectangle(0, yOffset, Constants.WDT, Constants.HGT));
                            yOffset += Constants.HGT;
                        }
                    }

                    bmp.Save($"{Path.GetDirectoryName(_fileName)}\\{Path.GetFileNameWithoutExtension(_fileName)}_{i}.bmp");
                }
            });
        }

        #region Начать декодирование.
        private void StartStopDecoding()
        {
            if (!_isDecodeStarting)
            {
                bool reedSoloFlag = rbRSYes.Checked;
                bool nrzFlag = rbNRZYes.Checked;

                _cancellationTokenSource = new CancellationTokenSource();
                _cancellationToken = _cancellationTokenSource.Token;
                _isDecodeStarting = true;
                btnStartStopDecode.BackgroundImage = Resources.stop_icon;

                var decode = new Decode.Decode(this, _fileName, reedSoloFlag, nrzFlag)
                {
                    ThreadSafeUpdateFrameCounterValue = UpdateFrameCounterValue,
                    ThreadSafeUpdateImagesContent = AddImages,
                    ThreadSafeStopDecoding = StopDecoding
                };

                for (int i = 0; i < 6; i++)
                {
                    _allChannels[i].Controls.Clear();
                    _channels[i].Controls.Clear();
                    _listImagesForSave[i].Clear();
                }

                tsmiStartDecoding.Enabled = false;
                tsmiStopDecoding.Enabled = true;
                gbDecodeParameters.Enabled = false;

                _worktimestart = DateTime.Now;
                Task.Run(() => decode.StartDecode(_cancellationToken));
                WriteToLogUserActions($"Начата расшифровка файла - {_fileName}");
            }
            else
            {
                ForcedStopDecoding();
            }          
        }

        #endregion

        #region Обновление счетчика кадров при декодировании.
        private void UpdateFrameCounterValue(uint counter)
        {
            guiUpdater.UpdateFrameCounterValue(lblFramesCounter, counter);        
        }

        #endregion

        #region Добавление полученных изображений при декодировании.
        private void AddImages(DirectBitmap[] images)
        {
            guiUpdater.AddImages(_channels, _allChannels, _listImagesForSave, images);

            bwImageSaver.RunWorkerAsync();
        }

        #endregion

        #region Остановка декодирования.
        private void StopDecoding()
        {
            _isDecodeStarting = false;
            btnStartStopDecode.BackgroundImage = Resources.start_icon;

            tsmiStartDecoding.Enabled = true;
            tsmiStopDecoding.Enabled = false;
            gbDecodeParameters.Enabled = true;

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
    }
}
