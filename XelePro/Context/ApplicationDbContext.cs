using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using XelePro.core.Entity.Dto;
using XelePro.Entity.ModelsEntity;

namespace XelePro.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
        }

        public DbSet<MyFolder> MyFolders { get; set; }
        public DbSet<MyFile> MyFiles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MyFolder>().HasData(
            new MyFolder { MyFolderId = 1, FolderName = "Folder1", path = "C:Users-Xele-Desktop-Folder1", ParentFolderId = 1, CreatedOn = DateTime.Now, CreatedBy = "USER ADMIN", UpdatedOn = null , UpdatedBy = null, Isdeleted = false },
            new MyFolder { MyFolderId = 2, FolderName = "Folder2", path = "C:Users-Xele-Desktop-Folder2", ParentFolderId = 2, CreatedOn = DateTime.Now, CreatedBy = "USER ADMIN", UpdatedOn = null , UpdatedBy = null, Isdeleted = false },
            new MyFolder { MyFolderId = 3, FolderName = "Folder3", path = "C:Users-Xele-Desktop-Folder3", ParentFolderId = 2, CreatedOn = DateTime.Now, CreatedBy = "USER ADMIN", UpdatedOn = null , UpdatedBy = null, Isdeleted = false },
            new MyFolder { MyFolderId = 4, FolderName = "Folder4", path = "C:Users-Xele-Desktop-Folder4", ParentFolderId = 3, CreatedOn = DateTime.Now, CreatedBy = "USER ADMIN", UpdatedOn = null , UpdatedBy = null, Isdeleted = false },
            new MyFolder { MyFolderId = 5, FolderName = "Folder5", path = "C:Users-Xele-Desktop-Folder5", ParentFolderId = 4, CreatedOn = DateTime.Now, CreatedBy = "USER ADMIN", UpdatedOn = null , UpdatedBy = null, Isdeleted = false },
            new MyFolder { MyFolderId = 6, FolderName = "Folder6", path = "C:Users-Xele-Desktop-Folder6", ParentFolderId = 4, CreatedOn = DateTime.Now, CreatedBy = "USER ADMIN", UpdatedOn = null , UpdatedBy = null, Isdeleted = false }
            );


            modelBuilder.Entity<MyFile>().HasData(

            new MyFile { MyFileId = 1, MyFolderId = 1, FileName = "FileName1", FilePath = "C:Users-Xele-Desktop-Folder1-FileName1", FileExtension = "txt",  CreatedOn = DateTime.Now, CreatedBy = "USER ADMIN", UpdatedOn = null , UpdatedBy = null, Isdeleted = false },
            new MyFile { MyFileId = 2, MyFolderId = 2, FileName = "FileName2", FilePath = "C:Users-Xele-Desktop-Folder2-FileName2", FileExtension = "PDF",  CreatedOn = DateTime.Now, CreatedBy = "USER ADMIN", UpdatedOn = null , UpdatedBy = null, Isdeleted = false },
            new MyFile { MyFileId = 3, MyFolderId = 3, FileName = "FileName3", FilePath = "C:Users-Xele-Desktop-Folder3-FileName3", FileExtension = "DOCX", CreatedOn = DateTime.Now, CreatedBy = "USER ADMIN", UpdatedOn = null , UpdatedBy = null, Isdeleted = false },
            new MyFile { MyFileId = 4, MyFolderId = 4, FileName = "FileName4", FilePath = "C:Users-Xele-Desktop-Folder4-FileName4", FileExtension = "JPG",  CreatedOn = DateTime.Now, CreatedBy = "USER ADMIN", UpdatedOn = null , UpdatedBy = null, Isdeleted = false },
            new MyFile { MyFileId = 5, MyFolderId = 5, FileName = "FileName5", FilePath = "C:Users-Xele-Desktop-Folder5-FileName5", FileExtension = "XLSX", CreatedOn = DateTime.Now, CreatedBy = "USER ADMIN", UpdatedOn = null , UpdatedBy = null, Isdeleted = false },
            new MyFile { MyFileId = 6, MyFolderId = 6, FileName = "FileName6", FilePath = "C:Users-Xele-Desktop-Folder6-FileName6", FileExtension = "PNG",  CreatedOn = DateTime.Now, CreatedBy = "USER ADMIN", UpdatedOn = null , UpdatedBy = null, Isdeleted = false }
            );
        }
    }

}

