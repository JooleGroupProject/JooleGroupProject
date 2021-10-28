using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JooleGroupProject.Models
{
    public class ProductSummaryViewModel
    {
        public List<ProductViewModel> Products;
        public Dictionary<string, List<string>> TypeFilters;

        public ProductSummaryViewModel()
        {
            this.Products = new List<ProductViewModel>();
            this.TypeFilters = new Dictionary<string, List<string>>();
        }
    }
}