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
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        public ClaimsIdentity Username { get; internal set; }
      
        [Required]
        [DataType (DataType.Password)]
        //regex [1 Capital letter min, 1 small 1 spaciel char]
        //"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$"
        //regex [1 Capital letter min, 1 smaall letter]
        //"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"  
        [StringLength(100, ErrorMessage = "The{0} must be at least {2} and at max {1} characters long", MinimumLength = 6)]
        [Display(Name = "Password")]
        public string  Password { get; set; }
        
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
       
        public string Email { get; set; }
       
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
       
        public UserType Type { get; set; } = UserType.Guest;

        [Display (Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Day Of Birth")]
        public DateTime DayOfBirth { get; set; }




    }
}
