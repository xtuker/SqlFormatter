namespace SqlFormatter
{
    using System;
    using System.Windows.Forms;

    public class MyTextBox : TextBox
    {
        public event EventHandler TextPasted = (sender, args) => { };

        private const int WM_PASTE = 0x0302;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_PASTE)
            {
                this.TextPasted(this, EventArgs.Empty);
            }
        }
    }
}