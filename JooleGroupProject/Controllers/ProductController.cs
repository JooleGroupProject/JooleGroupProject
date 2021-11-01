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

        private readonly PropertyValueService propertyValueService;
        private readonly CategoryService catService;
        public SearchModel viewModel;
        public JooleModel mai;


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

        public ActionResult ProductSummary(int subCatId = 1)
        {
            ProductSummaryViewModel viewModel = new ProductSummaryViewModel();
            IEnumerable<tblProduct> products = this.productService.GetByProductsBySubCategory(subCatId);
            foreach (tblProduct p in products)
            {
                ProductViewModel productViewModel = GenerateProductViewModel(p.Product_ID);

                viewModel.Products.Add(productViewModel);
            }
            viewModel.TypeFilters = this.filterService.getTypeFiltersBySubCatId(subCatId);
            viewModel.TechSpecFilters = this.filterService.GetTechSpecFiltersBySubCat2(subCatId).ToList();

            IEnumerable<tblSpecFilter> filters = this.filterService.GetTechSpecFiltersBySubCat2(subCatId);
            foreach (tblSpecFilter f in filters)
            {
                System.Diagnostics.Debug.WriteLine(f.tblProperty.Property_ID);
            }

            return View(viewModel);
        }

        public ActionResult ProductDetails_placeholder(int productId = 1)
        {
            ProductViewModel viewModel = GenerateProductViewModel(productId);

            return View(viewModel);
        }

        public ActionResult SubmitCompare(ProductSummaryViewModel obj)
        {
            List<ProductViewModel> viewModels = new List<ProductViewModel>();
            foreach (ProductViewModel p in obj.Products)
            {
                if (p.IsChecked)
                {
                    viewModels.Add(GenerateProductViewModel(p.Product.Product_ID));
                }
            }
            return View("ProductCompare_placeholder", viewModels);
        }

        public ActionResult ProductCompare_placeholder()
        {
            List<ProductViewModel> viewModels = new List<ProductViewModel>();
            viewModels.Add(GenerateProductViewModel(1));
            viewModels.Add(GenerateProductViewModel(2));
            viewModels.Add(GenerateProductViewModel(3));
            return View(viewModels);
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