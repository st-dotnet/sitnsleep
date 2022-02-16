using Microsoft.EntityFrameworkCore;
using NLog;
using SitNSleep.Data.Context;
using SitNSleep.Data.Entities;
using SitNSleep.Services.Dtos;
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

        public async Task<Store> AddStore(StoreDto request)
        {
            var store = new Store
            {
                StoreName = request.StoreName,
                StoreNum = request.StoreNum,
                StorisType = request.StorisType,
                Url = request.Url,
                PlayerId = request.PlayerId,
                PodiumLocationId = request.PodiumLocationId,
            };

            _db.Stores.Add(store);
            await _db.SaveChangesAsync();

            return store;
        }

        public async Task<Store> UpdateStore(StoreDto request)
        {
            var store = await _db.Stores.FirstOrDefaultAsync(x => x.StoreID == request.StoreID);

            if (store == null)
                throw new Exception(string.Format("Store do no exist with id: {0}, name : {1}", request.StoreID, request.StoreName));

            store.StoreName = request.StoreName;
            store.StoreNum = request.StoreNum;
            store.StorisType = request.StorisType;
            store.Url = request.Url;
            store.PlayerId = request.PlayerId;
            store.PodiumLocationId = request.PodiumLocationId;

            _db.Stores.Update(store);
            await _db.SaveChangesAsync();

            return store;
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
