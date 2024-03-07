namespace DXCBookStore.COMMON.Entities
{
    public class Book:BaseEntity
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? SerieId { get; set; }
        public int CategoryId { get; set; }
        public int PublisherId { get; set; }
        public int Quantity { get; set; }
        public virtual Serie Serie { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<Image> Images { get; set; }
        public virtual Publisher Publisher { get; set; }

        public int TotalPage { get; set; }

        public string Author { get; set; }

        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
