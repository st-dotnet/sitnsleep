using SitNSleep.Data.Entities;
using SitNSleep.Services.Dtos;

namespace SitNSleep.Services.Interfaces
{
    public interface ISalesPersonService
    {
        Task<List<SalesPerson>> GetSalesPersonList();
        Task<SalesPerson> AddSalesPerson(SalesPersonDto request);
    }
}
