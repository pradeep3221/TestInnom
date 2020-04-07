using System;

namespace TestInnom.Product.DataModels.Models
{
    public partial class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public int? Quantity { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
