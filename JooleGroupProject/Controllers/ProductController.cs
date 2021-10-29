using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JooleGroupProject.Service;
using JooleGroupProject.Data;
using JooleGroupProject.Models;

namespace JooleGroupProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService productService;
        private readonly PropertyValueService propertyValueService;
        private readonly CategoryService catService;
        public SearchModel viewModel;
        public JooleModel mai;
            

        public ProductController()
        {
            this.productService = new ProductService();
            this.catService = new CategoryService();
            this.propertyValueService = new PropertyValueService();
            this.viewModel = new SearchModel();
            this.mai = new JooleModel();
        }
        // GET: Product
        public ActionResult Index()
        {
            viewModel.Categories = this.catService.getCategory().ToList();
            mai.SearchView = viewModel;
            return View(mai);
        }
        [HttpPost]
        public ActionResult Index(string CustomerName)
        {
            mai.SearchView = viewModel;
            return View(mai);
        }
        public ActionResult ProductSummary()
        {            
            IEnumerable<tblProduct> products = this.productService.GetByProductsBySubCategory(1);
            mai.Products = products;
            return View(mai);
        }

        public ActionResult ProductDetail(int id)
        {
            ViewData["tblProducts"] = productService.GetProductDetails(id);
            ViewData["UseType"] = propertyValueService.GetUseTypeByProductId(id);
            ViewData["Application"] = propertyValueService.GetApplicationByProductId(id);
            ViewData["Accessories"] = propertyValueService.GetAccessoriesByProductId(id);
            ViewData["Airflow"] = propertyValueService.GetAirflowByProductId(id);
            ViewData["Power"] = propertyValueService.GetPowerByProductId(id);
            ViewData["OperatingVoltage"] = propertyValueService.GetOperatingVoltageByProductId(id);
            ViewData["FanSpeed"] = propertyValueService.GetFanSpeedByProductId(id);
            ViewData["NumFanSpeed"] = propertyValueService.GetNumFanSpeedByProductId(id);
            ViewData["SoundAtMaxSpeed"] = propertyValueService.GetSoundAtMaxSpeedByProductId(id);
            
            //viewModel.Categories = this.catService.getCategory().ToList();
            //ViewData["Dropdown"] = viewModel.Categories;
            //ViewData["SearchBar"] = viewModel.autoComp;
            return View();

        }
        public ActionResult ProductSearchBar()
        {
            return View();
        }
        public ActionResult CategoryDropdown()
        {
            viewModel.Categories = this.catService.getCategory().ToList();
            mai.SearchView = viewModel;
            return View(mai);
        }
        [HttpPost]
        public JsonResult GetProdName(string Prefix, int catID)
        {
            if (catID < 1)
            {
                catID = 1;
            }
            var Products = from c in this.catService.getProducts(catID)
                           where c.Product_Name.StartsWith(Prefix)
                           select new { c.Product_Name };
            Console.WriteLine(Products.ToString());

            return Json(Products, JsonRequestBehavior.AllowGet);
        }

    }
}