using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SitNSleep.Data.Entities
{
    [Table("Stores")]
    public class Store
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StoreID { get; set; }

        public string StoreName { get; set; }

        public string StoreNum { get; set; }

        public bool? StorisType { get; set; }

        public string? Url { get; set; }

        public string? PlayerId { get; set; }

        public string? PodiumLocationId { get; set; }

    }
}
