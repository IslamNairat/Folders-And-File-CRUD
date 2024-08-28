using AutoMapper;
using Org.BouncyCastle.Asn1.X509;
using System.Linq;
using XelePro.core.Entity.Dto;
using XelePro.Entity.Dto;
using XelePro.Entity.ModelsEntity;
using XelePro.Repository;
using XelePro.Shared.Pagination;
using XelePro.UOWork;

namespace XelePro.Services
{
    public class FilesService : IFilesService
    {
        private readonly IFileRepositry _fileRepositry;
        private readonly IMapper _mapper;
        private IXeleProUnitOfWork _uOW;
        public FilesService(IFileRepositry fileRepositry, IMapper mapper, IXeleProUnitOfWork uOW)
        {
            _fileRepositry = fileRepositry;
            _mapper = mapper;
            _uOW = uOW;
        }

        public async Task<CreateAndUpdateFileDto> CreateFile(CreateAndUpdateFileDto dto)
        {
            var file = _mapper.Map<MyFile>(dto);
            file.CreatedOn = DateTime.Now;
            file.CreatedBy = "USER ADMIN";
            await _uOW.IFileRepo.AddAsync(file);
            await _uOW.CommitAsync();

            return _mapper.Map<CreateAndUpdateFileDto>(file);
        }


        public async Task<PaginationDto<FileDto>> GetAllFiles(string? search, int pageIndex, int pageSize )
        {
            var result = (await _uOW.IFileRepo
                .GetPagination(x => !x.Isdeleted && (string.IsNullOrEmpty(search) || x.FileName.Contains(search)), pageIndex: pageIndex, pageSize: pageSize, orderBy: o => o.OrderByDescending(x => x.MyFileId)));

            return new PaginationDto<FileDto>
            {
                Result = _mapper.Map<List<FileDto>>(result.Result),
                Total = result.Total,
            };
        }

        public async Task<GetFileDto> GetFileById(int fileId)
        {
            var file = await _uOW.IFileRepo.Get(f => f.MyFileId == fileId && f.Isdeleted == false)
                ?? throw new Exception("Id Not Found");
            return _mapper.Map<GetFileDto>(file);

        }

        public async Task<CreateAndUpdateFileDto> UpdateFile(CreateAndUpdateFileDto dto, int fileId)
        {

            var file = _uOW.IFileRepo.GetById(fileId);
            _mapper.Map(dto, file);
            file.UpdatedOn = DateTime.Now;
            file.UpdatedBy = "USER ADMIN";

            _uOW.IFileRepo.Update(file);
            await _uOW.CommitAsync();
            return _mapper.Map<CreateAndUpdateFileDto>(dto);
        }

        


        public async Task<List<FileDto>> GetAllFilesByFolderId(int folderId)
        {

            var files = await _uOW.IFileRepo.GetListAsync(a => a.MyFolderId == folderId);

            if (files == null || !files.Any())
                return new List<FileDto>();

            return _mapper.Map<List<FileDto>>(files);

        }

        public async Task<bool> DeleteFile(int fileId)
        {
            var file = _uOW.IFileRepo.GetById(fileId)
             ?? throw new Exception("Id not Found");


            file.Isdeleted = true;
            file.UpdatedOn = DateTime.Now;
            file.UpdatedBy = "USER ADMIN";

            _uOW.IFileRepo.Update(file);
            await _uOW.CommitAsync();

            return true;

        }
    }

}
