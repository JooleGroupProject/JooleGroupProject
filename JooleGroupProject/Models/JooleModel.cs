using JooleGroupProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace JooleGroupProject.Models
{
    public class JooleModel
    {
        public ProductViewModel ProductView { get; set; }
        public SearchModel SearchView { get; set; }
        public IEnumerable<tblProduct> Products { get; set; }
        public List<ProductViewModel> LProduct { get; set; }
        public ProductSummaryViewModel PSVModel  { get; set; }

        public JooleModel()
        {
            this.SearchView = new SearchModel();
            this.ProductView = new ProductViewModel();
            this.LProduct = new List<ProductViewModel>();
            this.PSVModel = new ProductSummaryViewModel();
        }
    }
}