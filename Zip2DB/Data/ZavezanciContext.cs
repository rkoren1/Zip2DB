using Microsoft.EntityFrameworkCore;

namespace DownloadZIP.Data
{
    internal class ZavezanciContext : DbContext
    {
        public virtual DbSet<ZavezanecEntity> Zavezanci { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlite("Data Source=davcni_zavezanci.db");
        }

    }
}
