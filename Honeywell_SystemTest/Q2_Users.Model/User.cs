using System;
using System.ComponentModel.DataAnnotations;


namespace Users.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        
        [MaxLength(50), Required(ErrorMessage = "Please Provide FirstName")]
        public string FirstName { get; set; }

        
        [MaxLength(50), Required(ErrorMessage = "Please Provide LastName")]
        public string LastName { get; set; }

        
        [MaxLength(50), EmailAddress, Required(ErrorMessage = "Please Provide Email")]
        public string Email { get; set; }

        
        [MaxLength(50), Required(ErrorMessage = "Please Provide UserName")]
        public string UserName { get; set; }

        
        [MaxLength(50), Required(ErrorMessage = "Please Provide Address")]
        public string Address { get; set; }
        public int Age { get; set; }
    }
}
