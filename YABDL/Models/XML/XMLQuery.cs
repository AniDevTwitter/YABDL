using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using YABDL.Models.Downloader;

namespace YABDL.Models.XML
{
    [Serializable]
    public sealed class XMLQuery : AbstractQuery
    {
        public XMLQuery() : base()
        {
            this.Providers = new List<Guid>();
        }

        [XmlArray("Providers"), XmlArrayItem(typeof(Guid), ElementName = "Provider")]
        public override List<Guid> Providers { get; set; }

        [XmlElement("Tags")]
        public override string Tags { get ; set; }

        [XmlElement("FolderPath")]
        public override string FolderPath { get ; set; }

        [XmlElement("Label")]
        public override string Label {get; set;}
    }
}

