using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JooleGP.Repo;

namespace JooleGP.BLL
{
    public class ReportsBLL 
    {
        public object getCategory()
        {
            return new CategoryRepository().GetCategory();
        }
        public object getProducts(int id)
        {
            return new CategoryRepository().GetProductsByID(id);
        }
       
    }
}