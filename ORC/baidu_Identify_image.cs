using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.IO;
using ORC;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;
namespace baidu
{
    public static class AccessToken

    {


        public static string Imgget(string imgurl)
        {
                /// <summary>
                ///读取配置文件key
                /// </summary>
                /// 
                string src = System.Windows.Forms.Application.StartupPath + "\\配置文件.txt";
                string[] lines = System.IO.File.ReadAllLines(src, Encoding.UTF8);

                var API_Key = lines[0];
                var Secret_Key = lines[1];
                var client = new Baidu.Aip.Ocr.Ocr(API_Key, Secret_Key);        //使用百度ai接口需要项目中安装百度ai
                client.Timeout = 60000;

                var image = File.ReadAllBytes(imgurl);          //图片转换成字节型
                var result = client.GeneralBasic(image);      //传输给接口同时返回json数据

                var options = new Dictionary<string, object>
                {
                    { "language_type", "CHN_ENG" },         //判断语言
                    {"detect_direction","true" },
                    {"detect_language","true"},
                    {"probability","true"}
                };

                string getJson = result.ToString(); //转换成字符串类型
                                                    //JsonImage.Root rt = JsonConvert.DeserializeObject<JsonImage.Root>(getJson);  //JsonImage.Root为对应的cs中的路径
                                                    //Console.WriteLine(rt.words_result[1].words); 使用格式   //getJson需要转换的反序化json字符
                return getJson;  //返回字符串类型的json数据
 
        }
     
    }
}