using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDRSharp.Radio;

namespace ReceivingStation.Demodulator
{
    public partial class FFT_Form : Form
    {
        private bool needsAutoScaling;
        private double fftPointSpacingHz;
        private double[] dfftPower;
        private double[] SamplesForConstellation_Real;
        private double[] SamplesForConstellation_Imag;

        public FFT_Form()
        {
            InitializeComponent();
            //SetupGraphLabels();
        }

        public void SetupGraphLabels(int SampleRate)
        {
            scottPlotUC1.fig.labelTitle = "File FFT Data";
            scottPlotUC1.fig.labelY = "Power ";
            scottPlotUC1.fig.labelX = "Frequency (Hz)";
            scottPlotUC1.Redraw();
            scottPlotUC1.fig.AxisSet(0, SampleRate/1000, -40, 60);

            
        }

        public void PlotData(float[] fftPower, int frameSize, uint SampleRate, Complex[] SamplesFromDemod)
        {
            int graphPointCount = frameSize;

            SamplesForConstellation_Real = new double[SamplesFromDemod.Length];
            SamplesForConstellation_Imag = new double[SamplesFromDemod.Length];

            fftPointSpacingHz = SampleRate / graphPointCount;

            if (SampleRate == 1024000) fftPointSpacingHz = fftPointSpacingHz / 16;
            if (SampleRate == 1400000) fftPointSpacingHz = fftPointSpacingHz / 30;
            if (SampleRate == 1920000) fftPointSpacingHz = fftPointSpacingHz / 28;
            if (SampleRate == 8000000) fftPointSpacingHz = fftPointSpacingHz / 480;
            dfftPower = new double[fftPower.Length];
            for (int i = 0; i < fftPower.Length; i++)
            {
                dfftPower[i] = (double)fftPower[i];
            }

            for (int i = 0; i < SamplesFromDemod.Length ; i++)
            {
                SamplesForConstellation_Real[i] = 4*SamplesFromDemod[i].Real;
                SamplesForConstellation_Imag[i] = 4*SamplesFromDemod[i].Imag;
            }
            //scottPlotUC1.Clear();
            //scottPlotUC1.PlotSignal(dfftPower, fftPointSpacingHz / 4, Color.Blue);
         
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            if (dfftPower != null && SamplesForConstellation_Imag != null)
            {
                scottPlotUC1.Clear();
                scottPlotUC1.PlotSignal(dfftPower, fftPointSpacingHz, Color.Black);
                scottPlotUC1.SizeUpdate();

            }
            //if (needsAutoScaling)
            //{
            //    scottPlotUC1.AxisAuto();
            //    needsAutoScaling = false;
            //}
            timer1.Enabled = true;
        }

        private void FFT_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
