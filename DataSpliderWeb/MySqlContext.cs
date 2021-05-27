using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataSpliderWeb
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        { 
        } 

        public DbSet<Entity.City> city { get; set; }
        public DbSet<Entity.Province> province { get; set; }
        public DbSet<Entity.AppInfo> appinfo { get; set; }
        public DbSet<Entity.AppListURL> applisturl { get; set; }
    }
}
