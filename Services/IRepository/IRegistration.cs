using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRepository
{
    /// <summary>
    /// This Interface provides method which can be implemented for user registration.
    /// </summary>
   public interface IRegistration
    {
        /// <summary>
        /// Used to add new user to the table.
        /// </summary>
        /// <param name="registration"></param>
        void AddUser(Registration registration);

        /// <summary>
        /// Used to update the user details.
        /// </summary>
        /// <param name="registration"></param>
        void UpdateUser(Registration registration);

        /// <summary>
        /// Used to check the duplicacy of the email.
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        bool CheckEmailExists(string Email);

        
       

    }
}
