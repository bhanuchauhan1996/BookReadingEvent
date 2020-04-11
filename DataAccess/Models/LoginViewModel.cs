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
    /// This class contains Login Info
    /// </summary>
    [NotMapped]
   public class LoginViewModel
    {
        /// <summary>
        /// Id of user to be logged in
        /// </summary>
        /// 
        [Key]
        public int UserId { get; set; }

        /// <summary>
        /// Name of the logged in user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Email of the logged in user
        /// </summary>
        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }

        /// <summary>
        /// password field for login
        /// </summary>
        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }
    }
}
