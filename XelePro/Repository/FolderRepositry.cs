using Microsoft.EntityFrameworkCore;
using XelePro.Context;
using XelePro.Entity.ModelsEntity;
using XelePro.Shared;

namespace XelePro.Repository
{
    public class FolderRepositry : BaseRepository<MyFolder>, IFolderRepositry
    {
        private readonly ApplicationDbContext _ApplicationDbContext;
        public FolderRepositry(ApplicationDbContext ApplicationDbContext) : base(ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }


    }

}
