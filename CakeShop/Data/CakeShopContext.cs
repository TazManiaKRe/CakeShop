using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CakeShop.Models;

namespace CakeShop.Data
{
    public class CakeShopContext : DbContext
    {
        public CakeShopContext(DbContextOptions<CakeShopContext> options)
            : base(options)
        {
        }

        public DbSet<CakeShop.Models.User> User { get; set; }

        public DbSet<CakeShop.Models.Cake> Cake { get; set; }

        public DbSet<CakeShop.Models.Category> Category { get; set; }

        public DbSet<CakeShop.Models.ImageCake> ImageCake { get; set; }

        public DbSet<CakeShop.Models.Ingredients> Ingredients { get; set; }
    }
}
