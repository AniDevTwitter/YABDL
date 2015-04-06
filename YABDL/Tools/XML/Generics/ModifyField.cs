using System;
using System.Xml;
using System.Xml.Serialization;

namespace YABDL.Tools.XML.Generics
{
    [Serializable]
    public class ModifyField
    {
        [XmlElement("FieldName")]
        public string FieldName;

        [XmlElement("FieldValue")]
        public string FieldValue;
    }
}

