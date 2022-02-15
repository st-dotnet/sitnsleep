using Microsoft.EntityFrameworkCore;
using NLog;
using SitNSleep.Data.Context;
using SitNSleep.Data.Entities;
using SitNSleep.Services.Interfaces;

namespace SitNSleep.Services.Services
{
    public class StoreService : IStoreService
    {

        #region Field(s)

        private readonly Logger _logger;
        private readonly UpSystemDbContext _db;

        #endregion

        #region Constructor

        public StoreService(UpSystemDbContext db)
        {
            _logger = LogManager.GetCurrentClassLogger();
            _db = db;
        }

        #endregion

        public async Task<Store> GetStore(int storeId)
        {
            var salesperson = await _db.Stores.FirstOrDefaultAsync(x => x.StoreID == storeId);

            return salesperson;
        }

        public async Task<List<Store>> GetStoreList()
        {
            var stores = await _db.Stores.ToListAsync();
            return stores;
        }

        public async Task<bool> DeleteStore(int storeId)
        {
            var store = await _db.Stores.FirstOrDefaultAsync(x => x.StoreID == storeId);
            _db.Stores.Remove(store);
            await _db.SaveChangesAsync();

            return true;
        }

    }
}
