namespace IreckonuAssignment.DataAccess.Json.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using IreckonuAssignment.DataAccess.Json.Models;
    using IreckonuAssignment.DataAccess.Json.Models.Mappers;
    using IreckonuAssignment.Domain.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Newtonsoft.Json;

    [TestClass]
    public class JsonArticleSaverFixture
    {
        private IMapper mapper;

        public JsonArticleSaverFixture()
        {
            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(new ArticleDataModelProfile());
            });

            this.mapper = config.CreateMapper();
        }

        [TestMethod]
        public async Task ShouldAddArticlesInJsonFile()
        {
            string savedData = string.Empty;

            // Arrange
            var fileWrapperMock = new Mock<IFileWrapper>();
            fileWrapperMock.Setup(m => m.WriteAllTextAsync(It.IsAny<string>()))
                .Callback<string>((x) =>
                {
                    savedData = x;
                });

            var jsonArticleSaver = new JsonArticleSaver(fileWrapperMock.Object, this.mapper);

            // Act
            var articles = new List<Article>
            {
                new Article
                {
                    ArticleCode = "article-code",
                    ColorCode = "colorCode",
                    Description = "description",
                    Q1 = "Q1",
                }
            };

            await jsonArticleSaver.SaveArticles(articles);

            // Assert
            fileWrapperMock.Verify(m => m.WriteAllTextAsync(It.IsAny<string>()), Times.Once());
            var parseData = JsonConvert.DeserializeObject<IEnumerable<ArticleDataModel>>(savedData);

            Assert.AreEqual("article-code", parseData.First().ArticleCode);
        }
    }
}
