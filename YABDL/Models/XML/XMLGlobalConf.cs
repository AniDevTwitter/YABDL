using System;
using YABDL.Models.Interfaces;
using System.IO;
using System.Xml.Serialization;
using YABDL.Tools.XML.Generics;
using System.Collections.Generic;

namespace YABDL.Models.XML
{
    [Serializable]
    public class XMLGlobalConf : IGlobalConf
    {
        // It's where we should serialize this
        private static readonly string GlobalConfPath = Path.Combine(GlobalConf.AppConfigFolderPath, @"globalConf.xml");

        public XMLGlobalConf()
        {
            this.Providers = new List<IProvider>();
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

        [XmlArray("Providers"), XmlArrayItem(typeof(XMLProvider), ElementName = "Provider")]
        public List<IProvider> Providers
        {
            get;
            set;
        }

        #endregion

        /// <summary>
        /// Get a new one or serialize one with default value if it don't exists
        /// </summary>
        /// <returns>The global app conf.</returns>
        public static XMLGlobalConf GetConf()
        {
            if (File.Exists(XMLGlobalConf.GlobalConfPath))
            {
                return XMLFileAccess.Read<XMLGlobalConf>(XMLGlobalConf.GlobalConfPath);
            }
            var retVal = new XMLGlobalConf()
                {
                    AppTitle = @"Yet Another Booru DownLoader",
                    Providers = new List<IProvider>
                        {
                            new XMLProvider()
                            {
                                Name = @"Danbooru",
                                Url = @"danbooru.donmai.us/",
                                Limit = @"limit",
                                
                                Tags = @"tags",
                                RawTags = @"raw",
                            }
                        }
                };
            retVal.Sync();
            return retVal;
        }
    }
}

