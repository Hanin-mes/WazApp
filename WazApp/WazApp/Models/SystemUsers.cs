using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace WazApp.Models
{
    public class SystemUsers
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNb { get; set; }
        public int VerifiedCode { get; set; }
        public int IsVerified { get; set; }
        public string AccountStatus { get; set; }
        public string Role { get; set; }
        public string Address { get; set; }
        public string DOB { get; set; }
        public string City { get; set; }

        private void connection()
        {
            // string constr = ConfigurationManager.ConnectionStrings["SqlConn"].ToString();
            // con = new SqlConnection(constr);

        }

        public void AddEmployee()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    //Creating the command object by passing the stored procedure that is used to
                    //retrieve all the employess from the tblEmployee table and the connection object
                    //on which the stored procedure is going to execute
                    SqlCommand cmd = new SqlCommand();

                    //cmd.CommandType = CommandType.Text;
                    //cmd.CommandText = "SELECT  ID,Email,FirstName,LastName,MobileNb,VerifiedCode,IsVerified,AccountStatus,Role,Address,SystemDatefrom SystemUsers where Email="+Email;

                    //Specify the command type as stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SystemUsers_Insert_Employee";
                    cmd.Parameters.Add(new SqlParameter("@Email", Email));
                    cmd.Parameters.Add(new SqlParameter("@Password", Password));
                    cmd.Parameters.Add(new SqlParameter("@LastName", LastName));
                    cmd.Parameters.Add(new SqlParameter("@FirstName", FirstName));
                    cmd.Parameters.Add(new SqlParameter("@MobileNb", MobileNb));
                    cmd.Parameters.Add(new SqlParameter("@VerifiedCode", VerifiedCode));
                    cmd.Parameters.Add(new SqlParameter("@IsVerified", IsVerified));
                    cmd.Parameters.Add(new SqlParameter("@AccountStatus", AccountStatus));
                    cmd.Parameters.Add(new SqlParameter("@Role", Role));
                    cmd.Parameters.Add(new SqlParameter("@Address", Address));
                    cmd.Parameters.Add(new SqlParameter("@DOB", DOB));
                    cmd.Connection = con;
                    //Open the connection
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SystemUsers getUserByEmail(string Email)
        {
            try
            {
                SystemUsers user = new SystemUsers();
                string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
                //Establish the Connection to the database

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    //Creating the command object by passing the stored procedure that is used to
                    //retrieve all the employess from the tblEmployee table and the connection object
                    //on which the stored procedure is going to execute
                    SqlCommand cmd = new SqlCommand();

                    //cmd.CommandType = CommandType.Text;
                    //cmd.CommandText = "SELECT  ID,Email,FirstName,LastName,MobileNb,VerifiedCode,IsVerified,AccountStatus,Role,Address,SystemDatefrom SystemUsers where Email="+Email;

                    //Specify the command type as stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetUsersByEmail";
                    cmd.Parameters.Add(new SqlParameter("@Email", Email));
                    cmd.Connection = con;
                    //Open the connection
                    con.Open();
                    //Execute the command and stored the result in Data Reader as the method ExecuteReader
                    //is going to return a Data Reader result set
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            ////Read each employee from the SQL Data Reader and stored in employee object                    
                            user.ID = Convert.ToInt32(rdr["ID"]);
                            user.Email = rdr["Email"].ToString();
                            user.FirstName = rdr["FirstName"].ToString();
                            user.LastName = rdr["LastName"].ToString();
                            user.Address = rdr["Address"].ToString();
                            user.MobileNb = rdr["MobileNb"].ToString();
                            user.VerifiedCode = Convert.ToInt32(rdr["VerifiedCode"].ToString());
                            user.IsVerified = Convert.ToInt32(rdr["IsVerified"].ToString());
                            user.AccountStatus = rdr["AccountStatus"].ToString();
                        }
                    }
                }
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddEmployer()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    //Creating the command object by passing the stored procedure that is used to
                    //retrieve all the employess from the tblEmployee table and the connection object
                    //on which the stored procedure is going to execute
                    SqlCommand cmd = new SqlCommand();

                    //cmd.CommandType = CommandType.Text;
                    //cmd.CommandText = "SELECT  ID,Email,FirstName,LastName,MobileNb,VerifiedCode,IsVerified,AccountStatus,Role,Address,SystemDatefrom SystemUsers where Email="+Email;

                    //Specify the command type as stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SystemUsers_Insert_Employer";
                    cmd.Parameters.Add(new SqlParameter("@Email", Email));
                    cmd.Parameters.Add(new SqlParameter("@Password", Password));
                    cmd.Parameters.Add(new SqlParameter("@LastName", LastName));
                    cmd.Parameters.Add(new SqlParameter("@FirstName", FirstName));
                    cmd.Parameters.Add(new SqlParameter("@MobileNb", MobileNb));
                    cmd.Parameters.Add(new SqlParameter("@VerifiedCode", VerifiedCode));
                    cmd.Parameters.Add(new SqlParameter("@IsVerified", IsVerified));
                    cmd.Parameters.Add(new SqlParameter("@AccountStatus", AccountStatus));
                    cmd.Parameters.Add(new SqlParameter("@Role", Role));
                    cmd.Parameters.Add(new SqlParameter("@Address", Address));
                    cmd.Parameters.Add(new SqlParameter("@City", City));

                    //cmd.Parameters.Add(new SqlParameter("@DOB", DOB));
                    cmd.Connection = con;
                    //Open the connection
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SystemUsers LoginUser(string Email, string Password)
        {
            try
            {
                SystemUsers user = new SystemUsers();
                string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
                //Establish the Connection to the database

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    //Creating the command object by passing the stored procedure that is used to
                    //retrieve all the employess from the tblEmployee table and the connection object
                    //on which the stored procedure is going to execute
                    SqlCommand cmd = new SqlCommand();

                    //cmd.CommandType = CommandType.Text;
                    //cmd.CommandText = "SELECT  ID,Email,FirstName,LastName,MobileNb,VerifiedCode,IsVerified,AccountStatus,Role,Address,SystemDatefrom SystemUsers where Email="+Email;

                    //Specify the command type as stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SystemUsers_Login";
                    cmd.Parameters.Add(new SqlParameter("@Email", Email));
                    cmd.Parameters.Add(new SqlParameter("@Password", Password));
                    cmd.Connection = con;
                    //Open the connection
                    con.Open();
                    //Execute the command and stored the result in Data Reader as the method ExecuteReader
                    //is going to return a Data Reader result set
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            ////Read each employee from the SQL Data Reader and stored in employee object                    
                            user.ID = Convert.ToInt32(rdr["ID"]);
                            user.Email = rdr["Email"].ToString();
                            user.FirstName = rdr["FirstName"].ToString();
                            user.LastName = rdr["LastName"].ToString();
                            user.Address = rdr["Address"].ToString();
                            user.MobileNb = rdr["MobileNb"].ToString();
                            user.VerifiedCode = Convert.ToInt32(rdr["VerifiedCode"].ToString());
                            user.IsVerified = Convert.ToInt32(rdr["IsVerified"].ToString());
                            user.AccountStatus = rdr["AccountStatus"].ToString();
                            user.Role = rdr["Role"].ToString();
                        }
                    }
                }
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





    }
}