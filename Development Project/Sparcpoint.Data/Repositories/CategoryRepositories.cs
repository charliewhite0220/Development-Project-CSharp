using Sparcpoint.SqlServer.Abstractions;
using Sparcpoint.Core.Models;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace Sparcpoint.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string _connectionString;

        public CategoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> AddCategoryAsync(Category category)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO Categories (Name, Description) VALUES (@Name, @Description); SELECT SCOPE_IDENTITY();";
                var categoryId = await connection.ExecuteScalarAsync<int>(query, category);
                return categoryId;
            }
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT CategoryId, Name, Description FROM Categories WHERE CategoryId = @CategoryId;";
                return await connection.QuerySingleOrDefaultAsync<Category>(query, new { CategoryId = categoryId });
            }
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE Categories SET Name = @Name, Description = @Description WHERE CategoryId = @CategoryId;";
                await connection.ExecuteAsync(query, category);
            }
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Categories WHERE CategoryId = @CategoryId;";
                await connection.ExecuteAsync(query, new { CategoryId = categoryId });
            }
        }
    }
}
