namespace ORC
{
    partial class screenshots_Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(screenshots_Form1));
            this.button_end = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_end
            // 
            this.button_end.BackColor = System.Drawing.Color.White;
            this.button_end.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button_end.Location = new System.Drawing.Point(597, 372);
            this.button_end.Name = "button_end";
            this.button_end.Size = new System.Drawing.Size(42, 35);
            this.button_end.TabIndex = 0;
            this.button_end.Text = "end";
            this.button_end.UseVisualStyleBackColor = false;
            this.button_end.Visible = false;
            this.button_end.Click += new System.EventHandler(this.button_end_Click);
            // 
            // screenshots_Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_end);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "screenshots_Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.screenshots_Form1_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.screenshots_Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.screenshots_Form1_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_end;
    }
}

