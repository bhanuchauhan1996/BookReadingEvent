using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// This class holds information regarding the role of user
    /// </summary>
    [Table("RoleUser")]
    public class Role
    {
        /// <summary>
        /// It represents the role id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// It is UserId of the user for that particular role
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// It holds name of the role.
        /// </summary>
        public string RoleName
        {
            get; set;
        }
    }
}
