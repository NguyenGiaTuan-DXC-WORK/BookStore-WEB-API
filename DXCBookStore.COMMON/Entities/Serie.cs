
namespace DXCBookStore.COMMON.Entities
{
    public class Serie:BaseEntity
    {
        public string SerieName { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public virtual Image Image { get; set; }
        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }

    }
}
