using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WazApp.Controllers.Employer
{
    public class EmployerProfileController : Controller
    {
        // GET: EmployerProfile
        public ActionResult Index()
        {
            //check if user is logged (using the session).

            if ((WazApp.Models.SystemUsers)Session["LoggedUser"] != null)
            {
                WazApp.Models.SystemUsers LoggedUser = (WazApp.Models.SystemUsers)Session["LoggedUser"];
                if (LoggedUser.Role == "ROL002")
                {
                    WazApp.Models.Employer Empr = new Models.Employer();
                    Empr.UserID = LoggedUser.ID;
                    Empr = Empr.GetEmployerByUserID();
                    return View(Empr);
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
        public JsonResult UpdateEmployer(WazApp.Models.Employer empr)
        {
            try
            {
                empr.UpdateEmployer();
                return Json(new { Status = "Error", ResponseMessage = "Operation completed successfully." });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}