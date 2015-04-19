using System;

namespace YABDL.Models.Interfaces
{
    /// <summary>
    /// Represent a booru provider (like danbooru, safebooru etc etc).
    /// </summary>
    public interface IProvider
    {
        /// <summary>
        /// Gets or sets the identifier for this provider (used to bind queries to one/multiple provider).
        /// </summary>
        /// <value>The identifier of this provider.</value>
        Guid Id{get; set;}

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

        /// <summary>
        /// Gets or sets the post node names provider.
        /// </summary>
        /// <value>Posts node names provider.</value>
        IProviderPost PostProvider { get; set; }
    }
}

