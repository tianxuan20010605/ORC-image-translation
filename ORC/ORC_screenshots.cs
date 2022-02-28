using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Windows.Input;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using Hook;
using System.IO;
using ORC;

namespace ORC
{
    public partial class screenshots_Form1 : Form
    {   
        bool Draw_controller = false;           //用作判断当前是否在移动
        int start_point_x = 0, start_point_y = 0;   //起坐标
        int move_point_x = 0, move_point_y = 0; //移动时变化的坐标
        int end_point_x = 0, end_point_y = 0;   //最终坐标
        ORC_Output_Form1 ORc_outpuy = new ORC_Output_Form1();
        private void hook_KeyDown(object sender, KeyEventArgs e)   //监听键盘
        {
            if (e.KeyCode == Keys.F1)
            {
                this.TopMost = true;
                this.BringToFront();
                this.WindowState = FormWindowState.Maximized;
                this.Activate();
                ORc_outpuy.Visible = false;

                
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.TopMost = false;
                this.WindowState = FormWindowState.Minimized;
            }
        }
     


        public screenshots_Form1()
        {
            var k_hook = new KeyboardHook();
            k_hook.KeyDownEvent += new KeyEventHandler(hook_KeyDown);//钩住键按下
            k_hook.Start();//安装键盘钩子
            InitializeComponent();
        }

        void Display(int x,int y,int width,int height)  //绘制图形函数
        {
         
            Pen mypen = new Pen(Color.Red,1);       //设置画笔
            Graphics g = this.CreateGraphics();     //创建画布
            g.Clear(Color.White);
            g.DrawRectangle(mypen,x,y,width,height); //进行绘制
            
        }

        void Getmouse_position(int judge_tpye) //获取鼠标坐标
        {
            Point screenshots_Form_position = Form.MousePosition;   //得到鼠标位于屏幕位置
            if (judge_tpye == 1)        //起点坐标
            {
                start_point_x= screenshots_Form_position.X;
                start_point_y = screenshots_Form_position.Y;
                judge_tpye = 0;
                Console.WriteLine("起点  " + start_point_x + "  " + start_point_y);
            }
            if (judge_tpye == 2)    //移动坐标
            {
                move_point_x = screenshots_Form_position.X;
                move_point_y = screenshots_Form_position.Y;
                judge_tpye = 0;
                Console.WriteLine("移动中坐标  " + move_point_x + "  " + move_point_y);
            }
            if (judge_tpye == 3)//终点坐标
            {
                end_point_x = screenshots_Form_position.X;
                end_point_y = screenshots_Form_position.Y;

                judge_tpye = 0;
                Console.WriteLine("终点坐标  " + end_point_x + "  " + end_point_y);
            } 
        }

     
        
        /// <summary>
        /// 托盘程序双击事件
        /// </summary>
        /// 
        void MynotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            /*this.Visible=false;
            this.Show();
            this.TopMost = true;
            this.BringToFront();
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            */
            ORc_outpuy.from_state(0);
            ORc_outpuy.Visible = false;
            ORc_outpuy.ShowDialog();
            ORc_outpuy.BringToFront();
            ORc_outpuy.TopMost = true;
            ORc_outpuy.WindowState = FormWindowState.Normal;
           
        }

        /// <summary>
        /// 托盘程序最小化事件
        /// </summary>
        void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState=FormWindowState.Minimized;
                
            }
        }

        /// <summary>
        /// 配置文件创建函数
        /// </summary>
        void config_text_create()
        {
            string src = System.Windows.Forms.Application.StartupPath + "\\配置文件.txt";
            if (!System.IO.File.Exists(src))
            {
                FileStream fs1 = new FileStream(src,FileMode.Create,FileAccess.Write);
                System.IO.File.SetAttributes(src, FileAttributes.Hidden);
                StreamWriter sw = new StreamWriter(fs1);
                sw.WriteLine("key");
                sw.WriteLine("keys");
                sw.Close();
                fs1.Close();
                Console.WriteLine("创建成功了");
            }
            
        }


        private void Form1_Load(object sender, EventArgs e)  //页面加载时
        {
            prevent_flashing();
            this.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;//设置宽
            this.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;

            config_text_create();
            /// <summary>
            /// 配置文件初始化
            /// </summary>



            /// <summary>
            /// 托盘创建
            /// </summary>
            NotifyIcon MynotifyIcon = new NotifyIcon();
            MynotifyIcon.Visible = true;
            MynotifyIcon.Text = "ORC";

            MynotifyIcon.BalloonTipText = "我的ORC";
            //MynotifyIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath);
            string src = System.Windows.Forms.Application.StartupPath;
            Icon i = new Icon(src+ "\\o0ho.ico");
            MynotifyIcon.Icon = i;
            MynotifyIcon.MouseDoubleClick += MynotifyIcon_MouseDoubleClick;
            this.Resize += Form1_Resize;
        }

        

        private void screenshots_Form1_MouseUp(object sender, MouseEventArgs e) //鼠标抬起事件
        {
            
            Draw_controller = false;
            Console.WriteLine(Draw_controller);
            Getmouse_position(3);       //获取坐标 //
            if (start_point_x < move_point_x) //判断是否为倒正方形，这个绘制函数是无负数 宽高无负数
            {
                Display(start_point_x, start_point_y, move_point_x - start_point_x, move_point_y - start_point_y);
            }
            else
            {
                Display(move_point_x, move_point_y, start_point_x - move_point_x, start_point_y - move_point_y);
            }

            button_end.Location = new Point(end_point_x-42,end_point_y+3);
            button_end.Visible = true;
        }

        void Screenshot_Save()          //截图保存
        {
            Bitmap bit;
            Point xy;
            int sumzhi = 10;
            this.TopMost = true;
            if (start_point_x < end_point_x) //判断是否为倒正方形，这个绘制函数是无负数 宽高无负数
            {
               bit = new Bitmap((int)((end_point_x - start_point_x) * 1.25 + sumzhi), (int)((end_point_y - start_point_y) * 1.25) + sumzhi);//截取的大小 
               xy = new Point(System.Math.Abs((int)(start_point_x * 1.25)), System.Math.Abs((int)(start_point_y * 1.25)));
               Console.WriteLine("正正方形" + xy);
               Console.WriteLine("正正方形大小" + bit.Width + " " + bit.Height);
            }
            else
            {
               bit = new Bitmap((int)((start_point_x - end_point_x) * 1.25) + sumzhi, (int)((start_point_y - end_point_y) * 1.25) + sumzhi);//截取的大小 
               xy = new Point((int)(end_point_x * 1.25), (int)(end_point_y * 1.25));
               Console.WriteLine("倒正方形" + xy);
               Console.WriteLine("倒正方形大小" + bit.Width + " " + bit.Height);
            }
            Graphics g = Graphics.FromImage(bit);           //创建画布
            g.CopyFromScreen(xy, this.Location, bit.Size);      //截取区域
            string src = System.Windows.Forms.Application.StartupPath; //获取当前地址
            bit.Save(src + "//2.jpg", System.Drawing.Imaging.ImageFormat.Jpeg); //存储成jpg
            Console.WriteLine(System.Windows.Forms.Application.StartupPath);
            this.TopMost = false;                   //取消窗口置顶
            this.WindowState = FormWindowState.Minimized;   //窗口最小化
        }

        private void screenshots_Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void button_end_Click(object sender, EventArgs e)
        {
            ORc_outpuy.from_state(1);
            Screenshot_Save();

            /// <summary>
            /// 唤出文本窗口
            /// </summary>
            ORc_outpuy.BringToFront();
            ORc_outpuy.TopMost = true;
            ORc_outpuy.ShowDialog();

        }

        void prevent_flashing() //防止闪烁并重绘背景
        {
            this.BackColor = Color.White;
            this.Opacity = 0.5;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            this.SetStyle(ControlStyles.DoubleBuffer, true);

            this.SetStyle(ControlStyles.UserPaint, true);

            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            prevent_flashing();
            Getmouse_position(1);//1
            Draw_controller = true; //等于ture说明已经确认了起点正在移动至终点
        }
        private void screenshots_Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Draw_controller==true)
            {
                Getmouse_position(2);
                prevent_flashing();
                button_end.Visible = false;
                if (start_point_x < move_point_x) //判断是否为倒正方形，这个绘制函数是无负数 宽高无负数
                {
                    Display(start_point_x, start_point_y, move_point_x - start_point_x, move_point_y - start_point_y);
                }
                else
                {
                    Display(move_point_x, move_point_y, start_point_x - move_point_x, start_point_y - move_point_y);
                }
            }
        }
    }
}
