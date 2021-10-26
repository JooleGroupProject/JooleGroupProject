﻿using JooleGroupProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JooleGroupProject.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: UserLogin
        public ActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(tblUser tUser)
        {
            using (JooleAppDBEntities db = new JooleAppDBEntities())
            {
                var userDetail = db.tblUsers.Where(userLogin => userLogin.User_Name == tUser.User_Name && userLogin.User_Password == tUser.User_Password ||
                                                  (userLogin.User_Email == tUser.User_Email && userLogin.User_Password == tUser.User_Password)).FirstOrDefault();
                if (userDetail == null)
                {
                    tUser.LoginErrorMessage = "Wrong User Name or Password!";
                    return View("LoginPage", tUser);
                }
                else
                {
                    Session["User_Name"] = userDetail.User_Name;
                    Session["User_Email"] = userDetail.User_Email;

                    var userName = Session["User_Name"];
                    var userEmail = Session["User_Email"];
                    //return to searching page
                    return RedirectToAction("Index", "Home");
                }
            }


        }


        public ActionResult SignUpPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(tblUser tUser)
        {
            if (ModelState.IsValid)
            {
                using (JooleAppDBEntities jdb = new JooleAppDBEntities())
                {
                    if (jdb.tblUsers.Any(userName => userName.User_Name == tUser.User_Name))
                    {
                        ViewBag.DuplicateMessage = "The User Name already exist!";
                        return View("SignUpPage", tUser);
                    }
                    jdb.tblUsers.Add(tUser);
                    jdb.SaveChanges();
                }
                tUser = null;
                ViewBag.SuccessMessage = "Registration Successful!";
            }
            return View("SignUpPage", tUser);
        }

        public ActionResult SignUp(HttpPostedFileBase imgfile)
        {
            if (imgfile != null && imgfile.ContentLength > 0)
            {
                string imgname = Path.GetFileName(imgfile.FileName);
                string imgext = Path.GetExtension(imgname);
                string imgpath = Path.Combine(Server.MapPath("~/Images"), imgname);
                imgfile.SaveAs(imgpath);

            }
            return View();
        }
    }
}