using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WazApp.Controllers.Employee
{
    public class EmployeeRegisterController : Controller
    {
        // GET: EmployeeLogin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddEmployee(WazApp.Models.SystemUsers User)
        {
            try
            {
                //set user details
                //1 check if email already registered
                WazApp.Models.SystemUsers registerdUser = User.getUserByEmail(User.Email);
                if (registerdUser.Email != null)
                {
                    return Json(new { Status = "Error", ResponseMessage = "Email already registered." });
                }
                else
                {
                    //2 set user details
                    //3 insert into table Users
                    //4 if user type(role) is employee => insert into employee table else insert into employer table
                    User.IsVerified = 1;
                    int _min = 1000;
                    int _max = 9999;
                    Random _rdm = new Random();
                    User.VerifiedCode = _rdm.Next(_min, _max);
                    User.AccountStatus = "A";
                    //Employee
                    User.Role = "ROL001";
                    User.AddEmployee();
                    return Json(new
                    {
                        Status = "Success",
                        ResponseMessage = "Account registered successfuly."
                    });

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}