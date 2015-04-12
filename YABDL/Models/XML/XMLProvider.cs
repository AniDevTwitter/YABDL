using System;
using YABDL.Models.Interfaces;
using System.Xml.Serialization;

namespace YABDL.Models.XML
{
    [Serializable]
    public class XMLProvider : IProvider
    {
        #region IProvider implementation

        [XmlElement("Name")]
        public string Name
        {
            get;
            set;
        }

        [XmlElement("Url")]
        public string Url
        {
            get;
            set;
        }

        [XmlElement("Limit")]
        public string Limit 
        { 
            get; 
            set; 
        }

        [XmlElement("Tags")]
        public string Tags 
        { 
            get; 
            set; 
        }

        [XmlElement("RawTags")]
        public string RawTags 
        { 
            get; 
            set; 
        }

        [XmlElement("Posts")]
        public string Posts
        {
            get;
            set;
        }

        [XmlElement("Page")]
        public string Page
        {
            get;
            set;
        }

        #endregion
    }
}

