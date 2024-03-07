namespace DXC_BookStore_WEB_API.Models.ResponseModels
{
    public class BaseResponseModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
