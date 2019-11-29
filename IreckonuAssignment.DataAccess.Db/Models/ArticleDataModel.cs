namespace IreckonuAssignment.DataAccess.Db.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ArticleDataModel
    {
        public ArticleDataModel()
        {
            this.Sizes = new List<ArticleSizeDataModel>();
        }

        [Key]
        public string ArticleCode { get; set; }

        public string ColorCode { get; set; }

        public string Description { get; set; }

        public string Q1 { get; set; }

        public IList<ArticleSizeDataModel> Sizes { get; set; }
    }
}
