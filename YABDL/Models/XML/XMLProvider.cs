using System;
using YABDL.Models.Interfaces;

namespace YABDL.Models.XML
{
    public class XMLProvider : IProvider
    {
        public XMLProvider()
        {

        }


        #region IProvider implementation

        public string Name
        {
            get;
            set;
        }

        public string Url
        {
            get;
            set;
        }

        #endregion
    }
}

