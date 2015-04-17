using System;
using System.Collections.Generic;
using YABDL.Models.API.Interfaces;
using System.IO;
using YABDL.Models.Interfaces;
using YABDL.Tools.Extensions;
using System.Xml.Linq;
using System.Linq;
using MoreLinq;

namespace YABDL.Models.API.Posts
{
    public class DanbooruPosts : IAPIDataObject<IProviderPosts>
    {
        public List<DanbooruPost> Posts{ get; set;}

        #region IAPIDataObject implementation

        public void DeserializeFromXML(Stream xml, IProviderPosts metas)
        {
            var document = xml.ToXDocument();
            var dbg = document.Root.Descendants(metas.Post).First();
            var dbg1 = dbg.Descendants(metas.LastCommentBumpedAt).First();
            //var dbg3 = (int)dbg1;

            this.Posts = document.Root.Descendants(metas.Post).Select(x => 
                new DanbooruPost()
                {
                    Id = (int)x.Descendants(metas.Id).First(),
                    CreatedAt = (DateTime)x.Descendants(metas.CreatedAt).First(),
                    UploaderId = (int)x.Descendants(metas.UploaderId).First(),
                    Score = (int)x.Descendants(metas.Score).First(),
                    Source = (string)x.Descendants(metas.Source).First(),
                    MD5 = (string)x.Descendants(metas.MD5).First(),
                    LastCommentBumpedAt = (DateTime?)x.Descendants(metas.LastCommentBumpedAt).First(),
                    Rating = (string)x.Descendants(metas.Rating).First(),
                    ImageWidth = (int)x.Descendants(metas.ImageWidth).First(),
                    ImageHeight = (int)x.Descendants(metas.ImageHeight).First(),
                    TagString = (string)x.Descendants(metas.TagString).First(),
                    IsNoteLocked = (bool)x.Descendants(metas.IsNoteLocked).First(),
                    FavCount = (int)x.Descendants(metas.FavCount).First(),
                    FileExt = (string)x.Descendants(metas.FileExt).First(),
                    LastNotedAt = (DateTime)x.Descendants(metas.LastNotedAt).First(),
                    IsRatingLocked = (bool)x.Descendants(metas.IsRatingLocked).First(),
                    ParentId = (int?)x.Descendants(metas.ParentId).First(),
                    HasChildren = (bool)x.Descendants(metas.HasChildren).First(),
                    ApproverId = (int?)x.Descendants(metas.ApproverId).First(),
                    TagCountGeneral = (int)x.Descendants(metas.TagCountGeneral).First(),
                    TagCountArtist = (int)x.Descendants(metas.TagCountArtist).First(),
                    TagCountCharacter = (int)x.Descendants(metas.TagCountCharacter).First(),
                    TagCountCopyright = (int)x.Descendants(metas.TagCountCopyright).First(),
                    FileSize = (int)x.Descendants(metas.FileSize).First(),
                    IsStatusLocked = (bool)x.Descendants(metas.IsStatusLocked).First(),
                    FavString = (string)x.Descendants(metas.FavString).First(),
                    PoolString = (string)x.Descendants(metas.PoolString).First(),
                    UpScore = (int)x.Descendants(metas.UpScore).First(),
                    DownScore = (int)x.Descendants(metas.DownScore).First(),
                    IsPending = (bool)x.Descendants(metas.IsPending).First(),
                    IsFlagged = (bool)x.Descendants(metas.IsFlagged).First(),
                    IsDeleted = (bool)x.Descendants(metas.IsDeleted).First(),
                    TagCount = (int)x.Descendants(metas.TagCount).First(),
                    UpdatedAt = (DateTime)x.Descendants(metas.UpdatedAt).First(),
                    IsBanned = (bool)x.Descendants(metas.UpdatedAt).First(),
                    PixivId = (int?)x.Descendants(metas.PixivId).First(),
                    LastCommentedAt = (DateTime?)x.Descendants(metas.LastCommentedAt).First(),
                    HasActiveChildren = (bool)x.Descendants(metas.HasActiveChildren).First(),
                    BitFlags = (int?)x.Descendants(metas.BitFlags).First(),
                    UploaderName = (string)x.Descendants(metas.UploaderName).First(),
                    HasLarge = (bool)x.Descendants(metas.HasLarge).First(),
                    TagStringArtist = (string)x.Descendants(metas.TagStringArtist).First(),
                    TagStringCharacter = (string)x.Descendants(metas.TagStringCharacter).First(),
                    TagStringCopyright = (string)x.Descendants(metas.TagStringCopyright).First(),
                    TagStringGeneral = (string)x.Descendants(metas.TagStringGeneral).First(),
                    HasVisibleChildren = (bool)x.Descendants(metas.HasVisibleChildren).First(),
                    FileUrl = (string)x.Descendants(metas.FileUrl).First(),
                    LargeFileUrl = (string)x.Descendants(metas.LargeFileUrl).First(),
                    PreviewFileUrl = (string)x.Descendants(metas.PreviewFileUrl).First()
                }).ToList();
        }

        public Stream SerializeToXML(IProviderPosts restMetatadatasProvider)
        {
            // TODO : Handle serialize into xml, but not now since it's pointless
            throw new NotImplementedException();
        }
            
        #endregion
    }
}

