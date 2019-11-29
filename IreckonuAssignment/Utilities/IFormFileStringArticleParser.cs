namespace IreckonuAssignment.Utilities
{
    using System.Collections.Generic;
    using IreckonuAssignment.BusinessLogic.Domain;

    public interface IFormFileStringArticleParser
    {
        IEnumerable<RawArticle> ParseArticles(IEnumerable<string> items);
    }
}
