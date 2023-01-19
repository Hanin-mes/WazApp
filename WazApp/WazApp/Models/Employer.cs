using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WazApp.Models
{
    public class Employer
    {
        public int EmployerID { get; set; }
        public int UserID { get; set; }
        public string Position { get; set; }
        public string Website { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public Employer GetEmployerByUserID()
        {
            try
            {
                Employer empr = new Employer();
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
                    cmd.CommandText = "Employer_GetByUserID";
                    cmd.Parameters.Add(new SqlParameter("@UserID", UserID));
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
                            empr.EmployerID = Convert.ToInt32(rdr["EmployerID"]);
                            empr.UserID = Convert.ToInt32(rdr["UserID"]);
                            empr.Position = rdr["Position"].ToString();
                            empr.Website = rdr["Website"].ToString();
                            empr.CompanyName = rdr["CompanyName"].ToString();
                            empr.CompanyAddress = rdr["CompanyAddress"].ToString();
                            empr.City = rdr["City"].ToString();
                            empr.Country = rdr["Country"].ToString();

                        }
                    }
                }
                return empr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateEmployer()
        {
            try
            {
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
                    cmd.CommandText = "Employer_Update";
                    cmd.Parameters.Add(new SqlParameter("@EmployerID", EmployerID));
                    cmd.Parameters.Add(new SqlParameter("@Position", Position));
                    cmd.Parameters.Add(new SqlParameter("@Website", Website));
                    cmd.Parameters.Add(new SqlParameter("@CompanyName", CompanyName));
                    cmd.Parameters.Add(new SqlParameter("@CompanyAddress", CompanyAddress));
                    cmd.Parameters.Add(new SqlParameter("@City", City));
                    cmd.Parameters.Add(new SqlParameter("@Country", Country));
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
    }
}