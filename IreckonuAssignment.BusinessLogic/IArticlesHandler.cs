namespace IreckonuAssignment.BusinessLogic
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using IreckonuAssignment.BusinessLogic.Domain;

    public interface IArticlesHandler
    {
        Task ProcessItems(IEnumerable<RawArticle> rawArticles);
    }
}
