namespace ORC
{
    partial class ORC_Output_Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ORC_Output_Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.翻译ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Text_box_translation = new System.Windows.Forms.TextBox();
            this.Text_box_translation_end = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.翻译ToolStripMenuItem,
            this.设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(611, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 翻译ToolStripMenuItem
            // 
            this.翻译ToolStripMenuItem.Name = "翻译ToolStripMenuItem";
            this.翻译ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.翻译ToolStripMenuItem.Text = "翻译";
            this.翻译ToolStripMenuItem.Click += new System.EventHandler(this.翻译ToolStripMenuItem_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.设置ToolStripMenuItem.Text = "设置";
            this.设置ToolStripMenuItem.Click += new System.EventHandler(this.设置ToolStripMenuItem_Click);
            // 
            // Text_box_translation
            // 
            this.Text_box_translation.Location = new System.Drawing.Point(3, 3);
            this.Text_box_translation.Multiline = true;
            this.Text_box_translation.Name = "Text_box_translation";
            this.Text_box_translation.Size = new System.Drawing.Size(188, 25);
            this.Text_box_translation.TabIndex = 1;
            // 
            // Text_box_translation_end
            // 
            this.Text_box_translation_end.Location = new System.Drawing.Point(302, 3);
            this.Text_box_translation_end.Multiline = true;
            this.Text_box_translation_end.Name = "Text_box_translation_end";
            this.Text_box_translation_end.Size = new System.Drawing.Size(100, 253);
            this.Text_box_translation_end.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.Text_box_translation, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Text_box_translation_end, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 31);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(599, 259);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // ORC_Output_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(611, 302);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ORC_Output_Form1";
            this.Text = "ORC_Output_Form";
            this.Load += new System.EventHandler(this.ORC_Output_Form_Load);
            this.SizeChanged += new System.EventHandler(this.ORC_Output_Form_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.ORC_Output_Form1_VisibleChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 翻译ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.TextBox Text_box_translation;
        private System.Windows.Forms.TextBox Text_box_translation_end;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}