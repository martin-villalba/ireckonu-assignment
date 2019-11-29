namespace IreckonuAssignment.DataAccess.Db
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using IreckonuAssignment.DataAccess.Db.Models;
    using IreckonuAssignment.Domain.Models;

    public class DatabaseArticleSaver : IArticleSaver
    {
        private IIreckonuAssigmentDbContext databaseContext;
        private IMapper mapper;

        public DatabaseArticleSaver(IIreckonuAssigmentDbContext databaseContext, IMapper mapper)
        {
            this.databaseContext = databaseContext;
            this.mapper = mapper;
        }

        public virtual async Task SaveArticles(IEnumerable<Article> articles)
        {
            var articlesDataModel = this.mapper.Map<IEnumerable<ArticleDataModel>>(articles);
            this.databaseContext.Articles.AddRange(articlesDataModel);

            await this.databaseContext.SaveChangesAsync();
        }
    }
}