using JooleGP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JooleGP.Repo
{
  
    public class CategoryRepository : ISearchRepository
        {
            private static JooleAppDBEntities _context = new JooleAppDBEntities();
           
            public IEnumerable<object> GetCategory()
            {
                return _context.tblCategories.ToList();
            }
            public IEnumerable<object> GetProductsByID(int id)
            {
            var query = "SELECT tblProducts.Product_Name FROM tblProducts " +
                "INNER JOIN tblSubCategory ON tblProducts.SubCategory_ID = tblSubCategory.SubCategory_ID " +
                "INNER JOIN tblCategory ON tblCategory.Category_ID = tblSubCategory.Category_ID " +
                "WHERE tblCategory.Category_ID = '" + id + "'";
            return _context.tblProducts.SqlQuery(query).ToList();
            }
            private bool disposed = false;
            protected virtual void Dispose(bool disposing)
            {
                if (!this.disposed)
                {
                    if (disposing)
                    {
                        _context.Dispose();
                    }
                }
                this.disposed = true;
            }
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }
    }
