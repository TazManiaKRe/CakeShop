using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Cake> Cakes { get; set; }

       
    }
}
