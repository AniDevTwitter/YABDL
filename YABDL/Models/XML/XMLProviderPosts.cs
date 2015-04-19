using System;
using YABDL.Models.Interfaces;
using System.Xml.Serialization;

namespace YABDL.Models.XML
{
    [Serializable]
    public class XMLProviderPosts : IProviderPost
    {

        #region IProviderPosts implementation

        [XmlElement("Posts")]
        public string Post{get;set;}

        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("created-at")]
        public string CreatedAt { get; set;}

        [XmlElement("uploader-id")]
        public string UploaderId { get; set; }

        [XmlElement("score")]
        public string Score { get; set; }

        [XmlElement("source")]
        public string Source { get; set;}

        [XmlElement("md5")]
        public string MD5 { get; set;}

        [XmlElement("last-comment-bumped-at")]
        public string LastCommentBumpedAt { get; set;}

        [XmlElement("rating")]
        public string Rating { get; set;}

        [XmlElement("image-width")]
        public string ImageWidth { get; set; }

        [XmlElement("image-height")]
        public string ImageHeight { get; set; }

        [XmlElement("tag-string")]
        public string TagString { get; set;}

        [XmlElement("is-note-locked")]
        public string IsNoteLocked { get; set;}

        [XmlElement("fav-count")]
        public string FavCount { get; set; }

        [XmlElement("file-ext")]
        public string FileExt { get; set;}

        [XmlElement("last-noted-at")]
        public string LastNotedAt { get; set;}

        [XmlElement("is-rating-locked")]
        public string IsRatingLocked{ get; set;}

        [XmlElement("parent-id")]
        public string ParentId{ get; set;}

        [XmlElement("has-children")]
        public string HasChildren{ get; set;}

        [XmlElement("approver-id")]
        public string ApproverId {get; set;}

        [XmlElement("tag-count-general")]
        public string TagCountGeneral {get; set;}

        [XmlElement("tag-count-artist")]
        public string TagCountArtist {get; set;}

        [XmlElement("tag-count-character")]
        public string TagCountCharacter {get; set;}

        [XmlElement("tag-count-copyright")]
        public string TagCountCopyright {get; set;}

        [XmlElement("file-size")]
        public string FileSize {get; set;}

        [XmlElement("is-status-locked")]
        public string IsStatusLocked {get; set;}

        [XmlElement("fav-string")]
        public string FavString {get; set;}

        [XmlElement("pool-string")]
        public string PoolString {get; set;}

        [XmlElement("up-score")]
        public string UpScore {get; set;}

        [XmlElement("down-score")]
        public string DownScore {get; set;}

        [XmlElement("is-pending")]
        public string IsPending {get; set;}

        [XmlElement("is-flagged")]
        public string IsFlagged {get; set;}

        [XmlElement("is-deleted")]
        public string IsDeleted {get; set;}

        [XmlElement("tag-count")]
        public string TagCount {get; set;}

        [XmlElement("updated-at")]
        public string UpdatedAt { get; set;}

        [XmlElement("is-banned")]
        public string IsBanned {get; set;}

        [XmlElement("pixiv-id")]
        public string PixivId { get; set;}

        [XmlElement("last-commented-at")]
        public string LastCommentedAt { get; set;}

        [XmlElement("has-active-children")]
        public string HasActiveChildren {get; set;}

        [XmlElement("bit-flags")]
        public string BitFlags { get; set;}

        [XmlElement("uploader-name")]
        public string UploaderName {get; set;}

        [XmlElement("has-large")]
        public string HasLarge {get; set;}

        [XmlElement("tag-string-artist")]
        public string TagStringArtist {get; set;}

        [XmlElement("tag-string-character")]
        public string TagStringCharacter {get; set;}

        [XmlElement("tag-string-copyright")]
        public string TagStringCopyright {get; set;}

        [XmlElement("tag-string-general")]
        public string TagStringGeneral {get; set;}

        [XmlElement("has-visible-children")]
        public string HasVisibleChildren {get; set;}

        [XmlElement("file-url")]
        public string FileUrl {get; set;}

        [XmlElement("large-file-url")]
        public string LargeFileUrl {get; set;}

        [XmlElement("preview-file-url")]
        public string PreviewFileUrl {get; set;}

        #endregion
    }
}

