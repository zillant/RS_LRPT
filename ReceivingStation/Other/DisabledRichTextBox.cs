﻿namespace ReceivingStation.Other
{
    class DisabledRichTextBox : System.Windows.Forms.RichTextBox
    {
        private const int WM_SETFOCUS = 0x07;
        private const int WM_ENABLE = 0x0A;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private const int WM_SETCURSOR = 0x20;

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (!(m.Msg == WM_SETFOCUS || m.Msg == WM_ENABLE || m.Msg == WM_SETCURSOR))
                base.WndProc(ref m);
        }
    }
}
