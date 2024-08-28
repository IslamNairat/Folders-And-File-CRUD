using Microsoft.EntityFrameworkCore;

namespace XelePro.Shared.Interface
{
    public interface IUOW<T> where T : DbContext, IDisposable
    {
        Task CommitAsync();

    }
}
