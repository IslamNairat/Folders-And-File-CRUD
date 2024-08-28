namespace XelePro.Entity.Dto
{
    public class GetFolderDto
    {
        public int MyFolderId { get; set; }
        public string? FolderName { get; set; }
        public string path { get; set; }
        public int? ParentFolderId { get; set; }

        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public ICollection<GetFilesFromFolderDto> Files { get; set; }
    }
}
