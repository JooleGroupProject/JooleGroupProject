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

                    //var userName = Session["User_Name"];
                    //var userEmail = Session["User_Email"];
                    //return to searching page
                    return RedirectToAction("Index", "Home");
                }
            }


        }

        /*
        public ActionResult Index()
        {
            JooleAppDBEntities entities = new JooleAppDBEntities();
            return View(entities.tblUsers.ToList());
        }

        [HttpPost]
        public JsonResult CheckDuplicate(tblUser alluser)
        {
            try
            {
                using (JooleAppDBEntities db = new JooleAppDBEntities())
                {
                    List<tblUser> customers = db.tblUsers.Where(x => x.User_Name == alluser.User_Name || x.User_Email == alluser.User_Email).ToList();
                    if (customers.Count >0)
                    {
                        TempData["Message"] = "<script>alert('The User Name already exist!');</script>";
                        
                    }
                    else
                    {
                        db.tblUsers.Add(alluser);
                        db.SaveChanges();
                    }

                }
            }
            catch (Exception)
            {

            }
            return Json(alluser);
        }
        */
        
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
                                return RedirectToAction("SignUp");
                            }
                            jdb.tblUsers.Add(tUser);
                            jdb.SaveChanges();
                        }
                        tUser = null;
                        ViewBag.SuccessMessage = "Registration Successful!";
                    }
                    return View("LoginPage",tUser);
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