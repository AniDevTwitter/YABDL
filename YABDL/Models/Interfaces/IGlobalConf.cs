using System;
using System.Collections.Generic;

namespace YABDL.Models.Interfaces
{
    public interface IGlobalConf
    {
        /// <summary>
        /// Gets or sets the app title.
        /// </summary>
        /// <value>The app title.</value>
        string AppTitle
        { 
            get; 
            set; 
        }

        /// <summary>
        /// Gets or sets the providers this app has.
        /// </summary>
        /// <value>The providers this app has.</value>
        List<IProvider> Providers
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the providers this app has.
        /// </summary>
        /// <value>The providers this app has.</value>
        List<IQuery> Queries
        {
            get;
            set;
        }


        /// <summary>
        /// Make this instance persists.
        /// </summary>
        void Sync();
    }
}

