using System;
using System.Collections.Generic;
using YABDL.Models.API.Interfaces;

namespace YABDL.Models.Interfaces
{
    public interface IQuery
    {
        /// <summary>
        /// Gets or sets the providers ids binded to this query.
        /// </summary>
        /// <value>The providers.</value>
        IList<Guid> Providers { get; set; }

        string FolderPath {get; set;}

        /// <summary>
        /// Gets or sets the tags this query will be bound.
        /// </summary>
        /// <value>The tags this query will be bound..</value>
        string Tags { get; set; }

        /// <summary>
        /// Execute this query across the providers to fill files.
        /// </summary>
        /// <param name="access">Access.</param>
        /// <param name="idToProvider">Identifier to provider.</param>
        void Execute(IAPIAccess access, IReadOnlyDictionary<Guid, IProvider> idToProvider);
       
    }
}

