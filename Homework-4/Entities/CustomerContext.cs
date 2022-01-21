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
            //options.UseSqlServer(Configuration.GetConnectionString("UserDBEntities"));
            options.UseSqlServer("Server = localhost,1431\\Catalog=WALLETDB;Database = WALLETDB;User=sa;Password=<YourP@$$word>;TrustServerCertificate=true");



        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            
        }
        public DbSet<Customer> Customer { get; set; }

    }
}


