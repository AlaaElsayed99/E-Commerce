using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync (ApplicationDbContext context)
        {
            
            if (!context.productBrands.Any())
            {
                var brandsData =File.ReadAllText("../infrastructure/Data/SeedData/brands.json");
                var brands= JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                context.productBrands.AddRange(brands);
            }
            if (!context.productTypes.Any())
            {
                var TypesData =File.ReadAllText("../infrastructure/Data/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);
                context.productTypes.AddRange(types);
            }
            if (!context.products.Any())
            {
                var productData = File.ReadAllText("../infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productData);
                context.products.AddRange(products);
            }
            if(context.ChangeTracker.HasChanges())
                await context.SaveChangesAsync();



        }
    }
}
