using Microsoft.EntityFrameworkCore;
using NLog;
using SitNSleep.Data.Context;
using SitNSleep.Data.Entities;
using SitNSleep.Services.Dtos;
using SitNSleep.Services.Interfaces;

namespace SitNSleep.Services.Services
{
    public class SalesPersonService : ISalesPersonService
    {

        #region Field(s)

        private readonly Logger _logger;
        private readonly UpSystemDbContext _db;

        #endregion

        #region Constructor

        public SalesPersonService(UpSystemDbContext db)
        {
            _logger = LogManager.GetCurrentClassLogger();
            _db = db;
        }

        #endregion

        public async Task<SalesPerson> GetSalesPerson(string salespersonId)
        {
            var salesperson = await _db.SalesPersons.FirstOrDefaultAsync(x => x.SalespersonID == salespersonId);

            return salesperson;
        }

        public async Task<List<SalesPerson>> GetSalesPersonList()
        {
            var salespersons = await _db.SalesPersons.ToListAsync();
            return salespersons;
        }

        public async Task<SalesPerson> AddSalesPerson(SalesPersonDto request)
        {
            var salesPerson = new SalesPerson
            {
                SalespersonID = request.SalesPersonId,
                Available = request.Available,
                Name = request.Name,
                UP = request.UP,
                Sequence = request.Sequence,
                SalesPersonEmail = request.SalesPersonEmail
            };

            _db.SalesPersons.Add(salesPerson);
            await _db.SaveChangesAsync();

            return salesPerson;
        }
        
        public async Task<SalesPerson> UpdateSalesPerson(SalesPersonDto request)
        {
            var salesPerson = await _db.SalesPersons.FirstOrDefaultAsync(x => x.SalespersonID == request.SalesPersonId);

            if (salesPerson == null)
                throw new Exception(string.Format("SalesPerson do no exist with id: {0}, name : {1}", request.SalesPersonId, request.Name));

            salesPerson.Available = request.Available;
            salesPerson.Name = request.Name;
            salesPerson.UP = request.UP;
            salesPerson.Sequence = request.Sequence;
            salesPerson.SalesPersonEmail = request.SalesPersonEmail;

            _db.SalesPersons.Update(salesPerson);
            await _db.SaveChangesAsync();

            return salesPerson;
        }

        public async Task<bool> DeleteSalesPerson(int saleId)
        {
            var salesperson = await _db.SalesPersons.FirstOrDefaultAsync(x => x.SaleID == saleId);
            _db.SalesPersons.Remove(salesperson);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
