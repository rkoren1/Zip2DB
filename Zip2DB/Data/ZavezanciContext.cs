using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadZIP.Data
{
    internal class ZavezanciContext : DbContext
    {
        public virtual DbSet<ZavezanecEntity> Zavezanci { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlite("Data Source=zavezanci.db");
        }
        
    }
}
