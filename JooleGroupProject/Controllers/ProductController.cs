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
        private readonly FilterService filterService;

        private ProductViewModel GenerateProductViewModel(int productId)
        {
            //TODO: Get manufacturer name from manufacturer ID
            ProductViewModel viewModel = new ProductViewModel();
            viewModel.Product = productService.GetProduct(productId);
            viewModel.TechSpecsProps = propertyService.GetTechSpecs(productId);
            viewModel.TypeProps = propertyService.GetTypeProps(productId);
            return viewModel;
        }

        public ProductController()
        {
            this.productService = new ProductService();
            this.propertyService = new PropertyService();
            this.filterService = new FilterService();
        }
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductSummary(int subCatId = 1)
        {
            ProductSummaryViewModel viewModel = new ProductSummaryViewModel();
            IEnumerable<tblProduct> products = this.productService.GetByProductsBySubCategory(subCatId);
            foreach(tblProduct p in products)
            {
                ProductViewModel productViewModel = GenerateProductViewModel(p.Product_ID);

                viewModel.Products.Add(productViewModel);
            }
            Dictionary<string, List<string>> typeFilters = this.filterService.getTypeFiltersBySubCatId(subCatId);
            viewModel.TypeFilters = typeFilters;

            return View(viewModel);
        }

        public ActionResult ProductDetails_placeholder(int productId = 1)
        {
            ProductViewModel viewModel = GenerateProductViewModel(productId);

            return View(viewModel);
        }

        public ActionResult ProductCompare_placeholder()
        {
            List<ProductViewModel> viewModels = new List<ProductViewModel>();
            viewModels.Add(GenerateProductViewModel(1));
            viewModels.Add(GenerateProductViewModel(2));
            viewModels.Add(GenerateProductViewModel(3));
            return View(viewModels);
        }
    }
}