namespace IreckonuAssignment.BusinessLogic.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using IreckonuAssignment.DataAccess;
    using IreckonuAssignment.Domain.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class ArticlesHandlerFixture
    {
        [TestMethod]
        public async Task ShouldPassNormalizedDataToArticleSaver()
        {
            // Arrange
            var articlesNormalizer = new ArticlesNormalizer();
            var savedArticles = new List<Article>();

            var mockSaver = new Mock<IArticleSaver>();
            mockSaver.Setup(m => m.SaveArticles(It.IsAny<IEnumerable<Article>>()))
                        .Callback<IEnumerable<Article>>(a =>
                        {
                            savedArticles.AddRange(a);
                        });

            var articleHandler = new ArticlesHandler(new ArticlesNormalizer(), new List<IArticleSaver>() { mockSaver.Object });

            // Act
            var rawData = new SampleDataGenerator().GetRawArticles();
            await articleHandler.ProcessItems(rawData);

            // Assert
            Assert.AreEqual(2, savedArticles.Count());

            var article = savedArticles.First(x => x.ArticleCode.Equals("2"));
            Assert.AreEqual("broek", article.ColorCode);
            Assert.AreEqual(2, article.Sizes.Count());
        }
    }
}
