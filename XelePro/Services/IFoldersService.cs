using Microsoft.AspNetCore.Mvc;
using XelePro.core.Entity.Dto;
using XelePro.Entity.Dto;
using XelePro.Entity.ModelsEntity;
using XelePro.Shared.Pagination;

namespace XelePro.Services
{
    public interface IFoldersService
    {
        Task<int> CreateFolder(FolderDto dto);
        Task<GetFolderDto> UpdateFolder(FolderDto dto, int folderId);
        Task<PaginationDto<FolderDto>> GetAllFolder(string? search, int pageIndex, int pageSize);
        Task<GetFolderDto> GetFolderByFolderId(int folderId);
        Task<bool> DeleteFolder(int folderId);
    }
}
