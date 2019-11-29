namespace IreckonuAssignment.DataAccess.Json.Models
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class ArticleDataModel
    {
        public ArticleDataModel()
        {
            this.Sizes = new List<ArticleSizeDataModel>();
        }

        public string ArticleCode { get; set; }

        public string ColorCode { get; set; }

        public string Description { get; set; }

        public string Q1 { get; set; }

        public IList<ArticleSizeDataModel> Sizes { get; set; }
    }
}
