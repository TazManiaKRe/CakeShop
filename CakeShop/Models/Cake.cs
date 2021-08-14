using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Models
{
    public class Cake
    {
        //An Id for cake
        public int Id { get; set; }

        //Title
        [MinLength(3), MaxLength(50)]
        [Required (ErrorMessage ="You must have cake title")]
        public string Title { get; set; }


        //Body
        [Required (ErrorMessage ="You must have cake body")]
        public string Body { get; set; }

        //Category id and category
        //Have to change the view to see the category name
        [Display(Name = "Category Id")]
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }



        //Image
        [Required]
        [Display(Name = "Photo url")]
        public string PhotosUrl1 { get; set; }
        [Display(Name = "Photo url")]
        [Required]
        public string PhotosUrl2 { get; set; }
        [Display(Name = "Photo url")]
        [Required]
        public string PhotosUrl3 { get; set; }
        [Display(Name = "Photo url")]
        [Required]
        public string PhotosUrl4 { get; set; }


        //Ingredients
        //public List<Ingredients> Ingredients { get; set; }
        //maybe not?



        //Price 
        [Range(0,300)]
        public int Price { get; set; }

        public List<Cart> Carts { get; set; }
    }
}
