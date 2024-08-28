using AutoMapper;
using XelePro.core.Entity.Dto;
using XelePro.Entity.Dto;

namespace XelePro.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FileDto, Entity.ModelsEntity.MyFile>().ReverseMap();
            CreateMap<FolderDto, Entity.ModelsEntity.MyFolder>().ReverseMap();
            CreateMap<Entity.ModelsEntity.MyFolder, GetFolderDto>()
            .ForMember(dest => dest.Files, opt => opt.MapFrom(src => src.Files.Select(f => new GetFilesFromFolderDto
            {
               MyFileId = f.MyFileId,
               FileName = f.FileName,
               FilePath = f.FilePath,
               FileExtension = f.FileExtension,
               MyFolderId = f.MyFolderId,
               CreatedOn = f.CreatedOn,
               CreatedBy = f.CreatedBy
               
             }))).ReverseMap();

            CreateMap<GetFileDto, Entity.ModelsEntity.MyFile>().ReverseMap();
            CreateMap<CreateAndUpdateFileDto, Entity.ModelsEntity.MyFile>().ReverseMap();
           
        }
    }
}

