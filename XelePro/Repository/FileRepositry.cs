using Microsoft.EntityFrameworkCore;
using XelePro.Context;
using XelePro.Entity.ModelsEntity;
using XelePro.Shared;

namespace XelePro.Repository
{
    public class FileRepositry : BaseRepository<MyFile>, IFileRepositry
    {
        private readonly ApplicationDbContext _ApplicationDbContext;
        public FileRepositry(ApplicationDbContext ApplicationDbContext) : base(ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }

        public async Task<IEnumerable<MyFile>> GetAllFileByFolderId(int folderId)
        {
            return await _ApplicationDbContext.MyFiles.Include(f => f.MyFolder).ThenInclude(s => s.ParentFolderId).Where(x => x.MyFolderId == folderId).ToListAsync();
        }
      
    }
}
