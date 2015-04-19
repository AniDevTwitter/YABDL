using System;
using YABDL.Models.Interfaces;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using YABDL.Models.Downloader;

namespace YABDL.Models.XML
{
    [Serializable]
    public class XMLQuery : AbstractQuery
    {
        public XMLQuery()
        {

        }

        [XmlArray("ToDownload"), XmlArrayItem(typeof(Tuple<string, string>), ElementName = "FileNameUrl")]
        public override IList<Tuple<string, string>> ToDownload { get; set; }

        [XmlArray("Providers"), XmlArrayItem(typeof(Guid), ElementName = "Provider")]
        public override IList<Guid> Providers { get; set; }

        [XmlElement("Tags")]
        public override string Tags { get ; set; }

        [XmlElement("FolderPath")]
        public override string FolderPath { get ; set; }

    }
}

