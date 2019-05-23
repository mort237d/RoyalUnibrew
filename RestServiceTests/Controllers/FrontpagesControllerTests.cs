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
    public class FrontpagesControllerTests
    {
        private FrontpagesController _frontpagesController = new FrontpagesController();
        [TestMethod()]
        public void GetFrontpagesTest()
        {
            Assert.IsNotNull(_frontpagesController.GetFrontpages());
        }
    }
}