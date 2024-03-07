
using DXCBookStore.COMMON.Entities;

namespace DXCBookStore.COMMON.Models
{
    public class CategoryResponseModel:BaseResponseModel
    {
        public string CategoryName { get; set; }
        public List<CategoryResponseModel>? ChildCategories { get;set; }
        public bool HasChildren { get; set; }
        public string CategoryIcon { get; set; }
        public string? CategoryParentName { get; set; }
    }
}
