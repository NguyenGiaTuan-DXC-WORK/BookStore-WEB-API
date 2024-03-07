using DXCBookStore.COMMON.Entities;

namespace DXC_BookStore_WEB_API.Models.ResponseModels
{
    public class CategoryResponseModel:BaseResponseModel
    {
        public string CategoryName { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
