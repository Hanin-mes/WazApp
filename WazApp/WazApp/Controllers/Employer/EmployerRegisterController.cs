using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WazApp.Controllers.Employer
{
    public class EmployerRegisterController : Controller
    {
        // GET: EmployerLogin
        public ActionResult Index()
        {
            return View();
        }

        // GET: EmployerLogin/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: EmployerLogin/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: EmployerLogin/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: EmployerLogin/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: EmployerLogin/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: EmployerLogin/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: EmployerLogin/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        [HttpPost]
        public JsonResult AddEmployer(WazApp.Models.SystemUsers User)
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
                    //Employer
                    User.Role = "ROL002";
                    User.AddEmployer();
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
