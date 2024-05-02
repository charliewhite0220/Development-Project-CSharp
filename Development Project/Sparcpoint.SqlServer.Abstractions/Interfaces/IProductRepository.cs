using System.Collections.Generic;
using System.Threading.Tasks;
using Sparcpoint.Core.Models;

namespace Sparcpoint.SqlServer.Abstractions
{
    public interface IProductRepository
    {
        Task<int> AddProductAsync(Product product);
        Task<List<Product>> SearchProductsAsync(string metadataKey, string metadataValue);
        Task<bool> UpdateProductAsync(Product product);
    }
}
