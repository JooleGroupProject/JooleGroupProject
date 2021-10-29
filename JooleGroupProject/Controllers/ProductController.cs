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
        public SearchModel viewModel;

        public ProductController()
        {
            this.productService = new ProductService();
            this.propertyValueService = new PropertyValueService();
            this.viewModel = new SearchModel();
        }
        // GET: Product
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult ProductSummary()
        {            
            IEnumerable<tblProduct> products = this.productService.GetByProductsBySubCategory(1);
            
            return View(products);
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

    }
}