using System;
using System.Xml.Serialization;

namespace YABDL.Models.APIs
{
    [Serializable]
    public class DanbooruPost
    {
        public DanbooruPost()
        {
        }

        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("created-at")]
        public DateTime CreatedAt;

        [XmlElement("uploader-id")]
        public int UploaderId { get; set; }

        [XmlElement("score")]
        public int Score { get; set; }

        [XmlElement("source")]
        public string Source { get; set;}

        [XmlElement("md5")]
        public string MD5 { get; set;}

        [XmlElement("last-comment-bumped-at")]
        public DateTime? LastCommentBumpedAt { get; set;}

        [XmlElement("rating")]
        public string Rating { get; set;}

        [XmlElement("image-width")]
        public int ImageWidth { get; set; }

        [XmlElement("image-height")]
        public int ImageHeight { get; set; }

        [XmlElement("tag-string")]
        public string TagString { get; set;}

        [XmlElement("is-note-locked")]
        public bool IsNoteLocked { get; set;}

        [XmlElement("fav-count")]
        public int FavCount { get; set; }

        [XmlElement("file-ext")]
        public string FileExt { get; set;}

        [XmlElement("last-noted-at")]
        public DateTime LastNotedAt { get; set;}

        [XmlElement("is-rating-locked")]
        public bool IsRatingLocked{ get; set;}

        [XmlElement("parent-id")]
        public int? ParentId{ get; set;}

        [XmlElement("has-children")]
        public bool HasChildren{ get; set;}

        [XmlElement("approver-id")]
        public int? ApproverId {get; set;}

        [XmlElement("tag-count-general")]
        public int TagCountGeneral {get; set;}

        [XmlElement("tag-count-artist")]
        public int TagCountArtist {get; set;}

        [XmlElement("tag-count-character")]
        public int TagCountCharacter {get; set;}

        [XmlElement("tag-count-copyright")]
        public int TagCountCopyright {get; set;}

        [XmlElement("file-size")]
        public int FileSize {get; set;}
       
        [XmlElement("is-status-locked")]
        public bool IsStatusLocked {get; set;}

        [XmlElement("fav-string")]
        public string FavString {get; set;}

        [XmlElement("pool-string")]
        public string PoolString {get; set;}

        [XmlElement("up-score")]
        public int UpScore {get; set;}

        [XmlElement("down-score")]
        public int DownScore {get; set;}

        [XmlElement("is-pending")]
        public bool IsPending {get; set;}

        [XmlElement("is-flagged")]
        public bool IsFlagged {get; set;}

        [XmlElement("is-deleted")]
        public bool IsDeleted {get; set;}

        [XmlElement("tag-count")]
        public int TagCount {get; set;}

        [XmlElement("updated-at")]
        public DateTime UpdatedAt { get; set;}

        [XmlElement("is-banned")]
        public bool IsBanned {get; set;}

        [XmlElement("pixiv-id")]
        public int? PixivId { get; set;}

        [XmlElement("last-commented-at")]
        public DateTime? LastCommentedAt { get; set;}

        [XmlElement("has-active-children")]
        public bool HasActiveChildren {get; set;}

        [XmlElement("bit-flags")]
        public int? BitFlags { get; set;}

        [XmlElement("uploader-name")]
        public string UploaderName {get; set;}

        [XmlElement("has-large")]
        public bool HasLarge {get; set;}

        [XmlElement("tag-string-artist")]
        public string TagStringArtist {get; set;}

        [XmlElement("tag-string-character")]
        public string TagStringCharacter {get; set;}

        [XmlElement("tag-string-copyright")]
        public string TagStringCopyright {get; set;}

        [XmlElement("tag-string-general")]
        public string TagStringGeneral {get; set;}

        [XmlElement("has-visible-children")]
        public bool HasVisibleChildren {get; set;}

        [XmlElement("file-url")]
        public string FileUrl {get; set;}

        [XmlElement("lage-file-url")]
        public string LargeFileUrl {get; set;}

        [XmlElement("preview-file-url")]
        public string PreviewFileUrl {get; set;}
    }
}

