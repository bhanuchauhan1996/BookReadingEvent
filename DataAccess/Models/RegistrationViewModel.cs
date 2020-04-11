using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// It represents view for the registration class
    /// </summary>
    public class RegistrationViewModel
    {
        /// <summary>
        /// It Represents User ID for the user
        /// </summary>
        [Key]
        public int UserId { get; set; }

        /// <summary>
        /// It Represents Name of the user
        /// </summary>
        [Required]
        [RegularExpression("^[a-zA-Z\\s]{3,20}$", ErrorMessage = "Please enter string only between (3-20).")]
        public string Name { get; set; }

        /// <summary>
        /// It Represents email of the user
        /// </summary>
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("[^@]+@[^@]+\\.[^@]+$", ErrorMessage="Please enter valid email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>
        /// It Represents password of the user
        /// </summary>
        [Required(ErrorMessage ="Password is Required")]
        [MinLength(5, ErrorMessage = "Minimum Password must be 5 in charaters")]
        [DataType(DataType.Password)]
       [RegularExpression("^.*(?=.*\\d)(?=.*[a-zA-Z])(?=.*[!*@#$%^&+=]).*$", ErrorMessage = "Password must contains one digit,one alphabet and one special character ")]
        public string Password { get; set; }

        /// <summary>
        /// Holds the password Confirmation
        /// </summary>
        [Display(Name="Confirm Password")]
        [Compare("Password", ErrorMessage = "Please Enter the same password as above")]
        public string ConfirmPassword { get; set; }
    }
}
