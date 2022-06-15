using Project.Entities.Models;
using Project.MAP.Options;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Context
{
    public class MyContext:DbContext
    {
        public MyContext() : base("MyConnection")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new BillMap());
            modelBuilder.Configurations.Add(new UserBillMap());
            modelBuilder.Entity<UserBill>().Property(x => x.TotalPrice).HasPrecision(18, 2);
            modelBuilder.Entity<Product>().Property(x => x.Price).HasPrecision(18, 2);
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<UserBill> UserBills { get; set; }

    }
}
