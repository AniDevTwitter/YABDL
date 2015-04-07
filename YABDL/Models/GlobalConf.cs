using System;
using YABDL.Models.Interfaces;
using System.IO;
using YABDL.Models.XML;

namespace YABDL.Models
{
    public static class GlobalConf
    {
        public static readonly string AppConfigFolderPath = Path.Combine(Path.GetFullPath(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)), @"yabdl/");

        private enum GlobalConfFileType
        {
            XML,
            // add more if you want
        }

        private const GlobalConfFileType UsedConfFileType = GlobalConfFileType.XML;
        private static IGlobalConf current = null;

        public static IGlobalConf GetGlobalConf()
        {
            if (GlobalConf.current == null)
            {
                switch (GlobalConf.UsedConfFileType)
                {
                    case GlobalConfFileType.XML:
                        GlobalConf.current = XMLGlobalConf.GetConf();
                        break;
                    //default:
                      //  throw new ArgumentException(GlobalConf.UsedConfFileType + " isn't supported yet.");
                }
            }
            return GlobalConf.current;
        }
    }
}

