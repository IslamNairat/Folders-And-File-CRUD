using XelePro.Shared.Pagination;
using XelePro.core.Entity.Dto;
using XelePro.Entity.ModelsEntity;
using XelePro.Shared.Interface;
using Microsoft.AspNetCore.Mvc;
using XelePro.Entity.Dto;
namespace XelePro.Services
{
    public interface IFilesService
    {
        Task<PaginationDto<FileDto>> GetAllFiles(string? search, int pageIndex, int pageSize);
        Task<CreateAndUpdateFileDto> CreateFile(CreateAndUpdateFileDto dto);
        Task<GetFileDto> GetFileById(int fileId);
        Task<bool> DeleteFile(int fileId);
        Task<CreateAndUpdateFileDto> UpdateFile(CreateAndUpdateFileDto dto, int fileId);
        Task<List<FileDto>> GetAllFilesByFolderId(int folderId);

    }
}
