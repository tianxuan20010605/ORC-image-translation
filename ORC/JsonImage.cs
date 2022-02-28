using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORC
{
    class JsonImage
    { //以json 的格式创建等级嵌套的class类型 用作匹配
        public class Probability
        {
            public double variance { get; set; }
            public double average { get; set; }
            public double min { get; set; }
        }
        public class word_resultitem
        {
            /// <summary>
            /// 精确识别图片上的文字
            /// </summary>
            public string words { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Probability probability { get; set; }
        }
        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public Int64 log_id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int direction { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int words_result_num { get; set; }  //定义与json类型相同的名字相同
            /// <summary>
            /// 
            /// </summary>
            public List<word_resultitem> words_result { get; set; }//由于底下还有一层所以还需再创建一个class类
        }
    }


    class JSON_English_translation
    {
        public class translate
        {
            public string tgt { get; set; }

            public string src { get; set; }
        }

        public class english
        {
            public string type { get; set; }

            public int errorCode { get; set; }
            public int elapsedTime { get; set; }
            public List<List<translate>>translateResult { get; set; }
        }
    }



}
