using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace WazApp.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public int UserID { get; set; }
        public string Skills { get; set; }
        public string ImagePath { get; set; }
        public string CvPath { get; set; }
        public string DOB { get; set; }
        public string Description { get; set; }

        public Employee GetEmployeeByUserID()
        {
            try
            {
                Employee emp = new Employee();
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
                    cmd.CommandText = "Employee_GetByUserID";
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
                            emp.EmployeeID = Convert.ToInt32(rdr["EmployeeID"]);
                            emp.UserID = Convert.ToInt32(rdr["UserID"]);
                            emp.CvPath = rdr["CvPath"].ToString();
                            emp.Skills = rdr["Skills"].ToString();
                            emp.ImagePath = rdr["ImagePath"].ToString();
                            emp.DOB = rdr["DOB"].ToString();
                            emp.Description = rdr["Description"].ToString();
                        }
                    }
                }
                return emp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateEmployee()
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
                    cmd.CommandText = "Employee_Update";
                    cmd.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID));
                    cmd.Parameters.Add(new SqlParameter("@Skills", Skills));
                    cmd.Parameters.Add(new SqlParameter("@ImagePath", ImagePath));
                    cmd.Parameters.Add(new SqlParameter("@CvPath", CvPath));
                    cmd.Parameters.Add(new SqlParameter("@DOB", DOB));
                    cmd.Parameters.Add(new SqlParameter("@Description", Description));
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