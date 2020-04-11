using DataAccess.Models;
using Services.IRepository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repository
{
    /// <summary>
    /// This class implement the Registration Interface
    /// </summary>
    public class RegistrationRepo : IRegistration
    {
        private string connectionString =
                  ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString;

        private DatabaseContext databaseContext;

        /// <summary>
        /// Parameterized constructor to initialize database
        /// </summary>
        /// <param name="databaseContext"></param>
        public RegistrationRepo(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        /// <summary>
        /// Default constructor to allocate memory to database object.
        /// </summary>
        public RegistrationRepo()
        {
            databaseContext = new DatabaseContext();
        }

        /// <summary>
        /// Used to add new user to the table.
        /// </summary>
        /// <param name="registration"></param>
        public void AddUser(Registration registration)
        {
           

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = registration.Name;
                cmd.Parameters.Add(paramName);

           

                SqlParameter paramEmail = new SqlParameter();
                paramEmail.ParameterName = "@Email";
                paramEmail.Value = registration.Email;
                cmd.Parameters.Add(paramEmail);

                SqlParameter paramPassword = new SqlParameter();
                paramPassword.ParameterName = "@Password";
                paramPassword.Value = registration.Password;
                cmd.Parameters.Add(paramPassword);

                
                con.Open();
                cmd.ExecuteNonQuery();
            }
        
        
    }

        /// <summary>
        /// Used to check the duplicacy of the email.
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public bool CheckEmailExists(string Email)
        {
            var result = (from user in databaseContext.Registrations
                          where user.Email == Email
                          select user).Count();

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Used to update the user details.
        /// </summary>
        /// <param name="registration"></param>
        public void UpdateUser(Registration registration)
        {
           
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@UserId";
                paramId.Value =registration.UserId;
                cmd.Parameters.Add(paramId);

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = registration.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramEmail = new SqlParameter();
                paramEmail.ParameterName = "@Email";
                paramEmail.Value = registration.Email;
                cmd.Parameters.Add(paramEmail);

                SqlParameter paramPassword = new SqlParameter();
                paramPassword.ParameterName = "@Password";
                paramPassword.Value = registration.Password;
                cmd.Parameters.Add(paramPassword);
                
                con.Open();
                cmd.ExecuteNonQuery();
            }

        
    }

        
    }
}
