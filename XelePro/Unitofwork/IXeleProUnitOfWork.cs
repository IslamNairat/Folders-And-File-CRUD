using XelePro.Context;
using XelePro.Repository;
using XelePro.Shared.Interface;

namespace XelePro.UOWork
{
    public interface IXeleProUnitOfWork : IUOW<ApplicationDbContext>
    {
        IFolderRepositry IFolderRepo { get; }
        IFileRepositry IFileRepo { get; }  
    }
}
