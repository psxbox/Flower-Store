using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerStore.Context.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlowerStore.Context
{
    public class MainDbContext : IdentityDbContext<User, UserRole, Guid>
    {
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Flower>? Flowers { get; set; }
        public DbSet<Category>? Categories { get; set; }
    }
}