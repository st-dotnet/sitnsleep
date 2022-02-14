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
    }
}
