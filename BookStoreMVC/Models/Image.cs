namespace BookStoreMVC.Models
{
    public class Image:BaseEntity
    {
        public string ImageName { get; set; }
        public int? IdBook { get; set; }

        public virtual Book Book { get; set; }
    }
}
