using Microsoft.AspNetCore.Mvc;
using XelePro.core.Entity.Dto;
using XelePro.Entity.Dto;
using XelePro.Entity.ModelsEntity;
using XelePro.Services;

namespace XelePro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {

        private readonly IFilesService _filesService;

        public FilesController(IFilesService filesService)
        {
            _filesService = filesService;
        }

        [HttpGet("GetAllFiles")]
        public async Task<IActionResult> GetAllFiles(string? search, int? pageIndex, int? pageSize)
        {
            var currentPageIndex = pageIndex ?? 1;
            var currentPageSize = pageSize ?? 10;

            var myfile = await _filesService.GetAllFiles(search, currentPageIndex, currentPageSize);
            return Ok(myfile);
        }

        [HttpGet("GetFileById/{id}")]
        public async Task<IActionResult> GetFileById(int id)
        {
            var myfile = await _filesService.GetFileById(id);
            return Ok(myfile);
        }

        [HttpPost("CreateFile")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateAndUpdateFileDto dto)
        {
            await _filesService.CreateFile(dto);
            return Ok(dto);
        }

        [HttpPut("UpdateFile")]
        public async Task<IActionResult> UpdateFile([FromBody] CreateAndUpdateFileDto dto, int fileId)
        {
            await _filesService.UpdateFile(dto, fileId);
            return Ok(fileId);
        }

        [HttpDelete("DeleteFile/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _filesService.DeleteFile(id));
        }

        [HttpGet("GetAllFileByFolderId/{folderId}")]
        public async Task<IActionResult> GetAllFileByFolderId(int folderId)
        {
            return Ok(await _filesService.GetAllFilesByFolderId(folderId));
        }

    }

}
