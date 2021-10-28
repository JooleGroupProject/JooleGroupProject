using JooleGP.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JooleGP.DAL;
using JooleGP.Repo;
using System.Web.Services;
using JooleGroupProject.Models;

namespace JooleGroupProject.Controllers
{
    public class SearchController : Controller
    {
        private readonly ReportsBLL catService;
        public SearchModel viewModel;
        // GET: Search
     
        public SearchController()
        {
            catService = new ReportsBLL();
            viewModel = new SearchModel();
        }
        public ActionResult Index()
        {

            viewModel.Categories = this.catService.getCategory().ToList();
            viewModel.CurrentList = this.catService.getProducts(1).ToList();
          

                return View(viewModel);
        }
    
        [HttpPost]
        public JsonResult GetProdName(string Prefix)
        {

            var Countries = from c in this.catService.getProducts(1)
                             where c.Product_Name.StartsWith(Prefix)
                             select new { c.Product_Name };
            Console.WriteLine(Countries.ToString());
    
            return Json(Countries, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Index(string CustomerName)
        {
            return View(viewModel);
        }
        public ActionResult ProductSearchBar()
        {
            return View();
        }
       
    }
}