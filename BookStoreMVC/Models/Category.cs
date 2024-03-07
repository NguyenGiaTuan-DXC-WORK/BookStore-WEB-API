namespace BookStoreMVC.Models
{
    public class Category:BaseEntity
    {
        public string CategoryName { get; set; }
        public int? CategoryParentId { get; set; }
        public Category CategoryParent { get; set; }

        public virtual ICollection<Category> ChildCategories { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
