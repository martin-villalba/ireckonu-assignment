namespace IreckonuAssignment.BusinessLogic.Domain
{
    public class RawArticle
    {
        public string Key { get; set; }

        public string ArticleCode { get; set; }

        public string ColorCode { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal DiscountPrice { get; set; }

        public string DeliveredIn { get; set; }

        public string Q1 { get; set; }

        public ushort Size { get; set; }

        public string Color { get; set; }
    }
}