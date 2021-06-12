using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CakeShop.Models
{

    public enum UserType { Guest, Buyer, Mod, Admin } //guest =1 and so on..
    //crating users for the cake shop
    public class User
    {

        public int Id { get; set; }


        [Required]
        public string UserName { get; set; }

        //regex [1 Capital letter min, 1 small 1 spaciel char]
        //"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$"
        //regex [1 Capital letter min, 1 smaall letter]
        //"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"

        [Required]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

       

        public UserType Type { get; set; } = UserType.Guest;

        //ask about first name, last name.. etc..
        /*
        [Range(1, 20)]
        [Required(ErrorMessage = "You don't have first name?")]
        public string Firstname { get; set; }

        [Range(1, 20)]
        [Required(ErrorMessage = "You don't have first name?")]
        public string Lastname { get; set; }

        
        public string  Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int Phone { get; set; }
        */
       //we have to update it!

    }
}
