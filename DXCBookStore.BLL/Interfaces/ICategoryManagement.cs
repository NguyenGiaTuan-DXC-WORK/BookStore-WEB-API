using DXCBookStore.COMMON.Entities;
using DXCBookStore.COMMON.Models;
using DXCBookStore.COMMON.Models.RequestModels;

namespace DXCBookStore.BLL.Interfaces
{
    public interface ICategoryManagement
    {
        public Task<IEnumerable<Category>> GetAllCategories();
        public Task<IEnumerable<Category>> GetAllParentCategories(int? id);

        public Task<string> CreateCategory(CategoryRequestModel categoryRequestModel);

        public Task<bool> UpdateCategory(Category category);

        public Task<bool> DeleteCategory(int id);

        public Task<Category> GetCategoryById(int id);
    }
}
