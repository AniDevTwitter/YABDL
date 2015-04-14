using System;
using System.Xml.Serialization;

namespace YABDL.Models.APIs
{
    [Serializable]
    public class DanbooruPost
    {
        [XmlElement("id")]
        public DanbooruBasicType<int> Id { get; set; }

        [XmlElement("created-at")]
        public DanbooruBasicType<DateTime> CreatedAt;

        [XmlElement("uploader-id")]
        public DanbooruBasicType<int> UploaderId { get; set; }

        [XmlElement("score")]
        public DanbooruBasicType<int> Score { get; set; }

        [XmlElement("source")]
        public DanbooruBasicType<string> Source { get; set;}

        [XmlElement("md5")]
        public DanbooruBasicType<string> MD5 { get; set;}

        [XmlElement("last-comment-bumped-at")]
        public DanbooruBasicType<DateTime?> LastCommentBumpedAt { get; set;}

        [XmlElement("rating")]
        public DanbooruBasicType<string> Rating { get; set;}

        [XmlElement("image-width")]
        public DanbooruBasicType<int> ImageWidth { get; set; }

        [XmlElement("image-height")]
        public DanbooruBasicType<int> ImageHeight { get; set; }

        [XmlElement("tag-string")]
        public DanbooruBasicType<string> TagString { get; set;}

        [XmlElement("is-note-locked")]
        public DanbooruBasicType<bool> IsNoteLocked { get; set;}

        [XmlElement("fav-count")]
        public DanbooruBasicType<int> FavCount { get; set; }

        [XmlElement("file-ext")]
        public DanbooruBasicType<string> FileExt { get; set;}

        [XmlElement("last-noted-at")]
        public DanbooruBasicType<DateTime> LastNotedAt { get; set;}

        [XmlElement("is-rating-locked")]
        public DanbooruBasicType<bool> IsRatingLocked{ get; set;}

        [XmlElement("parent-id")]
        public DanbooruBasicType<int?> ParentId{ get; set;}

        [XmlElement("has-children")]
        public DanbooruBasicType<bool> HasChildren{ get; set;}

        [XmlElement("approver-id")]
        public DanbooruBasicType<int?> ApproverId {get; set;}

        [XmlElement("tag-count-general")]
        public DanbooruBasicType<int> TagCountGeneral {get; set;}

        [XmlElement("tag-count-artist")]
        public DanbooruBasicType<int> TagCountArtist {get; set;}

        [XmlElement("tag-count-character")]
        public DanbooruBasicType<int> TagCountCharacter {get; set;}

        [XmlElement("tag-count-copyright")]
        public DanbooruBasicType<int>TagCountCopyright {get; set;}

        [XmlElement("file-size")]
        public DanbooruBasicType<int> FileSize {get; set;}
       
        [XmlElement("is-status-locked")]
        public DanbooruBasicType<bool> IsStatusLocked {get; set;}

        [XmlElement("fav-string")]
        public DanbooruBasicType<string> FavString {get; set;}

        [XmlElement("pool-string")]
        public DanbooruBasicType<string> PoolString {get; set;}

        [XmlElement("up-score")]
        public DanbooruBasicType<int> UpScore {get; set;}

        [XmlElement("down-score")]
        public DanbooruBasicType<int> DownScore {get; set;}

        [XmlElement("is-pending")]
        public DanbooruBasicType<bool> IsPending {get; set;}

        [XmlElement("is-flagged")]
        public DanbooruBasicType<bool> IsFlagged {get; set;}

        [XmlElement("is-deleted")]
        public DanbooruBasicType<bool> IsDeleted {get; set;}

        [XmlElement("tag-count")]
        public DanbooruBasicType<int> TagCount {get; set;}

        [XmlElement("updated-at")]
        public DanbooruBasicType<DateTime> UpdatedAt { get; set;}

        [XmlElement("is-banned")]
        public DanbooruBasicType<bool> IsBanned {get; set;}

        [XmlElement("pixiv-id")]
        public DanbooruBasicType<int?> PixivId { get; set;}

        [XmlElement("last-commented-at")]
        public DanbooruBasicType<DateTime?> LastCommentedAt { get; set;}

        [XmlElement("has-active-children")]
        public DanbooruBasicType<bool> HasActiveChildren {get; set;}

        [XmlElement("bit-flags")]
        public DanbooruBasicType<int?> BitFlags { get; set;}

        [XmlElement("uploader-name")]
        public DanbooruBasicType<string> UploaderName {get; set;}

        [XmlElement("has-large")]
        public DanbooruBasicType<bool> HasLarge {get; set;}

        [XmlElement("tag-string-artist")]
        public DanbooruBasicType<string> TagStringArtist {get; set;}

        [XmlElement("tag-string-character")]
        public DanbooruBasicType<string> TagStringCharacter {get; set;}

        [XmlElement("tag-string-copyright")]
        public DanbooruBasicType<string> TagStringCopyright {get; set;}

        [XmlElement("tag-string-general")]
        public DanbooruBasicType<string> TagStringGeneral {get; set;}

        [XmlElement("has-visible-children")]
        public DanbooruBasicType<bool> HasVisibleChildren {get; set;}

        [XmlElement("file-url")]
        public DanbooruBasicType<string> FileUrl {get; set;}

        [XmlElement("lage-file-url")]
        public DanbooruBasicType<string> LargeFileUrl {get; set;}

        [XmlElement("preview-file-url")]
        public DanbooruBasicType<string> PreviewFileUrl {get; set;}
    }
}

