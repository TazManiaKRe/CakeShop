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


        [Required] //user must do
        public string UserName { get; set; }
        public ClaimsIdentity Username { get; internal set; }
        [Required]
        [DataType (DataType.Password)]
        //regex [1 Capital letter min, 1 small 1 spaciel char]
        //"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$"
        //regex [1 Capital letter min, 1 smaall letter]
        //"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"
        public string  PassWord { get; set; }

        public UserType Type { get; set; } = UserType.Guest;

    }
}
