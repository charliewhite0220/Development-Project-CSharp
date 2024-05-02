using Sparcpoint.Core.Models;
using System.Threading.Tasks;

namespace Sparcpoint.SqlServer.Abstractions
{
    public interface ICategoryRepository
    {
        Task<int> AddCategoryAsync(Category category);
        Task<Category> GetCategoryByIdAsync(int categoryId);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int categoryId);
    }
}
