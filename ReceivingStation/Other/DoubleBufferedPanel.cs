using System.Windows.Forms;

namespace ReceivingStation.Other
{
    class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            DoubleBuffered = true;
        }
    }
}
