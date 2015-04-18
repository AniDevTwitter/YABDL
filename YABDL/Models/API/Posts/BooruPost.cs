using System;
using YABDL.Models.API.Interfaces;
using YABDL.Models.Interfaces;
using System.IO;
using YABDL.Tools.Extensions;
using System.Linq;
using System.Xml.Linq;

namespace YABDL.Models.API.Posts
{
    public class BooruPost  : IAPIDataObject<IProviderPosts>
    {
        public void DeserializeFromXML(XElement post, IProviderPosts metas)
        {
            this.Id = (int)post.Descendants(metas.Id).First();
            this.CreatedAt = (DateTime)post.Descendants(metas.CreatedAt).First();
            this.UploaderId = (int)post.Descendants(metas.UploaderId).First();
            this.Score = (int)post.Descendants(metas.Score).First();
            this.Source = (string)post.Descendants(metas.Source).First();
            this.MD5 = (string)post.Descendants(metas.MD5).First();
            this.LastCommentBumpedAt = post.Descendants(metas.LastCommentBumpedAt).First().NullIfEmpty<DateTime>();
            this.Rating = (string)post.Descendants(metas.Rating).First();
            this.ImageWidth = (int)post.Descendants(metas.ImageWidth).First();
            this.ImageHeight = (int)post.Descendants(metas.ImageHeight).First();
            this.TagString = (string)post.Descendants(metas.TagString).First();
            this.IsNoteLocked = (bool)post.Descendants(metas.IsNoteLocked).First();
            this.FavCount = (int)post.Descendants(metas.FavCount).First();
            this.FileExt = (string)post.Descendants(metas.FileExt).First();
            this.LastNotedAt = post.Descendants(metas.LastNotedAt).First().NullIfEmpty<DateTime>();
            this.IsRatingLocked = (bool)post.Descendants(metas.IsRatingLocked).First();
            this.ParentId = post.Descendants(metas.ParentId).First().NullIfEmpty<int>();
            this.HasChildren = (bool)post.Descendants(metas.HasChildren).First();
            this.ApproverId = post.Descendants(metas.ApproverId).First().NullIfEmpty<int>();
            this.TagCountGeneral = (int)post.Descendants(metas.TagCountGeneral).First();
            this.TagCountArtist = (int)post.Descendants(metas.TagCountArtist).First();
            this.TagCountCharacter = (int)post.Descendants(metas.TagCountCharacter).First();
            this.TagCountCopyright = (int)post.Descendants(metas.TagCountCopyright).First();
            this.FileSize = (int)post.Descendants(metas.FileSize).First();
            this.IsStatusLocked = (bool)post.Descendants(metas.IsStatusLocked).First();
            this.FavString = (string)post.Descendants(metas.FavString).First();
            this.PoolString = (string)post.Descendants(metas.PoolString).First();
            this.UpScore = (int)post.Descendants(metas.UpScore).First();
            this.DownScore = (int)post.Descendants(metas.DownScore).First();
            this.IsPending = (bool)post.Descendants(metas.IsPending).First();
            this.IsFlagged = (bool)post.Descendants(metas.IsFlagged).First();
            this.IsDeleted = (bool)post.Descendants(metas.IsDeleted).First();
            this.TagCount = (int)post.Descendants(metas.TagCount).First();
            this.UpdatedAt = (DateTime)post.Descendants(metas.UpdatedAt).First();
            this.IsBanned = (bool)post.Descendants(metas.IsBanned).First();
            this.PixivId = post.Descendants(metas.PixivId).First().NullIfEmpty<int>();
            this.LastCommentedAt = post.Descendants(metas.LastCommentedAt).First().NullIfEmpty<DateTime>();
            this.HasActiveChildren = (bool)post.Descendants(metas.HasActiveChildren).First();
            this.BitFlags = post.Descendants(metas.BitFlags).First().NullIfEmpty<int>();
            this.UploaderName = (string)post.Descendants(metas.UploaderName).First();
            this.HasLarge = (bool)post.Descendants(metas.HasLarge).First();
            this.TagStringArtist = (string)post.Descendants(metas.TagStringArtist).First();
            this.TagStringCharacter = (string)post.Descendants(metas.TagStringCharacter).First();
            this.TagStringCopyright = (string)post.Descendants(metas.TagStringCopyright).First();
            this.TagStringGeneral = (string)post.Descendants(metas.TagStringGeneral).First();
            this.HasVisibleChildren = (bool)post.Descendants(metas.HasVisibleChildren).First();
            this.FileUrl = (string)post.Descendants(metas.FileUrl).First();
            this.LargeFileUrl = (string)post.Descendants(metas.LargeFileUrl).First();
            this.PreviewFileUrl = (string)post.Descendants(metas.PreviewFileUrl).First();
        }

        #region IAPIDataObject implementation

        public void DeserializeFromXML(Stream xml, IProviderPosts metas)
        {
            this.DeserializeFromXML(xml.ToXDocument().Root, metas);
        }

        public Stream SerializeToXML(IProviderPosts restMetatadatasProvider)
        {
            // TODO : Handle serialize into xml, but not now since it's pointless
            throw new NotImplementedException();
        }

        #endregion


        #region Fields

        public int Id { get; set; }
        public DateTime CreatedAt;
        public int UploaderId { get; set; }
        public int Score { get; set; }
        public string Source { get; set;}
        public string MD5 { get; set;}
        public DateTime? LastCommentBumpedAt { get; set;}
        public string Rating { get; set;}
        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }
        public string TagString { get; set;}
        public bool IsNoteLocked { get; set;}
        public int FavCount { get; set; }
        public string FileExt { get; set;}
        public DateTime? LastNotedAt { get; set;}
        public bool IsRatingLocked{ get; set;}
        public int? ParentId{ get; set;}
        public bool HasChildren{ get; set;}
        public int? ApproverId {get; set;}
        public int TagCountGeneral {get; set;}
        public int TagCountArtist {get; set;}
        public int TagCountCharacter {get; set;}
        public int TagCountCopyright {get; set;}
        public int FileSize {get; set;}
        public bool IsStatusLocked {get; set;}
        public string FavString {get; set;}
        public string PoolString {get; set;}
        public int UpScore {get; set;}
        public int DownScore {get; set;}
        public bool IsPending {get; set;}
        public bool IsFlagged {get; set;}
        public bool IsDeleted {get; set;}
        public int TagCount {get; set;}
        public DateTime UpdatedAt { get; set;}
        public bool IsBanned {get; set;}
        public int? PixivId { get; set;}
        public DateTime? LastCommentedAt { get; set;}
        public bool HasActiveChildren {get; set;}
        public int? BitFlags { get; set;}
        public string UploaderName {get; set;}
        public bool HasLarge {get; set;}
        public string TagStringArtist {get; set;}
        public string TagStringCharacter {get; set;}
        public string TagStringCopyright {get; set;}
        public string TagStringGeneral {get; set;}
        public bool HasVisibleChildren {get; set;}
        public string FileUrl {get; set;}
        public string LargeFileUrl {get; set;}
        public string PreviewFileUrl {get; set;}

        #endregion Fields
    }
}

