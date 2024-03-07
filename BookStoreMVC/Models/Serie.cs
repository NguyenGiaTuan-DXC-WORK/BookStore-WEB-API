namespace BookStoreMVC.Models
{
    public class Serie:BaseEntity
    {
        public string SerieName { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
