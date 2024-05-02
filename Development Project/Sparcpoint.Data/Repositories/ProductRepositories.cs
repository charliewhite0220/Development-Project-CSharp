using Sparcpoint.Core;
using Sparcpoint.SqlServer.Abstractions;
using System.Data.SqlClient;
using Dapper;
using Sparcpoint.Core.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Sparcpoint.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> AddProductAsync(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"INSERT INTO Instances.Products (Name, Description, ProductImageUris, ValidSkus)
                              VALUES (@Name, @Description, @ProductImageUris, @ValidSkus);
                              SELECT CAST(SCOPE_IDENTITY() as int);";
                var productId = await connection.QuerySingleAsync<int>(query, product);

                foreach (var pair in product.Metadata)
                {
                    var metaQuery = @"INSERT INTO Instances.ProductAttributes (InstanceId, Key, Value)
                                      VALUES (@InstanceId, @Key, @Value);";
                    await connection.ExecuteAsync(metaQuery, new { InstanceId = productId, pair.Key, pair.Value });
                }

                return productId;
            }
        }

        public async Task<List<Product>> SearchProductsAsync(string metadataKey, string metadataValue)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"SELECT p.InstanceId, p.Name, p.Description, p.ProductImageUris, p.ValidSkus
                              FROM Instances.Products p
                              INNER JOIN Instances.ProductAttributes pa ON p.InstanceId = pa.InstanceId
                              WHERE pa.Key = @Key AND pa.Value = @Value AND p.IsDeleted = 0;";

                var products = await connection.QueryAsync<Product>(query, new { Key = metadataKey, Value = metadataValue });
                return products.ToList();
            }
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE Instances.Products SET Name = @Name, Description = @Description WHERE InstanceId = @InstanceId;";
                var result = await connection.ExecuteAsync(query, product);
                return result > 0;
            }
        }
    }
}
