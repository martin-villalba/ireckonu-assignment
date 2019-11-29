namespace IreckonuAssignment.Domain.Models
{
    using System.Collections.Generic;

    public class Article
    {
        public Article()
        {
            this.Sizes = new List<ArticleSize>();
        }

        public string ArticleCode { get; set; }

        public string ColorCode { get; set; }

        public string Description { get; set; }

        public string Q1 { get; set; }

        public IList<ArticleSize> Sizes { get; set; }
    }
}
