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
        public Dictionary<string,tblSpecFilter> SpecFilters { get; set; }
        public Dictionary<string, tblTypeFilter> TypeFilters { get; set; }

        public ProductSummaryViewModel()
        {
            Products = new List<ProductViewModel>();
            SpecFilters = new Dictionary<string, tblSpecFilter>();
            TypeFilters = new Dictionary<string, tblTypeFilter>();
        }

    }
}