namespace SitNSleep.Web.Models
{
    public class StoreModel
    {
        public int? StoreID { get; set; }
        public string StoreName { get; set; }

        public string StoreNum { get; set; }

        public bool? StorisType { get; set; }

        public string? Url { get; set; }

        public string? PlayerId { get; set; }

        public string? PodiumLocationId { get; set; }
    }
}
