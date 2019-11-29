namespace IreckonuAssignment.BusinessLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using IreckonuAssignment.BusinessLogic.Domain;
    using IreckonuAssignment.Domain.Models;

    public class ArticlesNormalizer : IArticlesNormalizer
    {
        public virtual IEnumerable<Article> NormalizeItems(IEnumerable<RawArticle> fileItems)
        {
            var articles = new List<Article>();
            var itemGroups = fileItems.GroupBy(x => Tuple.Create(x.ArticleCode, x.ColorCode, x.Description, x.Q1));

            foreach (var group in itemGroups)
            {
                var article = new Article
                {
                    ArticleCode = group.Key.Item1,
                    ColorCode = group.Key.Item2,
                    Description = group.Key.Item3,
                    Q1 = group.Key.Item4
                };

                foreach (var item in group)
                {
                    article.Sizes.Add(new ArticleSize
                    {
                        Article = article,
                        Color = item.Color,
                        DiscountPrice = item.DiscountPrice,
                        Key = item.Key,
                        Price = item.Price,
                        Size = item.Size,
                        DeliveredIn = item.DeliveredIn
                    });
                }

                articles.Add(article);
            }

            return articles;
        }
    }
}
