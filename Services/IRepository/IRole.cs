using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRepository
{
    /// <summary>
    /// This Interface is to Implement Role Based Authentication
    /// </summary>
   public interface IRole
    {
        /// <summary>
        /// Used to add role for the users in the database
        /// </summary>
        /// <param name="UserId"></param>
        void AddRole(int UserId);
      
    }
}
