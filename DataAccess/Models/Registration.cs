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
    /// This class is used to hold registration Information
    /// </summary>
    [Table("Registration")]
    public class Registration
    {
        /// <summary>
        /// It Represents User ID for the user
        /// </summary>
        [Key]
        public int UserId { get; set; }

        /// <summary>
        /// It Represents Name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// It Represents email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// It Represents password of the user
        /// </summary>
        public string Password { get; set; }

    }
}
