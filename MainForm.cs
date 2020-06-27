namespace SqlFormatter
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        private readonly Formatter formatter = new Formatter();

        public MainForm()
        {
            this.InitializeComponent();
            this.formatter.ReadConfig();

            this.IsBeautify.Checked = this.formatter.IsBeautify;
            this.UseClipboard.Checked = this.formatter.UseClipboard;

            this.formatter.InitProgressBar += this.Formatter_InitProgressBar;
            this.formatter.IncrementProgressBar += this.Formatter_IncrementProgressBar;
        }

        private void Formatter_IncrementProgressBar(object sender, EventArgs e)
        {
            this.IncrementProgressBar();
        }

        private void Formatter_InitProgressBar(object sender, EventArgs e)
        {
            this.InitProgressBar((int) sender);
        }

        private async Task Convert()
        {
            var sw = Stopwatch.StartNew();
            var text = await this.formatter.Convert(this.InputArea.Text);
            sw.Stop();

            this.SetOutput(text);

            this.HideProgressBar();

            this.Elapsed($"Elapsed: {sw.Elapsed}");
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await this.Convert();
        }

        private async void IsBeautify_CheckedChanged(object sender, EventArgs e)
        {
            await this.Convert();
        }

        private void SetOutput(string text)
        {
            if (this.progressBar.InvokeRequired)
            {
                this.progressBar.Invoke(new MethodInvoker(() => this.SetOutput(text)));
            }
            else
            {
                this.OutputArea.Text = text;
            }
        }

        private void Elapsed(string time)
        {
            if (this.ElapsedTime.InvokeRequired)
            {
                this.ElapsedTime.Invoke(new MethodInvoker(() => this.Elapsed(time)));
            }
            else
            {
                this.ElapsedTime.Text = time;
            }
        }

        private void InitProgressBar(int count)
        {
            if (this.progressBar.InvokeRequired)
            {
                this.progressBar.Invoke(new MethodInvoker(() => this.InitProgressBar(count)));
            }
            else
            {
                this.progressBar.Visible = true;
                this.progressBar.Minimum = 0;
                this.progressBar.Maximum = count;
                this.progressBar.Value = 0;
            }
        }

        private void IncrementProgressBar()
        {
            if (this.progressBar.InvokeRequired)
            {
                this.progressBar.Invoke(new MethodInvoker(this.IncrementProgressBar));
            }
            else
            {
                this.progressBar.Increment(1);
            }
        }

        private void HideProgressBar()
        {
            if (this.progressBar.InvokeRequired)
            {
                this.progressBar.Invoke(new MethodInvoker(this.HideProgressBar));
            }
            else
            {
                this.progressBar.Visible = false;
            }
        }

        private async void InputArea_TextPasted(object sender, EventArgs e)
        {
            await this.Convert();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            switch (this.WindowState)
            {
                case FormWindowState.Normal:
                    this.WindowState = FormWindowState.Minimized;
                    break;
                case FormWindowState.Minimized:
                case FormWindowState.Maximized:
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    break;
            }
            
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.formatter.IsBeautify = this.IsBeautify.Checked;
            this.formatter.UseClipboard = this.UseClipboard.Checked;
            this.formatter.WriteConfig();
        }

        private void OutputArea_TextChanged(object sender, EventArgs e)
        {
            var text = (sender as TextBox)?.Text;
            if (this.UseClipboard.Checked && !string.IsNullOrWhiteSpace(text))
            {
                Clipboard.SetText(text);
            }
        }
    }
}
