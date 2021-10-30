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
            tblUser userDetail = null;

            var inputUserName = tUser.User_Name.ToString();

            if (ModelState.IsValid)
            {
                using (JooleAppDBEntities jdb = new JooleAppDBEntities())
                {
                    //SignUp
                    if (jdb.tblUsers.Any(userName => userName.User_Name == tUser.User_Name))
                    {
                        ViewBag.Message = "The User Name already exist!";
                        return View("LoginPage",tUser);
                    }
                    else
                    {
                        jdb.tblUsers.Add(tUser);
                        jdb.SaveChanges();
                        ViewBag.SuccessMessage = "Registration Successful!";
                                             
                    }
                    //Login
                    if (inputUserName.Contains("@"))
                    {
                        tUser.User_Email = inputUserName;
                        userDetail = jdb.tblUsers.Where(userLogin => userLogin.User_Email == tUser.User_Email && userLogin.User_Password == tUser.User_Password).FirstOrDefault();
                    }
                    else
                    {
                        userDetail = jdb.tblUsers.Where(userLogin => userLogin.User_Name == inputUserName && userLogin.User_Password == tUser.User_Password).FirstOrDefault();
                    }

                    if (userDetail == null)
                    {
                        tUser.LoginErrorMessage = "Wrong User Name/Email or Password!";
                        return View("LoginPage", tUser);
                    }
                    else
                    {
                        HttpPostedFileBase file = Request.Files["Imgfile"];
                        if (file != null && file.ContentLength !=0)
                        {
                            string fileName = Path.GetFileNameWithoutExtension(tUser.Imgfile.FileName);
                            string extension = Path.GetExtension(tUser.Imgfile.FileName);
                            fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                            tUser.User_Image = fileName;
                            tUser.Imgfile.SaveAs(Path.Combine(Server.MapPath("~/Images"), fileName));
                            jdb.tblUsers.Add(tUser);
                            jdb.SaveChanges();
                        }
                        Session["User_Name"] = userDetail.User_Name;
                        Session["User_Email"] = userDetail.User_Email;

                        return View("LoginPage", tUser);
                    }
                }
            }
                //return to product search
                return RedirectToAction("Index", "Home");
        }
    }

}