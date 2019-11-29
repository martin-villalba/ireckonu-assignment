namespace IreckonuAssignment.DataAccess.Db.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ArticleSizeDataModel
    {
        [Key]
        public string Key { get; set; }

        public decimal Price { get; set; }

        public decimal DiscountPrice { get; set; }

        public ushort Size { get; set; }

        public string Color { get; set; }

        public string DeliveredIn { get; set; }

        public ArticleDataModel Article { get; set; }
    }
}
