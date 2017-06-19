using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
namespace CH.CodeGenerator
{



    [XmlRoot(ElementName = "Config", IsNullable = false, Namespace = "")]
    public class ConnectionStrs
    { 
        [XmlElement("List", typeof(ConnectionStr))]
        public List<ConnectionStr> ConnectionStrList { get; set; }
       
    }
    [Serializable]
    public class ConnectionStr
    {
        [XmlAttribute(AttributeName = "ID")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "Checked")]
        public bool Checked { get; set; }
    }
}
