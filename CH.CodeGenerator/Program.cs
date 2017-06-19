using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RazorEngine.Templating;
using RazorEngine.Configuration;
using System.IO;
using System.Text;
namespace CH.CodeGenerator
{
    static class Program
    {


        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        /*   [STAThread]
          static void Main()
          {
              Application.EnableVisualStyles();
              Application.SetCompatibleTextRenderingDefault(false);
              Application.Run(new frmMain());
          } */

        static void Main(string[] args)
        {
            var db = new LinqToDB.Data.DataConnection("default");

            var sp = db.DataProvider.GetSchemaProvider();
            var schema = sp.GetSchema(db);

            LinqToDB.SchemaProvider.TableSchema table = null;

            foreach (var item in schema.Tables)
            {
                if (item.TableName.ToUpper() == "SYS_SIGIN_LOG")
                {


                    table = item;
                    foreach (var col in item.Columns)
                    {

                        //Console.WriteLine(string.Format(" col.ColumnName:{0},col.ColumnType:{1},col.DataType :{2},col.Length:{3} ,col.MemberType:{4}", col.ColumnName, col.ColumnType, col.DataType, col.Length, col.MemberType));
                    }
                }
            }


            string index = System.IO.File.ReadAllText("testdb2linq.cshtml", System.Text.Encoding.UTF8);
            var config = new TemplateServiceConfiguration();
            config.BaseTemplateType = typeof(CustomTemplateBase<>);
            //config.Debug = true;
            using (var service = RazorEngineService.Create(config))
            {


                string result = service.RunCompile(index, string.Empty, null, new { Table = table, Cols = table.Columns });

                //Console.WriteLine(result);

                using (FileStream fs = new FileStream(table.TableName.ToUpper().ToPascal() + ".cs", FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(result);
                    }

                }


            }

        }

    }















   
    






}
