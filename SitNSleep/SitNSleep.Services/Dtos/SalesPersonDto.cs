namespace SitNSleep.Services.Dtos
{
    public class SalesPersonDto
    {
        public int SaleId { get; set; }
        public string? SalesPersonId { get; set; }
        public string? Name { get; set; }
        public bool? Available { get; set; }
        public bool? UP { get; set; }
        public decimal? Sequence { get; set; }
        public string? SalesPersonEmail { get; set; }
    }
}
