namespace DXCBookStore.COMMON.Models.ResponseModels
{
    public class InvoiceResponseModel:BaseResponseModel
    {
        public string ShippingAddress { get; set; }
        public string Phone { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PaidDate { get; set; }
        public string FullName { get; set; }

        public virtual ICollection<InvoiceDetailResponseModel> InvoiceDetailReponseModels { get; set; }
    }
}
