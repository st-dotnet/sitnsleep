using SitNSleep.Data.Entities;

namespace SitNSleep.Services.Interfaces
{
    public interface IStoreService
    {
        Task<Store> GetStore(int storeId);
        Task<List<Store>> GetStoreList();
        Task<bool> DeleteStore(int storeId);
    }
}
