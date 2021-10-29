using JooleGP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JooleGP.Repo
{
  
    public class CategoryRepository : Repository<tblCategory>
        {
        public CategoryRepository() : base()
        {
        }
        public IEnumerable<tblProduct> GetProductsByID(int id)
            {
            var query = "SELECT tblProducts.* FROM tblProducts " +
                "INNER JOIN tblSubCategory ON tblProducts.SubCategory_ID = tblSubCategory.SubCategory_ID " +
                "INNER JOIN tblCategory ON tblCategory.Category_ID = tblSubCategory.Category_ID " +
                "WHERE tblCategory.Category_ID = '" + id + "'";



            return this.context.tblProducts.SqlQuery(query);
           
        }
           /* private bool disposed = false;
            protected virtual void Dispose(bool disposing)
            {
                if (!this.disposed)
                {
                    if (disposing)
                    {
                        this.context.Dispose();
                    }
                }
                this.disposed = true;
            }
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }*/
        }
    }
