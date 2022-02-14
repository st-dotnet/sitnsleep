using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SitNSleep.Data.Entities
{
    [Table("SalesPerson")]
    public class SalesPerson
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SaleID { get; set; }
        public string? SalespersonID { get; set; }
        public string? Name { get; set; }
        public bool? Available { get; set; }
        public string? StoreID { get; set; }
        public bool? UP { get; set; }
        public decimal? Sequence { get; set; }
        public string? SalesPersonEmail { get; set; }
    }
}
