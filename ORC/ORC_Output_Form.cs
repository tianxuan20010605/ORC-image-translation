using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using baidu;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using Hook;
namespace ORC
{

    public partial class ORC_Output_Form1 : Form
    {
        public ORC_Output_Form1()
        {
            InitializeComponent();
            
        }

        private void ORC_Output_Form_Load(object sender, EventArgs e)//初始化组件
        {
            this.Width = 580;
            this.Height = 400;
            tableLayoutPanel1.Width = (int)(this.Width * 0.969);
            tableLayoutPanel1.Height = (int)(this.Height * 0.84);
            Text_box_translation.AutoSize = false;
            Text_box_translation_end.AutoSize = false;
            Text_box_translation_end.Multiline = true;

            Text_box_translation.Width =tableLayoutPanel1.Width/2 ;
            Text_box_translation_end.Width =tableLayoutPanel1.Width/2;
            Text_box_translation.Height =tableLayoutPanel1.Height;
            Text_box_translation_end.Height =tableLayoutPanel1.Height;
        }

        private void ORC_Output_Form_SizeChanged(object sender, EventArgs e) //控制文本框大小
        {
            tableLayoutPanel1.Width = (int)(this.Width * 0.969);
            tableLayoutPanel1.Height = (int)(this.Height * 0.84);
            Text_box_translation.AutoSize = false;
            Text_box_translation_end.AutoSize = false;

            Text_box_translation.Width = tableLayoutPanel1.Width / 2;
            Text_box_translation_end.Width = tableLayoutPanel1.Width / 2;
            Text_box_translation.Height = tableLayoutPanel1.Height;
            Text_box_translation_end.Height = tableLayoutPanel1.Height;
        }
        /// <summary>
        /// 翻译函数接口为有道
        /// </summary>
        void post_engslish(string item)
        {
            string posidate = "i=" + item + "&doctype=json";
            string strurl = "https://fanyi.youdao.com/translate?smartresult=dict,rule";     //请求的地址
            System.Net.HttpWebRequest request;          //定义一个请求http类是用于发送和接收HTTP数据的最好选择
            request = (System.Net.HttpWebRequest)WebRequest.Create(strurl); //想对应接口发送请求
            request.Method = "POST";        //请求方式
         
            request.ContentType = "application/x-www-form-urlencoded";  //请求标头类别
            request.AutomaticDecompression = DecompressionMethods.GZip; //解码格式
            request.Accept = "*/*";

            StreamWriter writer = new StreamWriter(request.GetRequestStream()); //创建一个可以写入的字节流
            writer.Write(posidate);     //进行写入操作暂存与缓存中
            writer.Flush();     //将缓存写入磁盘
            writer.Close();  //关闭
            
            HttpWebResponse response = (HttpWebResponse)request.GetResponse(); //用于接收的response类
            
            Stream getstream = response.GetResponseStream();        //存储服务器返回的响应体
            StreamReader streamreader = new StreamReader(getstream); ///不知道什么原因导致字节流卡死怀疑不能同时开启过多字节流
            string result = streamreader.ReadToEnd();
            Console.WriteLine(result);//多次不清除缓存导致系统资源无法释放导致卡死
            streamreader.Close();
            try
            {

                JSON_English_translation.english englishend = JsonConvert.DeserializeObject<JSON_English_translation.english>(result); //反序列化json
                Text_format(englishend.translateResult[0][0].tgt); //输出至文本框
            }
            catch
            {
                Console.WriteLine("参数输入有误");
            }

        }

        /// <summary>
        /// 调整英文输出格式函数
        /// </summary>
        void Text_format(string text)//调整英文输出格式
        {
            Text_box_translation_end.Text +=text+ Environment.NewLine;
        }

        /// <summary>
        /// 调用识图函数
        /// </summary>
        public  void translation_play()
        {
            try
            {
                string src = System.Windows.Forms.Application.StartupPath + "//2.jpg"; //获取生成的当前文件位置
                var api = AccessToken.Imgget(src);
                JsonImage.Root rt = JsonConvert.DeserializeObject<JsonImage.Root>(api); //将传输出来的结果反序化
                foreach (var temp in rt.words_result)
                {
                    Text_box_translation.Text += temp.words + "\r\n"; //遍历输出
                }
            }
            catch
            {
                MessageBox.Show("key过期或错误，请重新确认");
            }
      

        }

        private void 翻译ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Text_box_translation_end.Text = "";


            var text = Regex.Split(Text_box_translation.Text, "\n");//根据换行符进行匹配决定循环次数
            foreach (var temp in text)
            {
                post_engslish(temp);
            }
        }




        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            ORC_Set_up f1 = new ORC_Set_up();
            f1.Visible = false;
            f1.ShowDialog();
            f1.TopMost = true;
            f1.BringToFront();
        }

        int state_tppe = 1;
        /// <summary>
        /// y用作状态识别用于确认是单击截图后调用还是托盘程序调用 1为正常截图调用 0为单击托盘时调用
        /// 要在窗口创建前调用
        /// </summary>
        public void from_state(int state_tppe_end)
        {
            state_tppe = state_tppe_end;
            Console.WriteLine("状态发生了更改");
        }
        private void ORC_Output_Form1_VisibleChanged(object sender, EventArgs e)
        {
            /// <summary>
            /// 调用识图函数
            /// </summary>
            if (this.Visible == true && state_tppe == 1)
            {
                Text_box_translation.Text = "";
                Text_box_translation_end.Text = "";
                translation_play();
                Console.WriteLine("from_state调用成功");

                var text = Regex.Split(Text_box_translation.Text, "\n");//根据换行符进行匹配决定循环次数
                foreach (var temp in text)
                {
                    post_engslish(temp);
                }

            }

        }

    }
}
