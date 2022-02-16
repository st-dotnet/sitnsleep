using SitNSleep.Data.Entities;
using SitNSleep.Services.Dtos;

namespace SitNSleep.Services.Interfaces
{
    public interface IStoreService
    {
        Task<Store> GetStore(int storeId);
        Task<List<Store>> GetStoreList();
        Task<Store> AddStore(StoreDto request);
        Task<Store> UpdateStore(StoreDto request);
        Task<bool> DeleteStore(int storeId);
    }
}
