namespace XelePro.Entity.Dto
{
    public class GetAllFolderDto
    {
        public string? Search { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 4;
    }
}
