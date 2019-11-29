namespace IreckonuAssignment.DataAccess.Json
{
    using System.Threading.Tasks;

    public class FileWrapper : IFileWrapper
    {
        private string filePath;

        public FileWrapper(string filePath)
        {
            this.filePath = filePath;
        }

        public virtual async Task WriteAllTextAsync(string content)
        {
            await System.IO.File.WriteAllTextAsync(this.filePath, content);
        }
    }
}
