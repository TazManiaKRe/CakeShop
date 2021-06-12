using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Models
{
    public class ImageCake
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.ImageUrl) ]
        public string URL { get; set; }
    }
}
