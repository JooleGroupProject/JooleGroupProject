using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JooleGroupProject.Data;

namespace JooleGroupProject.Repo
{
    public class ProductRepository : Repository<tblProduct>
    {

        public ProductRepository() : base()
        {
        }
        public IEnumerable<tblProduct> GetProductsBySubCategory(int subCatId)
        {
            return from product in this.entities
                    where product.SubCategory_ID == subCatId
                    select product;
        }

        public IEnumerable<tblProduct> GetProductDetails(int id)
        {
            return from product in this.entities
                   where product.Product_ID == id
                   select product;
        }

    }
}
