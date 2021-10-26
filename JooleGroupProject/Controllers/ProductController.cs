using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JooleGroupProject.Service;
using JooleGroupProject.Data;

namespace JooleGroupProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService productService;

        public ProductController()
        {
            this.productService = new ProductService();
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
    }
}