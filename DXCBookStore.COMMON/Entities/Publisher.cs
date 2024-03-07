using System.ComponentModel.DataAnnotations;

namespace DXCBookStore.COMMON.Entities
{
    public class Publisher:BaseEntity
    {
        [Required]
        public string BrandName { get; set; }
        [Required]
        public string HeadOfficeAddress { get; set; }
        [Required]
        public string ContactMail { get; set; }
        [Required]
        public string HotLine { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsActive { get; set; }
        // 1 Publisher owns many Books
        public virtual ICollection<Book> Books { get; set; }
        // 1 Publisher owns many Series
        public virtual ICollection<Serie> Series { get; set; }

        // 1 Publisher owns one account
        public virtual Account Account { get; set; }
    }
}
