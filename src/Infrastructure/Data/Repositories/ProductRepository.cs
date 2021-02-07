using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetProductsWithTypeAndUserAsync()
        {
            return await _context.Products
                                 .Include(p => p.ProductType)
                                 .Include(u => u.User)
                                 .ThenInclude(a => a.Address)
                                 .ThenInclude(g => g.Geo)
                                 .Include(u => u.User)
                                 .ThenInclude(c => c.Company)
                                 .ToListAsync();
        }

        public async Task<Product> GetProductWithTypeAndUserByIdAsync(int id)
        {
            return await _context.Products
                                 .Include(p => p.ProductType)
                                 .Include(u => u.User)
                                 .ThenInclude(a => a.Address)
                                 .ThenInclude(g => g.Geo)
                                 .Include(u => u.User)
                                 .ThenInclude(c => c.Company)
                                 .FirstOrDefaultAsync(x => x.ProductId == id);
        }
    }
}
