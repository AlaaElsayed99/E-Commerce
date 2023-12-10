using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class Product:BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set;}
        public ProductType? productType { get; set; }
        [ForeignKey(nameof(ProductType))]
        public int ProductTypeId { get; set; }
        public ProductBrand? productBrand { get; set; }
        [ForeignKey(nameof(productBrand))]
        public int ProductBrandId { get; set; }


    }
}
