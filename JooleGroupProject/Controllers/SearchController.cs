using JooleGP.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JooleGP.DAL;
using JooleGP.Repo;

namespace JooleGroupProject.Controllers
{
    public class SearchController : Controller
    {
        private readonly ReportsBLL catService;
         
        // GET: Search
     
     public SearchController()
        {
            catService = new ReportsBLL();
        }
        public ActionResult Index()
        {

            IEnumerable<tblCategory> cat = this.catService.getCategory();

            return View(cat);
        }
        public ActionResult getProd(int x)
        {
            IEnumerable<tblProduct> prod = catService.getProducts(x);

            return View(prod);
        }
    }
}