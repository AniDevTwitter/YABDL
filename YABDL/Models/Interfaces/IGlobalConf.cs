using System;
using System.Collections.Generic;

namespace YABDL.Models.Interfaces
{
    public interface IGlobalConf
    {
        string AppTitle
        { 
            get; 
            set; 
        }

        List<IProvider> Providers
        {
            get;
            set;
        }

        void Sync();
    }
}

