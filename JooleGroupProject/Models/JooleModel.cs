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

        public JooleModel()
        {
            this.SearchView = new SearchModel();
            this.ProductView = new ProductViewModel();
        }
    }
}