namespace IreckonuAssignment.DataAccess.Db.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using IreckonuAssignment.DataAccess.Db.Models;
    using IreckonuAssignment.DataAccess.Db.Models.Mappers;
    using IreckonuAssignment.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class DatabaseArticleSaverFixture
    {
        private IMapper mapper;

        public DatabaseArticleSaverFixture()
        {
            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(new ArticleDataModelProfile());
            });

            this.mapper = config.CreateMapper();
        }

        [TestMethod]
        public async Task ShouldAddArticlesInDbContext()
        {
            // Arrange
            var addedArticles = new List<ArticleDataModel>();

            var mockSet = new Mock<DbSet<ArticleDataModel>>();
            var mockContext = new Mock<IreckonuAssigmentDbContext>(MockBehavior.Default, new object[] { "Connection String" });
            mockContext.Setup(m => m.Articles).Returns(mockSet.Object);
            mockContext.Setup(m => m.Articles.AddRange(It.IsAny<IEnumerable<ArticleDataModel>>()))
                        .Callback<IEnumerable<ArticleDataModel>>(a =>
                        {
                            addedArticles.AddRange(a);
                        });
            mockContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(() => Task.FromResult(0)).Verifiable();

            var articleSaver = new DatabaseArticleSaver(mockContext.Object, this.mapper);

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

            await articleSaver.SaveArticles(articles);

            // Assert
            mockSet.Verify(m => m.AddRange(It.IsAny<IEnumerable<ArticleDataModel>>()), Times.Once());
            mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());

            Assert.AreEqual(1, addedArticles.Count());
            Assert.AreEqual("article-code", addedArticles.First().ArticleCode);
        }
    }
}