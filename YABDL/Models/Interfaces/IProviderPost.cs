using System;

namespace YABDL.Models.Interfaces
{
    public interface IProviderPost
    {
        string Post{get; set;}

        string Id { get; set; }
        string CreatedAt{ get; set; }
        string UploaderId { get; set; }
        string Score { get; set; }
        string Source { get; set;}
        string MD5 { get; set;}
        string LastCommentBumpedAt { get; set;}
        string Rating { get; set;}
        string ImageWidth { get; set; }
        string ImageHeight { get; set; }
        string TagString { get; set;}
        string IsNoteLocked { get; set;}
        string FavCount { get; set; }
        string FileExt { get; set;}
        string LastNotedAt { get; set;}
        string IsRatingLocked{ get; set;}
        string ParentId{ get; set;}
        string HasChildren{ get; set;}
        string ApproverId {get; set;}
        string TagCountGeneral {get; set;}
        string TagCountArtist {get; set;}
        string TagCountCharacter {get; set;}
        string TagCountCopyright {get; set;}
        string FileSize {get; set;}
        string IsStatusLocked {get; set;}
        string FavString {get; set;}
        string PoolString {get; set;}
        string UpScore {get; set;}
        string DownScore {get; set;}
        string IsPending {get; set;}
        string IsFlagged {get; set;}
        string IsDeleted {get; set;}
        string TagCount {get; set;}
        string UpdatedAt { get; set;}
        string IsBanned {get; set;}
        string PixivId { get; set;}
        string LastCommentedAt { get; set;}
        string HasActiveChildren {get; set;}
        string BitFlags { get; set;}
        string UploaderName {get; set;}
        string HasLarge {get; set;}
        string TagStringArtist {get; set;}
        string TagStringCharacter {get; set;}
        string TagStringCopyright {get; set;}
        string TagStringGeneral {get; set;}
        string HasVisibleChildren {get; set;}
        string FileUrl {get; set;}
        string LargeFileUrl {get; set;}
        string PreviewFileUrl {get; set;}
    }
}

