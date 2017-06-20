using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CH.CodeGenerator
{
    public class Constant
    {

        /// <summary>
        /// xml
        /// </summary>
        public static string xmlFileName = @"config\config.xml";

        /// <summary>
        /// ini
        /// </summary>
        public static string iniFileName= @"config\settings.ini";


        /// <summary>
        /// Section名称
        /// </summary>
        public static string ini_Section_name = "generator";
        /// <summary>
        /// 模板Section名称
        /// </summary>
        public static string ini_Section_templateFile = "file";

        /// <summary>
        /// 输出目录
        /// </summary>
        public static string ini_Section_outDirectory = "dir";
    }
}
