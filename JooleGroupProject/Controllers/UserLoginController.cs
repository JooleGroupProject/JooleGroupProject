using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JooleGroupProject.Data;


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
                tblUser userDetail = null; 
                var inputUserName = tUser.User_Name.ToString();

                if (inputUserName.Contains("@"))
                {
                    tUser.User_Email = inputUserName;
                    userDetail = db.tblUsers.Where(userLogin =>userLogin.User_Email == tUser.User_Email && userLogin.User_Password == tUser.User_Password).FirstOrDefault();
                }
                else
                {
                    userDetail = db.tblUsers.Where(userLogin => userLogin.User_Name == inputUserName && userLogin.User_Password == tUser.User_Password).FirstOrDefault();
                }
                
                if (userDetail == null)
                {
                    tUser.LoginErrorMessage = "Wrong User Name/Email or Password!";
                    return View("LoginPage", tUser);
                }
                else
                {
                    Session["User_Name"] = userDetail.User_Name;
                    Session["User_Email"] = userDetail.User_Email;

                    var userName = Session["User_Name"];
                    var userEmail = Session["User_Email"];
                    //return to searching page
                    return RedirectToAction("Index", "Search");
                }
            }


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
                       //Session["User_name"] = tUser.User_Name;
                       //var em = Session["User_name"].ToString();
                       //ViewBag.DuplicateEmail = "The Email Exists, The User Name is " + em;
                        return View("LoginPage", tUser);
                    }else if (jdb.tblUsers.Any(userEmail => userEmail.User_Email == tUser.User_Email))
                    {
                        var obj = jdb.tblUsers.Where(userDetail => userDetail.User_Email == tUser.User_Email).Select(userName => userName.User_Name).SingleOrDefault();
                        if (obj != null)
                        {
                            ViewBag.DuplicateEmail = "The Email already exist! and Your User Name: " + obj;
                        }
                        return View("LoginPage", tUser);
                    }
                    else
                    {
                        HttpPostedFileBase file = Request.Files["Imgfile"];
                        if (file != null && file.ContentLength != 0)
                        {
                            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                            string extension = Path.GetExtension(file.FileName);
                            fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                            tUser.User_Image = fileName;
                            tUser.Imgfile.SaveAs(Path.Combine(Server.MapPath("~/Images"), fileName));
                        }
                            jdb.tblUsers.Add(tUser);
                            jdb.SaveChanges();
                    }
                }
                tUser = null;
                ViewBag.SuccessMessage = "Registration Successful!";
            }
            return View("LoginPage", tUser);
        }
    }
}