﻿using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductsWithBrandsAndTypesSpecifications:BaseSpecification<Product>
    {
        public ProductsWithBrandsAndTypesSpecifications(ProductSpecParams specParams)
            :base(x=>
            (string.IsNullOrEmpty(specParams.Search)||x.Name.ToLower().Contains(specParams.Search))&&
            (!specParams.BrandId.HasValue||x.ProductBrandId== specParams.BrandId) &&
            (!specParams.TypeId.HasValue || x.ProductTypeId == specParams.TypeId))
        {
            AddIncludes(x => x.productType);
            AddIncludes(x => x.productBrand);
            AddOrderBy(x => x.Name);
            ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);

            if (!string.IsNullOrEmpty(specParams.Sort))
            {
                switch (specParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p=>p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p=>p.Price);
                        break;  
                    default: AddOrderBy(p=>p.Name);
                        break;
                }
            }
        }
        public ProductsWithBrandsAndTypesSpecifications(int id): base(x=>x.Id==id)
        {
            AddIncludes(x => x.productType);
            AddIncludes(x => x.productBrand);
        }
        
    }
}
