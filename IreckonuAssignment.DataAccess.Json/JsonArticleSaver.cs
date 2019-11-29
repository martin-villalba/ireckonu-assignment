namespace IreckonuAssignment.DataAccess.Json
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using IreckonuAssignment.DataAccess.Json.Models;
    using IreckonuAssignment.Domain.Models;
    using Newtonsoft.Json;

    public class JsonArticleSaver : IArticleSaver
    {
        private IMapper mapper;
        private IFileWrapper fileWrapper;

        public JsonArticleSaver(IFileWrapper fileWrapper, IMapper mapper)
        {
            this.mapper = mapper;
            this.fileWrapper = fileWrapper;
        }

        public virtual async Task SaveArticles(IEnumerable<Article> articles)
        {
            var articlesDataModel = this.mapper.Map<IEnumerable<ArticleDataModel>>(articles);
            var serializedArticles = JsonConvert.SerializeObject(articlesDataModel, Formatting.Indented);

            await this.fileWrapper.WriteAllTextAsync(serializedArticles);
        }
    }
}
