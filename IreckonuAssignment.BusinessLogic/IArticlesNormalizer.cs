namespace IreckonuAssignment.BusinessLogic
{
    using System.Collections.Generic;
    using IreckonuAssignment.BusinessLogic.Domain;
    using IreckonuAssignment.Domain.Models;

    public interface IArticlesNormalizer
    {
        IEnumerable<Article> NormalizeItems(IEnumerable<RawArticle> fileItems);
    }
}
