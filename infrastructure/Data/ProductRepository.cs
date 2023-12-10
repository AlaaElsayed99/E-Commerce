using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.products.Include(s=>s.productType).Include(s=>s.productBrand).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return _context.products
                .Include(s => s.productType)
                .Include(s => s.productBrand)
                .FirstOrDefault(s=>s.Id == id);
        }
    }
}
