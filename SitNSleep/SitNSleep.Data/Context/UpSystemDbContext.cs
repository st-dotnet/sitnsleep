using Microsoft.EntityFrameworkCore;
using SitNSleep.Data.Entities;

namespace SitNSleep.Data.Context
{
    public class UpSystemDbContext : DbContext
    {
        public UpSystemDbContext(DbContextOptions<UpSystemDbContext> options) : base(options) { }

        #region Tables

        public DbSet<SalesPerson> SalesPersons { get; set; }

        #endregion
    }
}
