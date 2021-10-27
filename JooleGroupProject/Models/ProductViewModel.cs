using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JooleGroupProject.Data;

namespace JooleGroupProject.Models
{
    public class ProductViewModel
    {
        public tblProduct Product { get; set; }
        public Dictionary<string, string> TechSpecsProps { get; set; }

        public ProductViewModel()
        {
            TechSpecsProps = new Dictionary<string, string>();
        }

    }
}