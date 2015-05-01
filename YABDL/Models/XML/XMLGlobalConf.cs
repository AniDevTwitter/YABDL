using System;
using YABDL.Models.Interfaces;
using System.IO;
using System.Xml.Serialization;
using YABDL.Tools.XML.Generics;
using System.Collections.Generic;
using System.Linq;

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
            this.Queries = new List<IQuery>();
            this.Factory = new XMLFactory();
        }



        #region IGlobalConf implementation

        public void Sync()
        {
            // RIP if exception
            XMLFileAccess.Write(this, XMLGlobalConf.GlobalConfPath);
        }
            
        [XmlElement("AppTitle")]
        public string AppTitle {get; set;}

        [XmlElement("DefaultOutputFolderPath")]
        public string DefaultOutputFolderPath {get; set;}

        [XmlArray("Providers"), XmlArrayItem(typeof(XMLProvider), ElementName = "Provider")]
        public List<IProvider> Providers {get; set;}

        [XmlArray("Queries"), XmlArrayItem(typeof(XMLQuery), ElementName = "Query")]
        public List<IQuery> Queries {get; set;}

        [XmlIgnore]
        public IFactory Factory { get; private set; }

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

            // Warning, wall of code, it's test purpose only and will be removed in the future when xml config files will be stable
            var retVal = new XMLGlobalConf()
                {
                    AppTitle = @"Yet Another Booru DownLoader",
                    DefaultOutputFolderPath = Path.GetFullPath(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)),
                    Queries = new List<IQuery>(),
                    Providers = new List<IProvider>(),
                };
            retVal.Providers.Add(retVal.Factory.NewProvider(@"Danbooru", @"danbooru.donmai.us"));
            retVal.Sync();
            return retVal;
        }
    }
}

