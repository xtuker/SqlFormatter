namespace SqlFormatter
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.OutputArea = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.IsBeautify = new System.Windows.Forms.CheckBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.UseClipboard = new System.Windows.Forms.CheckBox();
            this.InputArea = new SqlFormatter.MyTextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.ElapsedTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OutputArea
            // 
            this.OutputArea.AcceptsReturn = true;
            this.OutputArea.AcceptsTab = true;
            this.OutputArea.AllowDrop = true;
            this.OutputArea.Location = new System.Drawing.Point(12, 161);
            this.OutputArea.MaxLength = 2097152;
            this.OutputArea.Multiline = true;
            this.OutputArea.Name = "OutputArea";
            this.OutputArea.ReadOnly = true;
            this.OutputArea.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.OutputArea.Size = new System.Drawing.Size(776, 235);
            this.OutputArea.TabIndex = 1;
            this.OutputArea.WordWrap = false;
            this.OutputArea.TextChanged += new System.EventHandler(this.OutputArea_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Конвертировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // IsBeautify
            // 
            this.IsBeautify.AutoSize = true;
            this.IsBeautify.Checked = true;
            this.IsBeautify.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsBeautify.Location = new System.Drawing.Point(126, 136);
            this.IsBeautify.Name = "IsBeautify";
            this.IsBeautify.Size = new System.Drawing.Size(109, 17);
            this.IsBeautify.TabIndex = 3;
            this.IsBeautify.Text = "Форматировать";
            this.IsBeautify.UseVisualStyleBackColor = true;
            this.IsBeautify.CheckedChanged += new System.EventHandler(this.IsBeautify_CheckedChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // UseClipboard
            // 
            this.UseClipboard.AutoSize = true;
            this.UseClipboard.Checked = true;
            this.UseClipboard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseClipboard.Location = new System.Drawing.Point(242, 136);
            this.UseClipboard.Name = "UseClipboard";
            this.UseClipboard.Size = new System.Drawing.Size(170, 17);
            this.UseClipboard.TabIndex = 4;
            this.UseClipboard.Text = "Копировать в буфер обмена";
            this.UseClipboard.UseVisualStyleBackColor = true;
            // 
            // InputArea
            // 
            this.InputArea.AcceptsReturn = true;
            this.InputArea.AcceptsTab = true;
            this.InputArea.AllowDrop = true;
            this.InputArea.Location = new System.Drawing.Point(12, 19);
            this.InputArea.Margin = new System.Windows.Forms.Padding(10);
            this.InputArea.MaxLength = 2097152;
            this.InputArea.Multiline = true;
            this.InputArea.Name = "InputArea";
            this.InputArea.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.InputArea.Size = new System.Drawing.Size(776, 100);
            this.InputArea.TabIndex = 0;
            this.InputArea.TextPasted += new System.EventHandler(this.InputArea_TextPasted);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(195, 210);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(410, 23);
            this.progressBar.TabIndex = 5;
            this.progressBar.Visible = false;
            // 
            // ElapsedTime
            // 
            this.ElapsedTime.AutoSize = true;
            this.ElapsedTime.Location = new System.Drawing.Point(580, 136);
            this.ElapsedTime.Name = "ElapsedTime";
            this.ElapsedTime.Size = new System.Drawing.Size(48, 13);
            this.ElapsedTime.TabIndex = 6;
            this.ElapsedTime.Text = "Elapsed:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 408);
            this.Controls.Add(this.ElapsedTime);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.UseClipboard);
            this.Controls.Add(this.IsBeautify);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.OutputArea);
            this.Controls.Add(this.InputArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Конвертер логов NHibernate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyTextBox InputArea;
        private System.Windows.Forms.TextBox OutputArea;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox IsBeautify;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.CheckBox UseClipboard;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label ElapsedTime;
    }
}

