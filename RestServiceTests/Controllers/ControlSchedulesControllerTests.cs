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
    public class ControlSchedulesControllerTests
    {
        private ControlSchedulesController _controlSchedulesController = new ControlSchedulesController();
        [TestMethod()]
        public void GetControlSchedulesTest()
        {
            Assert.IsNotNull(_controlSchedulesController.GetControlSchedules());
        }
    }
}