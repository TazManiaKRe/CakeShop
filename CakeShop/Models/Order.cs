using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Models
{
    public class Order
    {


        public int Id { get; set; }

        [Required]
        //cannot be null - must be atleast one
        public List<Cake> Cakes { get; set; }

        //how much for all the list cakes
        public int Totalprice { get; set; }

        //must
        [Required]
        public User Userorder { get; set; }

        //must
        [Required]
        public string Adreess { get; set; }

        [Required]
        [DataType(DataType.CreditCard) ]
        public int Craditcard { get; set; }
    }
}
