using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509;
using XelePro.Context;
using XelePro.core.Entity.Dto;
using XelePro.Entity.Dto;
using XelePro.Entity.ModelsEntity;
using XelePro.Repository;
using XelePro.Shared.Pagination;
using XelePro.UOWork;

namespace XelePro.Services
{
    public class FoldersService : IFoldersService
    {
        private readonly ApplicationDbContext _context;
        private readonly IFolderRepositry _folderRepositry;
        private readonly IMapper _mapper;
        private IXeleProUnitOfWork _uOW;
        public FoldersService(IFolderRepositry folderRepositry, IMapper mapper, IXeleProUnitOfWork uOW, ApplicationDbContext context)
        {
            _folderRepositry = folderRepositry;
            _mapper = mapper;
            _context = context;
            _uOW = uOW;
        }

        public async Task<int> CreateFolder(FolderDto dto)
        {
            var folder = _mapper.Map<MyFolder>(dto);

            folder.CreatedOn = DateTime.Now;
            folder.CreatedBy = "USER ADMIN";

            await _uOW.IFolderRepo.AddAsync(folder);
            await _uOW.CommitAsync();

            return folder.MyFolderId;
        }

        public async Task<bool> DeleteFolder(int folderId)
        {
            var folder = await _context.MyFolders
                .Where(f => !f.Isdeleted && f.MyFolderId == folderId)
                .Include(f => f.Files)
                .Include(f => f.SubFolders).ThenInclude(f => f.Files)
                .FirstOrDefaultAsync();

            if (folder == null)
            {
                throw new Exception("Folder not found");
            }

            
            await DeleteFolderAndContentsAsync(folder);

            await _context.SaveChangesAsync();

            return true;
        }

        private async Task DeleteFolderAndContentsAsync(MyFolder folder)
        {
            if (folder.SubFolders != null)
            {
                foreach (var subFolder in folder.SubFolders.ToList())
                {
                    await DeleteFolderAndContentsAsync(subFolder);
                }
            }


            if (folder.Files != null)
            {
                foreach (var file in folder.Files.ToList())
                {
                    file.Isdeleted = true;
                    _context.MyFiles.Update(file);
                }
            }


            folder.Isdeleted = true;
            _context.MyFolders.Update(folder);
        }


        public async Task<GetFolderDto> UpdateFolder(FolderDto dto, int folderId)
        {
            var folder = _uOW.IFolderRepo.GetById(folderId)
                ?? throw new Exception("Id Not Found");

            _mapper.Map(dto, folder);
            folder.UpdatedOn = DateTime.Now;
            folder.UpdatedBy = "USER ADMIN";
            await _uOW.CommitAsync();
            return _mapper.Map<GetFolderDto>(folder);
        }

        public async Task<PaginationDto<FolderDto>> GetAllFolder(string? search, int pageIndex, int pageSize)
        {
          
            var result = (await _uOW.IFolderRepo
                .GetPagination(x => !x.Isdeleted && (string.IsNullOrEmpty(search) || x.FolderName.Contains(search)), pageIndex: pageIndex, pageSize: pageSize, orderBy: o => o.OrderByDescending(x => x.MyFolderId)));

            return new PaginationDto<FolderDto>
            {
                Result = _mapper.Map<List<FolderDto>>(result.Result),
                Total = result.Total,
            };
        }


        public async Task<GetFolderDto> GetFolderByFolderId(int folderId)
        {

            var folder = await _uOW.IFolderRepo.GetByIdAsync(folderId, includeRelated: true)
                        ?? throw new Exception("Id not Found");

            return _mapper.Map<GetFolderDto>(folder);
        }


    }


}

