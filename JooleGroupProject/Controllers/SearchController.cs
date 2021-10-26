using JooleGP.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JooleGroupProject.Models;

namespace JooleGroupProject.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getCat()
        {
            List<Category> cat = (List<Category>)new ReportsBLL().getCategory();

            return View(cat);
        }
        public ActionResult getProd(int x)
        {
            List<Product> prod = (List<Product>)new ReportsBLL().getProducts(x);

            return View(prod);
        }
    }
}