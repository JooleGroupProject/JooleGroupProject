using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JooleGroupProject.Data;

namespace JooleGroupProject.Models
{
    public class ProductSummaryViewModel
    {
        public List<ProductViewModel> Products { get; set; }
        public Dictionary<string, List<string>> TypeFilters { get; set; }
        public List<tblSpecFilter> TechSpecFilters { get; set; }
        public List<int> SelectedProductId { get; set; }

        public ProductSummaryViewModel()
        {
            this.Products = new List<ProductViewModel>();
            this.TypeFilters = new Dictionary<string, List<string>>();
            this.TechSpecFilters = new List<tblSpecFilter>();
            this.SelectedProductId = new List<int>();
        }
    }
}