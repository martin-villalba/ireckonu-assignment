namespace IreckonuAssignment.DataAccess.Json
{
    using System.Threading.Tasks;

    public interface IFileWrapper
    {
        Task WriteAllTextAsync(string content);
    }
}
