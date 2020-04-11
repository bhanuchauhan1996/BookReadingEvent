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
    /// This class implements the IRole interface which provide us role based authorization
    /// </summary>
    public class RoleRepo : IRole
    {
        /// <summary>
        /// Used to add role for the users in the database
        /// </summary>
        /// <param name="UserId"></param>
        public void AddRole(int UserId)
        {
            
                string connectionString =
                        ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddRole", con);
                    cmd.CommandType = CommandType.StoredProcedure;


                SqlParameter paramUserId = new SqlParameter();
                paramUserId.ParameterName = "@UserId";
                paramUserId.Value = UserId;
                cmd.Parameters.Add(paramUserId);

                SqlParameter paramName = new SqlParameter();
                    paramName.ParameterName = "@Name";
                    paramName.Value ="User";
                    cmd.Parameters.Add(paramName);

                    


                    con.Open();
                    cmd.ExecuteNonQuery();
                }

              
            }
            
        
    }
}
