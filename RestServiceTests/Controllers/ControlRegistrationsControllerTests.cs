using System.Net;
using System.Threading;
using System.Web.Http.Results;
using RestService.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestService.Models;

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

        [TestMethod()]
        public void GetControlRegistrationTest()
        {
            //var controlRegistration = _controlRegistrationsController.GetControlRegistration(1);
            //Assert.IsInstanceOfType(controlRegistration, typeof(OkResult));

            //var controlRegistration = _controlRegistrationsController.GetControlRegistration(10000);
            //Assert.IsInstanceOfType(controlRegistration, typeof(NotFoundResult));
        }

        //https://stackoverflow.com/questions/19936892/how-do-i-unit-test-web-api-action-method-when-it-returns-ihttpactionresult
    }
}