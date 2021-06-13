﻿using System;
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
        [Range(3,50, ErrorMessage ="Cake Title beteween 3-50") ] //only for max title
        [Required (ErrorMessage ="You must have cake title")]
        public string Title { get; set; }


        //Body
        [Required (ErrorMessage ="You must have cake body")]
        public string Body { get; set; }

        //Category id and category
        //Have to change the view to see the category name
        public int CategoryId { get; set; }
        public Category Category { get; set; }



        //Image
        [DataType(DataType.ImageUrl)]
        public ImageCake ImageCake { get; set; }


        //Ingredients
        public List<Ingredients> Ingredients { get; set; }

        //Price can be null?
        [Range(0,300)]
        public int Price { get; set; }

        
    }
}
