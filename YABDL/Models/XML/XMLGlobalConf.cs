using System;
using YABDL.Models.Interfaces;
using System.IO;
using System.Xml.Serialization;
using YABDL.Tools.XML.Generics;
using System.Collections.Generic;

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
        }

        #region IGlobalConf implementation

        public void Sync()
        {
            // RIP if exception
            XMLFileAccess.Write(this, XMLGlobalConf.GlobalConfPath);
        }


        [XmlElement("AppTitle")]
        public string AppTitle {get; set;}

        [XmlArray("Providers"), XmlArrayItem(typeof(XMLProvider), ElementName = "Provider")]
        public List<IProvider> Providers {get; set; }

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
                    Providers = new List<IProvider>
                        {
                            new XMLProvider()
                            {
                                Name = @"Danbooru",
                                Url = @"danbooru.donmai.us",
                                Limit = @"limit",
                                Page = @"page",
                                Posts = @"/posts",
                                Tags = @"tags",
                                RawTags = @"raw",
                                PostProviderSerial = new XMLProviderPosts()
                                    {
                                        Post = @"po1st",
                                        Id = @"id",
                                        CreatedAt = @"created-at",
                                        UploaderId = @"uploader-id",
                                        Score = @"score",
                                        Source = @"source",
                                        MD5 = @"md5",
                                        LastCommentBumpedAt = @"last-comment-bumped-at",
                                        Rating = @"rating",
                                        ImageWidth = @"image-width",
                                        ImageHeight = @"image-height",
                                        TagString = @"tag-string",
                                        IsNoteLocked = @"is-note-locked",
                                        FavCount = @"fav-count",
                                        FileExt = @"file-ext",
                                        LastNotedAt = @"last-noted-at",
                                        IsRatingLocked = @"is-rating-locked",
                                        ParentId = @"parent-id",
                                        HasChildren = @"has-children",
                                        ApproverId = @"approver-id",
                                        TagCountGeneral = @"tag-count-general",
                                        TagCountArtist = @"tag-count-artist",
                                        TagCountCharacter = @"tag-count-character",
                                        TagCountCopyright = @"tag-count-copyright",
                                        FileSize = @"file-size",
                                        IsStatusLocked = @"is-status-locked",
                                        FavString = @"fav-string",
                                        PoolString = @"pool-string",
                                        UpScore = @"up-score",
                                        DownScore = @"down-score",
                                        IsPending = @"is-pending",
                                        IsFlagged = @"is-flagged",
                                        IsDeleted = @"is-deleted",
                                        TagCount = @"tag-count",
                                        UpdatedAt = @"updated-at",
                                        IsBanned = @"is-banned",
                                        PixivId = @"pixiv-id",
                                        LastCommentedAt = @"last-commented-at",
                                        HasActiveChildren = @"has-active-children",
                                        BitFlags = @"bit-flags",
                                        UploaderName = @"uploader-name",
                                        HasLarge = @"has-large",
                                        TagStringArtist = @"tag-string-artist",
                                        TagStringCharacter = @"tag-string-character",
                                        TagStringCopyright = @"tag-string-copyright",
                                        TagStringGeneral = @"tag-string-general",
                                        HasVisibleChildren = @"has-visible-children",
                                        FileUrl = @"file-url",
                                        LargeFileUrl = @"large-file-url",
                                        PreviewFileUrl = @"preview-file-url"
                                    }
                            }
                        }
                };
            retVal.Sync();
            return retVal;
        }
    }
}

