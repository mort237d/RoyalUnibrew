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
    public class ProductionsControllerTests
    {
        private ProductionsController _productionsController = new ProductionsController();
        [TestMethod()]
        public void GetProductionsTest()
        {
            Assert.IsNotNull(_productionsController.GetProductions());
        }
    }
}