using StateManagementLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateManagementLab.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.CurrentUser = (User)Session["CurrentUser"];
            return View();
        }

        public ActionResult Register(string Message)
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Welcome(User newUser)
        {
            if (Session["AllUsers"] != null)
            {
                Session["AllUsers"] = new List<User>();
            }
            else
            {
                List<User> AllUsers = new List<User> { new User("Kent", "Butler", "photokentbutler@gmail.com", 35, "password", "password") };
            }

            if(string.IsNullOrEmpty(newUser.ConfirmPassword))
            {// this is for existing user logging in
                foreach (User user in AllUsers)
                {// searches list for email address entered and checks if it exisists.
                    if (user.Email == newUser.Email)
                    {
                        if (user.Password == newUser.Password)
                        {
                            ViewBag.CurrentUser = user;
                            Session["CurrentUser"] = user;

                            return View();
                        }
                        else
                        {
                            ViewBag.ErrorMessage = "Login failed. Try again.";
                            return RedirectToAction("Login");
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Login failed. Try again.";
                        return RedirectToAction("Login");
                    }
                }
            }


            if (newUser.Password != newUser.ConfirmPassword)
            {
                return RedirectToAction("Register", new { message = "Error: Passwords did not match" });
            }

            if (Session["CurrentUser"] != null)
            {
                
                newUser = (User)Session["CurrentUser"];
                ViewBag.CurrentUser = newUser;
            }

            if (ModelState.IsValid)
            {
                ViewBag.CurrentUser = newUser;
                Session["CurrentUser"] = newUser;
                AllUsers.Add(newUser);
                return View();
            }
            else
            {
                ViewBag.ErrorMessage = "Registration failed. Try again.";
                return RedirectToAction("Register");
            }

        }

        public ActionResult About()
        {
            ViewBag.CurrentUser = (User)Session["CurrentUser"];
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.CurrentUser = (User)Session["CurrentUser"];
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult LogOut()
        {
            Session.Remove("CurrentUser");
            return RedirectToAction("Index");
        }
    }
}