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
    }
}
