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
        private readonly PropertyService propertyService;

        public ProductController()
        {
            this.productService = new ProductService();
            this.propertyService = new PropertyService();
        }
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductSummary()
        {
            
            //ProductSummaryViewModel viewModel = new ProductSummaryViewModel();
            IEnumerable<tblProduct> products = this.productService.GetByProductsBySubCategory(1);
            /*
            foreach (tblProduct p in products)
            {
                ProductViewModel pViewModel = new ProductViewModel();
                Dictionary<string,string> techSpecs = propertyService.GetTechSpecsByProductId(p.Product_ID);
                pViewModel.Product = p;
                pViewModel.TechSpecsProps = techSpecs;
                viewModel.Products.Add(pViewModel);
            }
            */

            return View(products);
        }

        public ActionResult ProductDetails(int productId = 1)
        {
            ProductViewModel viewModel = new ProductViewModel();
            viewModel.Product = productService.GetProduct(productId);
            viewModel.TechSpecsProps = propertyService.GetTechSpecsByProductId(productId);
            return View(viewModel);
        }
    }
}