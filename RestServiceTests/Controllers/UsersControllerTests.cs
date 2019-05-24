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
    public class UsersControllerTests
    {
        private UsersController _usersController = new UsersController();
        [TestMethod()]
        public void GetUsersTest()
        {
            Assert.IsNotNull(_usersController.GetUsers());
        }
    }
}