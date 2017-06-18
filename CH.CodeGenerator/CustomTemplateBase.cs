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

            this.HtmlHelper = new HtmlHelper();
        }

        public HtmlHelper HtmlHelper { get; set; }

    }

    public class HtmlHelper
    {
        public string ToUpper(string str)
        {
            return str.ToUpper();
        }

        //[Column(Name = "Action_Id", CanBeNull = false)]
        private string ColumnProperty(ColumnSchema col)
        {

            string rs = string.Empty;

            if(col.IsPrimaryKey)
            {
                rs += "[PrimaryKey]\r\n";
            } 
            rs += string.Format("[Column(Name=\"{0}\",CanBeNull={1},IsIdentity={2}", col.ColumnName.ToUpper(), (!col.IsNullable).ToString().ToLower(),col.IsIdentity.ToString().ToLower());  

            return rs;

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
