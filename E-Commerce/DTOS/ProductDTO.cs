using Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.DTOS
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string productType { get; set; }
        
        public string productBrand { get; set; }
        

    }
}
