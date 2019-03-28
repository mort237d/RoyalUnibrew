using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ModelLibrary;
using RestService.DBUtil;

namespace RestService.Controllers
{
    public class ProductController : ApiController
    {
        private ManageProduct _mngProduct = new ManageProduct();

        public IEnumerable<Product> Get()
        {
            return _mngProduct.GetAllProducts();
        }

        public Product Get(int id)
        {
            return _mngProduct.GetProductFromID(id);
        }

        public bool Post([FromBody]Product value)
        {
            return _mngProduct.CreateProduct(value);
        }

        public bool Put([FromBody]Product value, int id)
        {
            return _mngProduct.UpdateProduct(value, id);
        }

        public bool Delete(int id)
        {
            return _mngProduct.DeleteProduct(id);
        }
    }
}
