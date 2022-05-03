using System;
using System.Collections.Generic;
using System.Linq;
using arz.eda.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace arz.eda
{
    public class ApplicationContext : IdentityDbContext<Account>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Order>().OwnsMany(x => x.OrderLines);
        }

        internal object FindAsync(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
