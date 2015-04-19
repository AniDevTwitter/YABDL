using System;

namespace YABDL.Models.Interfaces
{
    public interface IProvider
    {
        /// <summary>
        /// Gets or sets the name of this provider.
        /// </summary>
        /// <value>The name of this provider (GUI intended).</value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the URL of this provider.
        /// </summary>
        /// <value>The URL of this provider.</value>
        string Url { get; set; }

        /// <summary>
        /// Gets or sets the posts REST key.
        /// </summary>
        /// <value>The posts REST key.</value>
        string Posts{ get; set; }

        /// <summary>
        /// Gets or sets the limit REST key.
        /// </summary>
        /// <value>The limit REST key.</value>
        string Limit { get; set; }

        /// <summary>
        /// Gets or sets the tags REST key.
        /// </summary>
        /// <value>The tags REST key.</value>
        string Tags { get; set; }

        /// <summary>
        /// Gets or sets the raw tags REST key.
        /// </summary>
        /// <value>The raw tags REST key.</value>
        string RawTags { get; set; }

        /// <summary>
        /// Gets or sets the page REST key.
        /// </summary>
        /// <value>The page REST key.</value>
        string Page { get; set; }


        IProviderPost PostProvider { get; set; }
    }
}

