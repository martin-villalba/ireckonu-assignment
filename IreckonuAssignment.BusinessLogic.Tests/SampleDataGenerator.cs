namespace IreckonuAssignment.BusinessLogic.Tests
{
    using System.Collections.Generic;
    using IreckonuAssignment.BusinessLogic.Domain;

    public class SampleDataGenerator
    {
        public virtual IEnumerable<RawArticle> GetRawArticles()
        {
            return new List<RawArticle>()
            {
                new RawArticle
                {
                    Key = "2800104",
                    ArticleCode = "2",
                    ColorCode = "broek",
                    Description = "Gaastra",
                    Price = 8,
                    DiscountPrice = 0,
                    DeliveredIn = "1 -3 werkdagen",
                    Q1 = "baby",
                    Size = 104,
                    Color = "grijs"
                },
                new RawArticle
                {
                    Key = "370056",
                    ArticleCode = "3",
                    ColorCode = "Kniebroek Jorge",
                    Description = "Mexx",
                    Price = 5,
                    DiscountPrice = 0,
                    DeliveredIn = "1 -3 werkdagen",
                    Q1 = "baby",
                    Size = 56,
                    Color = "bruin"
                },
                new RawArticle
                {
                    Key = "00000002groe56",
                    ArticleCode = "2",
                    ColorCode = "broek",
                    Description = "Gaastra",
                    Price = 8,
                    DiscountPrice = 0,
                    DeliveredIn = "1 -3 werkdagen",
                    Q1 = "baby",
                    Size = 56,
                    Color = "groen"
                }
            };
        }
    }
}