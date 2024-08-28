namespace XelePro.Entity.ModelsEntity
{
    public class MyFile : BaseEntity
    {
        public int MyFileId { get; set; } 
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileExtension { get; set; }
        public int? MyFolderId { get; set; }
        public MyFolder MyFolder { get; set; }
        
    }
}


