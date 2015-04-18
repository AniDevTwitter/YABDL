using System;
using YABDL.Models.Interfaces;
using System.IO;
using YABDL.Models.XML;
using YABDL.Models.API;
using YABDL.Models.API.Interfaces;

namespace YABDL.Models
{
    public static class GlobalConf
    {
        private const SerializedAs UsedConfFileType = SerializedAs.XML;
        private static IGlobalConf currentConf = null;
        private static IAPIAccess currentApiAccess = null;

        public static readonly string AppConfigFolderPath = Path.Combine(Path.GetFullPath(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)), @"yabdl/");

        public static IGlobalConf GetGlobalConf()
        {
            if (GlobalConf.currentConf == null)
            {
                switch (GlobalConf.UsedConfFileType)
                {
                    case SerializedAs.XML:
                        GlobalConf.currentConf = XMLGlobalConf.GetConf();
                        break;
                    //default:
                      //  throw new ArgumentException(GlobalConf.UsedConfFileType + " isn't supported yet.");
                }
            }
            return GlobalConf.currentConf;
        }

        public static IAPIAccess GetAPIAccess()
        {
            if (GlobalConf.currentApiAccess == null)
            {
                GlobalConf.currentApiAccess = new BooruAccess();
            }
            return GlobalConf.currentApiAccess;
        }
    }
}

