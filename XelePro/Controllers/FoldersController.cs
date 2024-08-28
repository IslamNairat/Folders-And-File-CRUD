using Microsoft.AspNetCore.Mvc;
using XelePro.core.Entity.Dto;
using XelePro.Entity.Dto;
using XelePro.Services;

namespace XelePro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoldersController : ControllerBase
    {
        private readonly IFoldersService _foldersService;

        public FoldersController(IFoldersService foldersService)
        {
            _foldersService = foldersService;

        }

        [HttpGet("GetAllFolder")]
        public async Task<IActionResult> GetAllFolder(string? search, int? pageIndex, int? pageSize)
        {
            var currentPageIndex = pageIndex ?? 1;
            var currentPageSize = pageSize ?? 10;

            var myfolders = await _foldersService.GetAllFolder(search, currentPageIndex, currentPageSize);
            return Ok(myfolders);
        }

        [HttpPost("CreateFolder")]
        public async Task<IActionResult> CreateFolder([FromBody] FolderDto dto)
        {
            await _foldersService.CreateFolder(dto);
            return Ok(dto);

        }

        [HttpGet("GetFolderByFolderId/{id}")]
        public async Task<IActionResult> GetFolderByFolderId(int id)
        {
            return Ok(await _foldersService.GetFolderByFolderId(id));
        }

        [HttpDelete("DeleteFolder/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _foldersService.DeleteFolder(id));
        }
        

        [HttpPut("UpdateFolder")]
        public async Task<IActionResult> UpdateFolder([FromBody] FolderDto dto, int folderId)
        {
            return Ok(await _foldersService.UpdateFolder(dto, folderId));
        }
    }
}
