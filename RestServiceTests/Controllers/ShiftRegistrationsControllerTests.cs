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
    public class ShiftRegistrationsControllerTests
    {
        private  ShiftRegistrationsController _shiftRegistrationsController = new ShiftRegistrationsController();
        [TestMethod()]
        public void GetShiftRegistrationsTest()
        {
            Assert.IsNotNull(_shiftRegistrationsController.GetShiftRegistrations());
        }
    }
}