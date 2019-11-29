namespace IreckonuAssignment.BusinessLogic
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using IreckonuAssignment.BusinessLogic.Domain;
    using IreckonuAssignment.DataAccess;

    public class ArticlesHandler : IArticlesHandler
    {
        private IArticlesNormalizer normalizer;
        private IEnumerable<IArticleSaver> articlesSavers;

        public ArticlesHandler(IArticlesNormalizer normalizer, IEnumerable<IArticleSaver> articlesSavers)
        {
            this.normalizer = normalizer;
            this.articlesSavers = articlesSavers;
        }

        public virtual async Task ProcessItems(IEnumerable<RawArticle> rawArticles)
        {
            var articles = this.normalizer.NormalizeItems(rawArticles);

            foreach (var articlesSaver in this.articlesSavers)
            {
                await articlesSaver.SaveArticles(articles);
            }
        }
    }
}