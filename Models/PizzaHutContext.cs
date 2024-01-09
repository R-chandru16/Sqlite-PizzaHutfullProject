using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Models
{
    public class PizzaHutContext : DbContext
    {
        public PizzaHutContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Users> Customers { get; set; }
        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<Toppings> Toppings { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasData(
                new Users() { ID = 101, Name = "chandru", UserID = "chandru@gmail.com", Password = "chandru2598", Phone = "9876543213", Address = "#Neyveli" },

                 new Users() { ID = 102, Name = "demo", UserID = "Demo@gmail.com", Password = "demo", Phone = "9876543214", Address = "#demo" }
                );
            modelBuilder.Entity<Pizza>().HasData(
               new Pizza() { ID = 1001, Name = "Veg Loaded", Price = 199, Speicality = "with Pepse", Crust = "Fresh Pan Pizza", Description = "Peppy Paneer Cheese Burst Topped with Extra Cheese", Images = "/images/pizza-1.jpg" },
                new Pizza() { ID = 1002, Name = "Peppy Paneer Pizza", Price = 299, Speicality = "with extra toppings", Crust = "Fresh Pan Pizza", Description = "Peppy Paneer Cheese Burst Topped with Extra Cheese", Images = "/images/pizza-2.jpg" },
                new Pizza() { ID = 1003, Name = "Peper Chicken", Price = 199, Speicality = "with Pepse", Crust = "Fresh Pan Pizza", Description = "Mashroon Topped", Images = "/images/pizza-3.jpg" },
                 new Pizza() { ID = 1004, Name = "Non Veg Loaded", Price = 299, Speicality = "with Pepse", Crust = "Fresh Pan Pizza", Description = "Peppy Paneer Cheese Burst Topped with Extra Cheese", Images = "/images/pizza-4.jpg" }
                );
            modelBuilder.Entity<Toppings>().HasData(
                new Toppings() { ID = 201, Name = "Tomato", Price = 99 },
                new Toppings() { ID = 202, Name = "Cheese", Price = 89 },
                new Toppings() { ID = 203, Name = "Onion", Price = 100 }
                );
        }
    }
}