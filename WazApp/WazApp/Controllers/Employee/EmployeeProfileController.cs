using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WazApp.Controllers.Employee
{
    public class EmployeeProfileController : Controller
    {
        // GET: EmployeeProfile
        public ActionResult Index()
        {
            //check if user is logged (using the session).
            if ((WazApp.Models.SystemUsers)Session["LoggedUser"] != null)
            {
                WazApp.Models.SystemUsers LoggedUser = (WazApp.Models.SystemUsers)Session["LoggedUser"];
                if (LoggedUser.Role == "ROL001")
                {
                    WazApp.Models.Employee Emp = new Models.Employee();
                    Emp.UserID = LoggedUser.ID;
                    Emp = Emp.GetEmployeeByUserID();
                    return View(Emp);
                }
                else
                {
                    return Redirect("/Login");
                }
            }
            else
            {
                return Redirect("/Login");
            }




        }
        [HttpPost]
        public JsonResult UpdateEmployee(WazApp.Models.Employee emp)
        {
            try
            {
                emp.UpdateEmployee();
                return Json(new { Status = "Error", ResponseMessage = "Operation completed successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { Status = "Error", ResponseMessage = ex.Message });
            }
        }






    }
}