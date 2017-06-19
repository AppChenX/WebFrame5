using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RazorEngine.Templating;
using LinqToDB.SchemaProvider; 
using LinqToDB.Data;
namespace CH.CodeGenerator
{
    public class CustomTemplateBase<T> : TemplateBase<T>
    {

        public CustomTemplateBase()
        {

            this.Helper = new Helper();
        }

         public Helper Helper { get; set; }

    }

    public class Helper
    {
        public string ToUpper(string str)
        {
            return str.ToUpper();
        }
         
        /// <summary>
        /// 转换成Pascal字符串
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string ToPascal(string str)
        {
            var separator = new[] { '_', '-' };

            StringBuilder sb = new StringBuilder();
            string[] parts = str.Split(separator);
            foreach (string part in parts)
            {
                if (part.Length > 0)
                {
                    sb.Append(Char.ToUpper(part[0]));
                    if (part.Length > 1) sb.Append(part.Substring(1).ToLower());
                }
            }

            return sb.ToString();
        }


      
    }
}
