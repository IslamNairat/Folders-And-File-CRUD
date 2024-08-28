using Microsoft.EntityFrameworkCore;
using XelePro.Context;
using XelePro.Repository;
using XelePro.Shared;
using XelePro.Shared.Interface;


namespace XelePro.UOWork
{
    public class XeleProUnitOfWork : UOW<ApplicationDbContext>, IXeleProUnitOfWork
    {
        public XeleProUnitOfWork(ApplicationDbContext context) :
         base(context)
        {
            _context = context;
            IFolderRepo = new FolderRepositry(_context);
            IFileRepo = new FileRepositry(_context);
        }
        public IFolderRepositry IFolderRepo { get; }
        public IFileRepositry IFileRepo { get; }

    }
}
