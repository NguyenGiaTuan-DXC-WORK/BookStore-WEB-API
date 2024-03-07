using DXCBookStore.BLL.Interfaces;
using DXCBookStore.COMMON.Entities;
using DXCBookStore.COMMON.Helpers;
using DXCBookStore.COMMON.Models;
using DXCBookStore.COMMON.Models.RequestModels;
using DXCBookStore.DAL.DatabaseContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace DXCBookStore.BLL.Business
{
    public class CategoryManagement : ICategoryManagement
    {
        private readonly DataContext _db;
        private IHostingEnvironment _webHostEnvironment;

        public CategoryManagement(DataContext db, IHostingEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<string> CreateCategory(CategoryRequestModel categoryRequestModel)
        {
            var category = new Category();

            category.CategoryName = categoryRequestModel.CategoryName;
            var fileHelper = new FileHelper(_webHostEnvironment);
            // Save image for serie
            // Modify file name

            // Check if file upload
            category.CategoryIcon = "";
            if (categoryRequestModel.CategoryIcon != null)
            {
                var fileName = fileHelper.UploadFile(categoryRequestModel.CategoryIcon);
                if (!fileName.Equals("error"))
                {
                    category.CategoryIcon = fileName;
                }
                else
                {
                    return "Error";
                }
            }
            if (categoryRequestModel.CategoryParentId == null)
            {
                category.CategoryParentId = null;
            }
            else
            {
                category.CategoryParentId = categoryRequestModel.CategoryParentId;
            }
            // Asign init value
            category.CreatedDate = DateTime.Now;
            category.IsDeleted = false;

            _db.Categories.Add(category);
            await _db.SaveChangesAsync();
            if (category.Id > 0)
            {
                return "Ok";
            }
            return "Fail";
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var categories = await _db.Categories.Include(p => p.Books).Include(p => p.CategoryParent).Include(p => p.InverseParent).Where(i=> (bool)!i.IsDeleted).OrderByDescending(p => p.Id).ToListAsync();
            return categories;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var category = await GetCategoryById(id);
            if (category != null)
            {
                category.IsDeleted = true;
                _db.Entry(category).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var result = await _db.Categories.SingleOrDefaultAsync(p => p.Id == id);
            return result;
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            if(category.CategoryParentId == 0)
            {
                category.CategoryParentId = null;
            }
            category.UpdatedDate = DateTime.Now;
            _db.Entry(category).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Category>> GetAllParentCategories(int? id)
        {
            var parentCategories = await _db.Categories.Where(i => i.CategoryParentId == id).Include(p => p.InverseParent).ToListAsync();
            return parentCategories;
        }
    }
}
