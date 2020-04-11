using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataAccess.Models
{
    /// <summary>
    /// This class extends DbContext class which is used to communicate with the database.
    /// </summary>
   public class DatabaseContext :DbContext
    {
        public DatabaseContext():base("name=DatabaseContext")
        {

        }

        /// <summary>
        /// This Property represent the Event model class.
        /// </summary>
        public DbSet<Event> Events { get; set; }

        /// <summary>
        /// This Property represent the Registration model class.
        /// </summary>
        public DbSet<Registration> Registrations { get; set; }

        /// <summary>
        /// This Property represent the Role model class.
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// This Property represent the Registration View model class.
        /// </summary>
        public DbSet<DataAccess.Models.RegistrationViewModel> RegistrationViewModels { get; set; }

       // public System.Data.Entity.DbSet<DataAccess.Models.LoginViewModel> LoginViewModels { get; set; }
    }
}
