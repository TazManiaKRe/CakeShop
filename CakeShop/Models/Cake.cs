using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Models
{
    public class Cake
    {
        
        public int Id { get; set; }
        [Range(3,50, ErrorMessage ="Cake Title beteween 3-50") ] //only for max title
        [Required (ErrorMessage ="You must have cake title")]
        public string Title { get; set; }

        [Required (ErrorMessage ="You must have cake body")]
        public string Body { get; set; }

        //for the category

        public int CategoryId { get; set; }
        public Category Category { get; set; }



        //Image for the cakes
        [DataType(DataType.ImageUrl)]
        public ImageCake ImageCake { get; set; }

        //Ingredients
        public List<Ingredients> Ingredients { get; set; }

        [Range(0,300)]
        public int Price { get; set; }

        
    }
}
