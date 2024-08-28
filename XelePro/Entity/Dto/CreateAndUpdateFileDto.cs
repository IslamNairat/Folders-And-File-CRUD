using XelePro.Entity.ModelsEntity;

namespace XelePro.Entity.Dto
{
    public class CreateAndUpdateFileDto 
    {
        public int? MyFolderId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileExtension { get; set; }

    }
}
