using JooleGroupProject.Service;
using JooleGroupProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JooleGroupProject.Models
{
    public class SearchModel
    {
        public tblUser user { get; set; }
        public List<tblCategory> Categories { get; set; }
        public List<tblProduct> CurrentList { get; set; }
        public List<string> autoComp { get; set; }
        public tblCategory chosenC { get; set; }
        public tblProduct chosenP { get; set; }

        public SearchModel()
        {
            this.Categories = new List<tblCategory>();
            this.CurrentList = new List<tblProduct>();
            this.chosenP = new tblProduct();
            this.chosenC = new tblCategory();
            this.autoComp = new List<string>();

        }

    }
}