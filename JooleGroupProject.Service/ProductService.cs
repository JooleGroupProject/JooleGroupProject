using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JooleGroupProject.Data;
using JooleGroupProject.Repo;

namespace JooleGroupProject.Service
{
    public class ProductService
    {
        private ProductRepository productRepository;

        public ProductService(/*Repository<tblProduct> productRepository*/)
        {
            this.productRepository = new ProductRepository();
        }

        public tblProduct GetProduct(int id)
        {
            return this.productRepository.Get(id);
        }

        public IEnumerable<tblProduct> GetAllProducts()
        {
            IEnumerable <tblProduct> products = this.productRepository.GetAll();
            return products;
        }

        public IEnumerable<tblProduct> GetByProductsBySubCategory(int subCatId)
        {
            return this.productRepository.GetProductsBySubCategory(subCatId);
        }
    }
}
