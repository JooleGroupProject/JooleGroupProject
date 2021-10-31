using System;
using System.Collections.Generic;
using System.Linq;
using JooleGroupProject.Data;
using JooleGroupProject.Repo;

namespace JooleGroupProject.Service
{
    public class CategoryService
    {
        private readonly CategoryRepository catRepository = new CategoryRepository();

        public CategoryService() : base()
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