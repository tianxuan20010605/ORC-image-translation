using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ORC
{
    public partial class ORC_Set_up : Form
    {
        public ORC_Set_up()
        {
            InitializeComponent();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            
            string src = System.Windows.Forms.Application.StartupPath + "\\配置文件.txt";
            FileInfo file = new FileInfo(src);
            file.Delete();
            FileStream fs = new FileStream(src, FileMode.Create, FileAccess.Write);
            System.IO.File.SetAttributes(src, FileAttributes.Hidden);
            StreamWriter sr = new StreamWriter(fs);
            sr.WriteLine(textBox_apikey.Text);
            sr.WriteLine(textBox_secret_key.Text);
            sr.Close();
            fs.Close();
            MessageBox.Show("保存成功");

        }

        private void ORC_Set_up_Load(object sender, EventArgs e)
        {
            string src = System.Windows.Forms.Application.StartupPath + "\\配置文件.txt";
            string[] lines = System.IO.File.ReadAllLines(src,Encoding.UTF8);
            Console.WriteLine(lines[0]);
            textBox_apikey.Text = lines[0];
            textBox_secret_key.Text = lines[1];
        }
    }
}
