using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Models
{
    public class Category
    {
        //one to many
        //every category have many cakes


        //Id
        public int Id { get; set; }
         

        //Category name - need to fix
        [Required (ErrorMessage ="Must have category type!")]
        [MinLength(2), MaxLength(100)]
        public string Name { get; set; }


        //List of cakes
        //for every category there is a list of cakes
        public List<Cake> Cakes { get; set; }

       
    }
}
