using SDRSharp.Radio;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;


namespace ReceivingStation.Demodulator
{
    public unsafe partial class Display : UserControl
    {
        private Bitmap _buffer;
        private Graphics _graphics;
        private bool _input;
        private bool _output;

        public bool Input
        {
            get { return _input; }
            set { _input = value; }
        }

        public bool Output
        {
            get { return _output; }
            set { _output = value; }
        }

        public bool Eye { get; set; }

        public bool Constellation { get; set; }

        public int Gain { get; set; }

        public int Zoom { get; set; }

        public bool Pause { get; set; }

        public int SamplesPerSymbol { get; set; }


        public Display()
        {
            InitializeComponent();

            _buffer = new Bitmap(ClientRectangle.Width, ClientRectangle.Height, PixelFormat.Format32bppArgb);
            _graphics = Graphics.FromImage(_buffer);

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            Gain = 1;
            Zoom = 1;
        }

        public void Perform(Complex* displayInputBuffer, Complex* displayOutputBuffer, int length)
        {
            if (displayInputBuffer == null || displayOutputBuffer == null || Pause) return;

            var graphics = _graphics;
            var graphicsRect = ClientRectangle;

            var xCenter = (int)(graphicsRect.Width * 0.5f);
            var yCenter = (int)(graphicsRect.Height * 0.5f);

            var gain = yCenter * Gain;
            var showLength = length;
            graphics.Clear(Color.WhiteSmoke);

            using (var spectrumPen = new Pen(Color.FromArgb(150, Color.Black), 1.0f))
            using (var linePen = new Pen(Color.FromArgb(150, Color.Red), 1.0f))
            using (var gridPen = new Pen(Color.Gray))
            {
                if (Constellation)
                {
                    if (_input)
                    {
                        Point[] points = new Point[showLength];

                        for (int i = 0; i < showLength; i++)
                        {
                            var newX = (int)(xCenter + (displayInputBuffer[i].Real * gain));
                            var newY = (int)(yCenter + (displayInputBuffer[i].Imag * gain));
                            if (newX > graphicsRect.Width) newX = graphicsRect.Width;
                            else if (newX < 0) newX = 0;
                            if (newY > graphicsRect.Height) newY = graphicsRect.Height;
                            else if (newY < 0) newY = 0;

                            points[i].X = newX;
                            points[i].Y = newY;
                        }
                        graphics.DrawLines(spectrumPen, points);
                    }

                    if (_output)
                    {
                        for (int i = 0; i < showLength; i++)
                        {
                            var newPoint = new Point((int)(xCenter + (displayOutputBuffer[i].Real * gain)), (int)(yCenter + (displayOutputBuffer[i].Imag * gain)));
                            if (graphicsRect.Contains(newPoint)) _buffer.SetPixel(newPoint.X, newPoint.Y, Color.Black);
                        }
                    }
                    graphics.DrawLine(gridPen, xCenter, 0, xCenter, graphicsRect.Height);

                }
                else if (Eye)
                {
                    var eyeLength = SamplesPerSymbol * 2;
                    Point[] points = new Point[eyeLength];
                    var step = graphicsRect.Width / (eyeLength - 1);

                    if (_input)
                    {
                        for (int i = 0; i < showLength; i++)
                        {
                            if (displayOutputBuffer[i].Imag == 0) continue;

                            for (var j = 0; j < eyeLength && i < showLength; j++)
                            {
                                var newX = j * step;
                                var newY = (int)(yCenter + (displayInputBuffer[i].Real * gain));
                                if (newX > graphicsRect.Width) newX = graphicsRect.Width;
                                else if (newX < 0) newX = 0;
                                if (newY > graphicsRect.Height) newY = graphicsRect.Height;
                                else if (newY < 0) newY = 0;

                                points[j].X = newX;
                                points[j].Y = newY;

                                i++;
                            }

                            graphics.DrawLines(linePen, points);
                        }
                    }
                    if (_output)
                    {
                        for (int i = 0; i < showLength; i++)
                        {
                            if (displayOutputBuffer[i].Imag == 0) continue;

                            for (var j = 0; j < eyeLength && i < showLength; j++)
                            {
                                var newX = j * step;
                                var newY = (int)(yCenter + (displayInputBuffer[i].Imag * gain));
                                if (newX > graphicsRect.Width) newX = graphicsRect.Width;
                                else if (newX < 0) newX = 0;
                                if (newY > graphicsRect.Height) newY = graphicsRect.Height;
                                else if (newY < 0) newY = 0;

                                points[j].X = newX;
                                points[j].Y = newY;

                                i++;
                            }
                            graphics.DrawLines(spectrumPen, points);
                        }
                    }
                }
       
                graphics.DrawLine(gridPen, 0, yCenter, graphicsRect.Width, yCenter);
            }
        }

        public static void ConfigureGraphics(Graphics graphics)
        {
            graphics.CompositingMode = CompositingMode.SourceOver;
            graphics.CompositingQuality = CompositingQuality.HighSpeed;
            graphics.SmoothingMode = SmoothingMode.None;
            graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            graphics.InterpolationMode = InterpolationMode.Low;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ConfigureGraphics(e.Graphics);
            e.Graphics.DrawImageUnscaled(_buffer, 0, 0);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (ClientRectangle.Width > 0 && ClientRectangle.Height > 0)
            {
                _buffer.Dispose();
                _graphics.Dispose();
                _buffer = new Bitmap(ClientRectangle.Width, ClientRectangle.Height, PixelFormat.Format32bppArgb);
                _graphics = Graphics.FromImage(_buffer);
            }
        }
    }
}
