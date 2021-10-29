using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JooleGroupProject.Data;
using JooleGroupProject.Repo;

namespace JooleGroupProject.Service
{
    public class CatService
    {
        private readonly CategoryRepository catRepository = new CategoryRepository();

        public CatService() : base()
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
