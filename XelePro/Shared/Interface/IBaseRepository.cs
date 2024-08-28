using Microsoft.EntityFrameworkCore.Query;
using NPOI.SS.Formula.Functions;
using System.Linq.Expressions;
using XelePro.core.Entity.Dto;
using XelePro.Entity.ModelsEntity;
using XelePro.Shared.Pagination;

namespace XelePro.Shared.Interface
{
    public interface IBaseRepository<TEntity>
    {
        Task AddAsync(TEntity objModel);
        void AddRange(IEnumerable<TEntity> objModel);
        TEntity? GetById(int id);
        Task<TEntity?>GetByIdAsync(int id);
        Task<MyFolder> GetByIdAsync(int folderId, bool includeRelated = false);
        Task<TEntity?> Get(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        int Count();
        Task<int> CountAsync();
        void Update(TEntity objModel);
        void Remove(TEntity objModel);
        Task<PaginationDto<TEntity>> GetPagination(Expression<Func<TEntity, bool>> predicate = null,
        int? pageIndex = 1,
        int? pageSize = 10,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null);

    }
}
