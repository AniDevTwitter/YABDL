using System;

namespace YABDL.Models.Interfaces
{
    public interface IGlobalConf
    {
        string AppTitle
        { 
            get; 
            set; 
        }

        void Sync();
    }
}

