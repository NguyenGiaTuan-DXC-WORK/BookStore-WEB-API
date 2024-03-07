namespace DXCBookStore.COMMON.Entities
{
    public class Category:BaseEntity
    {
        public string CategoryName { get; set; }
        public string CategoryIcon { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public int? CategoryParentId { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual Category CategoryParent { get; set; }
        public virtual ICollection<Category> InverseParent { get; set; }
    }
}
