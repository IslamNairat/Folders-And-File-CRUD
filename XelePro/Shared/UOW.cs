using Microsoft.EntityFrameworkCore;
using XelePro.Context;
using XelePro.Shared.Interface;

namespace XelePro.Shared
{
    public class UOW<TContext> : IUOW<TContext> where TContext : DbContext
    {
        public  ApplicationDbContext _context;

        public UOW(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
