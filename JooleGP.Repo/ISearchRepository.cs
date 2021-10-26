using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JooleGP.DAL;

namespace JooleGP.Repo
{
    public interface ISearchRepository : IDisposable
    {
        IEnumerable<object> GetCategory();
        IEnumerable<object> GetProductsByID(int categoryId);
    }
}
