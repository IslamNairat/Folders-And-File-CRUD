using XelePro.Entity.ModelsEntity;
using XelePro.Shared.Interface;

namespace XelePro.Repository
{
    public interface IFileRepositry : IBaseRepository<MyFile>
    {
        Task<IEnumerable<MyFile>> GetAllFileByFolderId(int folderId);
        
    }
}
