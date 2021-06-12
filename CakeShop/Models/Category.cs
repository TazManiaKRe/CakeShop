using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required (ErrorMessage ="Must have category type!")]
        [Range(2,100)]
        public string Name { get; set; }

        public List<Cake> Cakes { get; set; }

       
    }
}
