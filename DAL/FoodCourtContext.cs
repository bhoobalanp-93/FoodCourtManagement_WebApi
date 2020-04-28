using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using FoodCourtManagement.Models;

namespace FoodCourtManagement.DAL
{
    public class FoodCourtContext : DbContext
    {

        public FoodCourtContext() : base("FoodCourtContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FoodCourtContext, Migrations.Configuration>());
        }

        public DbSet<FoodOrder> FoodOrders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<FoodProduct> FoodProducts { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet <FoodCategory> FoodCategories { get; set; }
        public DbSet<RestaurantType> RestaurantTypes { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<OrderProduct>().HasKey(x => new { x.OrderId, x.fProductid});
        }
    }
}