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
    public class TUsControllerTests
    {
        private TUsController _tusController = new TUsController();
        [TestMethod()]
        public void GetTUsTest()
        {
            Assert.IsNotNull(_tusController.GetTUs());
        }
    }
}