namespace XelePro
{
    public class NotFoundException : Exception
    {
        public NotFoundException(int folderId, string folderName)
            : base($"No files found for folder with ID: {folderId} and Name : {folderName}")
        {
        }

        public NotFoundException(int Id)
            : base($"Id Not found: {Id}")
        {
        }
    }
    
}
