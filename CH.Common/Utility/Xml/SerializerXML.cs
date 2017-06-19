using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace CH.Common.Utility
{

    /// <summary>
    /// 序列化\反序列化XML
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SerializerXML<T> where T:class
    {

        /// <summary>
        /// 文件名
        /// </summary>
        public string fileName { get; set; }

        public SerializerXML()
        {

        }

        public SerializerXML(string fileName)
        {
            this.fileName = fileName;

        }

        public void Save(T obj)
        {
            Save(obj, fileName);
        }
        public void Save(T obj,string fileName)
        {

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlSerializer xmls = new XmlSerializer(typeof(T));
            XmlWriterSettings sets = new XmlWriterSettings();
            sets.Encoding = Encoding.UTF8;
            sets.OmitXmlDeclaration = false;
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            { 
                    XmlWriter writer = XmlWriter.Create(fs, sets);
                    xmls.Serialize(writer, obj, ns);
                    writer.Close(); 
            }

        }

        public T GetObj()
        {
            return GetObj(fileName);
        }

        public T GetObj(string fileName)
        {

            if (!File.Exists(fileName)) return default(T);
             
            XmlSerializer xmls = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                return xmls.Deserialize(fs) as T;
            }
        }
    }

}
