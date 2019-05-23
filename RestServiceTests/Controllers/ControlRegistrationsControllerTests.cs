using RestService.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RestService.Controllers.Tests
{
    [TestClass()]
    public class ControlRegistrationsControllerTests
    {
        private ControlRegistrationsController _controlRegistrationsController = new ControlRegistrationsController();
        [TestMethod()]
        public void GetControlRegistrationsTest()
        {
            Assert.IsNotNull(_controlRegistrationsController.GetControlRegistrations());
        }
    }
}