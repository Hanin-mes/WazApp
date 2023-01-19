using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WazApp.Controllers.Login
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Login(string Email, string Password)
        {
            try
            {
                //check login credentials
                WazApp.Models.SystemUsers user = new Models.SystemUsers();
                user = user.LoginUser(Email, Password);
                if (user.ID == 0)
                {
                    return Json(new { Status = "Error", ResponseMessage = "Invalid data submitted." });
                }
                else
                {
                    Session["LoggedUser"] = user;
                    return Json(new { Status = "Success", ResponseMessage = "", User = user });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}