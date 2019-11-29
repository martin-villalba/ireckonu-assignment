namespace IreckonuAssignment.BusinessLogic.Tests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ArticlesNormalizerFixture
    {
        [TestMethod]
        public void ShouldGenerateTwoNormalizedArticles()
        {
            // Arrange
            var articlesNormalizer = new ArticlesNormalizer();

            // Act
            var rawData = new SampleDataGenerator().GetRawArticles();
            var normalizedData = articlesNormalizer.NormalizeItems(rawData);

            // Assert
            Assert.AreEqual(2, normalizedData.Count());

            var article = normalizedData.First(x => x.ArticleCode.Equals("2"));
            Assert.AreEqual("broek", article.ColorCode);
            Assert.AreEqual(2, article.Sizes.Count());
        }
    }
}
