namespace IreckonuAssignment.DataAccess
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using IreckonuAssignment.Domain.Models;

    public interface IArticleSaver
    {
        Task SaveArticles(IEnumerable<Article> items);
    }
}
