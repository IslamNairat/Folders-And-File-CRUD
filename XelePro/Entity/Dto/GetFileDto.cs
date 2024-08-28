namespace XelePro.Entity.Dto
{
    public class GetFileDto 
    {
        public int MyFileId { get; set; }
        public int? MyFolderId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileExtension { get; set; }


        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedBy { get; set; }

    }
}
