using SitNSleep.Data.Entities;
using SitNSleep.Services.Dtos;

namespace SitNSleep.Services.Interfaces
{
    public interface ISalesPersonService
    {
        Task<SalesPerson> GetSalesPerson(string salespersonId);
        Task<List<SalesPerson>> GetSalesPersonList();
        Task<SalesPerson> AddSalesPerson(SalesPersonDto request);
        Task<SalesPerson> UpdateSalesPerson(SalesPersonDto request);
        Task<bool> DeleteSalesPerson(int saleId);
    }
}
