namespace IreckonuAssignment.DataAccess.Json.Models
{
    using System;

    [Serializable]
    public class ArticleSizeDataModel
    {
        public string Key { get; set; }

        public decimal Price { get; set; }

        public decimal DiscountPrice { get; set; }

        public ushort Size { get; set; }

        public string Color { get; set; }

        public string DeliveredIn { get; set; }
    }
}
