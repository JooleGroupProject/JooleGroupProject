using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JooleGroupProject.Models
{
    public class Product
    {

        public int Product_ID { get; set; }
        public int SubCategory_ID { get; set; }
        public int Manufacturer_ID { get; set; }
        [StringLength(50)]
        [Display(Name = "Product Name")]
        public string Product_Name { get; set; }
        public string Product_Image { get; set; }
        public string Series { get; set; }
        public string Model { get; set; }
        public int Model_Year { get; set; }
        public string Series_Info { get; set; }
        public string Featured { get; set; }

    }
}