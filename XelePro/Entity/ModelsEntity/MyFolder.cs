using System.ComponentModel.DataAnnotations;
using System.IO;

namespace XelePro.Entity.ModelsEntity
{
    public class MyFolder : BaseEntity
    {
        
        public int MyFolderId { get; set; }
        public string? FolderName { get; set; }
        public string path { get; set; }
        public int? ParentFolderId { get; set; }
        public MyFolder? ParentFolder { get; set; }

        public ICollection<MyFile> Files { get; set; }
        public ICollection<MyFolder> SubFolders { get; set; }

    }
}

