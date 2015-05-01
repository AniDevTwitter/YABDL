using System;
using YABDL.Models.Interfaces;
using System.Collections.Generic;
using YABDL.Tools.Extensions;

namespace YABDL.Models.XML
{
    public class XMLFactory : IFactory
    {

        #region IFactory implementation

        public IProvider NewProvider(string name, string url)
        {
            return new XMLProvider() //Ayyyy wall of code
            {
                Id = Guid.NewGuid(),
                Name = name.ThrowIfNull(),
                Url = url.ThrowIfNull(),
                Limit = @"limit",
                Page = @"page",
                Posts = @"/posts",
                Tags = @"tags",
                RawTags = @"raw",
                PostProvider = new XMLProviderPosts()
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
            };

        }

        public IQuery NewQuery(string name, List<Guid> providersIds, string tags, string outputFolder)
        {
            return new XMLQuery()
            {
                FolderPath = outputFolder.ThrowIfNull(),
                Label = name.ThrowIfNull(),
                Providers = providersIds.ThrowIfNull(),
                Tags = tags.ThrowIfNull(),
            };
        }

        #endregion
    }
}

