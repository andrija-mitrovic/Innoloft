using ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsWithTypeAndUserAsync();
        //Task<IEnumerable<Product>> GetProductsWithTypeAndUserAsync(PagingParams pagingParams);
        Task<Product> GetProductWithTypeAndUserByIdAsync(int id);
    }
}
