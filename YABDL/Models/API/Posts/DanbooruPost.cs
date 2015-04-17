using System;

namespace YABDL.Models.API.Posts
{
    public class DanbooruPost
    {
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
        public DateTime LastNotedAt { get; set;}
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
    }
}

