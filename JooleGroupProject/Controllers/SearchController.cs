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

                return View(viewModel);
        }
    
        [HttpPost]
        public JsonResult GetProdName(string Prefix, int catID)
        {
            if(catID < 1)
            {
                catID = 1;
            }
            var Products = from c in this.catService.getProducts(catID)
                             where c.Product_Name.StartsWith(Prefix)
                             select new { c.Product_Name };
            Console.WriteLine(Products.ToString());
    
            return Json(Products, JsonRequestBehavior.AllowGet);
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