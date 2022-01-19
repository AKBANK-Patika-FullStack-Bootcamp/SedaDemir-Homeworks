using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFLibCore
{
	public class CustomerContext : DbContext
	{
        
        //protected readonly IConfiguration Configuration;
        public CustomerContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer("Data Source = localhost; Database = CustomerDB; integrated security = True;");
            options.UseSqlServer("Server = localhost,1431\\Catalog=CURRENCYDB;Database = CURRENCYDB;User=sa;Password=<YourPa@$$word>;TrustServerCertificate=true");



        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            //modelBuilder.Entity<Currency>().ToTable("Currency");
            //modelBuilder.Entity<Favorites>().ToTable("Favorites");
            modelBuilder.Entity<APIAuthority>().ToTable("APIAuthority");

        }
        public DbSet<Customer> Customer { get; set; }
        //public DbSet<Currency> Currency { get; set; }
        //public DbSet<Favorites> Favorites { get; set; }
        public DbSet<APIAuthority> APIAuthority { get; set; }

    }
}


