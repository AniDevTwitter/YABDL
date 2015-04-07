using System;
using YABDL.Models.Interfaces;
using System.IO;
using System.Xml.Serialization;
using YABDL.Tools.XML.Generics;

namespace YABDL.Models.XML
{
    [Serializable]
    public class XMLGlobalConf : IGlobalConf
    {
        // It's where we should serialize this
        private static readonly string GlobalConfPath = Path.Combine(GlobalConf.AppConfigFolderPath, @"globalConf.xml");

        public XMLGlobalConf()
        {

        }

        #region IGlobalConf implementation

        public void Sync()
        {
            // RIP if exception
            XMLFileAccess.Write(this, XMLGlobalConf.GlobalConfPath);
        }


        [XmlElement("AppTitle")]
        public string AppTitle
        {
            get;
            set;
        }

        #endregion

        // Get a new one or serialize one with default value if it don't exists
        public static XMLGlobalConf GetConf()
        {
            if (File.Exists(XMLGlobalConf.GlobalConfPath))
            {
                return XMLFileAccess.Read<XMLGlobalConf>(XMLGlobalConf.GlobalConfPath);
            }
            var retVal = new XMLGlobalConf()
                {
                    AppTitle = @"Yet Another Booru DownLoader"
                };
            retVal.Sync();
            return retVal;
        }
    }
}

