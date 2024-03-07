namespace BookStoreMVC.Models
{
    public class Book:BaseEntity
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishedDate { get; set; }
        public int IdCategory { get; set; }
        public int? IdSerie { get; set; }

        public DateTime? DeletedDate { get; set; }
        public virtual Serie Serie { get; set; }
        public virtual Category Category { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
