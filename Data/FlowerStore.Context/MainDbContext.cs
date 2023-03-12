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
        public DbSet<UserRole> Roles { get; set; }
        public DbSet<Flower> Flowers { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserRole>().HasMany(r => r.Users).WithMany(r => r.UserRoles);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseLazyLoadingProxies();
            base.OnConfiguring(builder);
        }
    }
}