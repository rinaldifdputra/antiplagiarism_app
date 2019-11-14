using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Security.Principal;
using AntiPlagiarism_App.Models;
using AntiPlagiarism_App.ViewModels;

namespace AntiPlagiarism_App.Controllers
{
    public class AccountController : Controller
    {
        private antiplagiarism_dbEntities db = new antiplagiarism_dbEntities();

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                var query = from a in db.users
                            where a.username == model.username && a.password == model.password
                            select new
                            {
                                id = a.ID_user
                            };

                if(query.ToList().Count > 0)
                {
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                                                                  1,
                                                                  model.username,
                                                                  DateTime.Now,
                                                                  DateTime.Now.AddMinutes(45),  // expire
                                                                  false,  //do not remember
                                                                  query.ToList().First().id.ToString(), //string.Join(",", USERsArr),
                                                                  "/");

                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                                                        FormsAuthentication.Encrypt(
                                                        authTicket));
                    Response.Cookies.Add(cookie);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Warning = "Warning";
                    ModelState.Remove("Password");
                }
            }
            else
            {
                ViewBag.Warning = "Warning";
                ModelState.Remove("Password");
            }
            return View();
        }

        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn","Account");
        }
    }
}