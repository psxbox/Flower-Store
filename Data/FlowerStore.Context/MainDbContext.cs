using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerStore.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlowerStore.Context
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Flower> Flowers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Bouquet> Bouquets { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Flower>().HasMany(f => f.Categories).WithMany();
            modelBuilder.Entity<Bouquet>().HasMany(b => b.Categories).WithMany();
            modelBuilder.Entity<Bouquet>().HasMany(b => b.Flowers).WithMany();
        }
    }
}