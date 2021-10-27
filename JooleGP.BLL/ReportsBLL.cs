using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JooleGP.DAL;
using JooleGP.Repo;

namespace JooleGP.BLL
{
    public class ReportsBLL 
    {
        private readonly CategoryRepository catRepository = new CategoryRepository();

        public ReportsBLL() : base()
        {
        }
        public IEnumerable<tblCategory> getCategory()
        {
            return this.catRepository.GetAll();
        }
        public IEnumerable<tblProduct> getProducts(int id)
        {
            return this.catRepository.GetProductsByID(id);
        }
       
    }
}