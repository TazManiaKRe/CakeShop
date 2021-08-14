/*using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Models
{
    public class ImageCake
    {

        //one to one
        //every cake have only one image

        public int Id { get; set; }


        //Image name
        public string Name { get; set; }

        //URL for cake - maybe add a upload as well
        [DataType(DataType.ImageUrl) ]
        public string URL { get; set; }
    }
}
*/