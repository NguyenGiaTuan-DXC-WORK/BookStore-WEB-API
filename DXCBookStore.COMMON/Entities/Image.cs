using System.Text.Json.Serialization;

namespace DXCBookStore.COMMON.Entities
{
    public class Image:BaseEntity
    {
        public string ImageName { get; set; }
        [JsonIgnore]
        public int? IdBook { get; set; }
        public int? IdSerie { get; set; }
        [JsonIgnore]
        public virtual Book Book { get; set; }
        [JsonIgnore]
        public virtual Serie Serie { get; set; }
    }
}
