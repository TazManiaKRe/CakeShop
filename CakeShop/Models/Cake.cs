using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Models
{
    public class Cake
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        //for the category
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        //Image for the cakes

        public ImageCake ImageCake { get; set; }

        //Ingredients
        public List<Ingredients> Ingredients { get; set; }

    }
}
