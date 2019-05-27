using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestService.Controllers.Tests
{
    [TestClass()]
    public class ProductsControllerTests
    {
        private  ProductsController _productsController = new ProductsController();
        [TestMethod()]
        public void GetProductsTest()
        {
            Assert.IsNotNull(_productsController.GetProducts());
        }
    }
}