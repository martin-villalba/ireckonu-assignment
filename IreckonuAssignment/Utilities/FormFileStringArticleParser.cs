namespace IreckonuAssignment.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using IreckonuAssignment.BusinessLogic.Domain;

    public class FormFileStringArticleParser : IFormFileStringArticleParser
    {
        public virtual IEnumerable<RawArticle> ParseArticles(IEnumerable<string> items)
        {
            return items.Skip(1).Select(x => this.ParseArticle(x));
        }

        public virtual RawArticle ParseArticle(string item)
        {
            var itemParts = item.Split(',');

            return new RawArticle
            {
                Key = itemParts[0],
                ArticleCode = itemParts[1],
                ColorCode = itemParts[2],
                Description = itemParts[3],
                Price = Convert.ToInt32(itemParts[4]),
                DiscountPrice = Convert.ToInt32(itemParts[5]),
                DeliveredIn = itemParts[6],
                Q1 = itemParts[7],
                Size = Convert.ToUInt16(itemParts[8]),
                Color = itemParts[9]
            };
        }
    }
}
