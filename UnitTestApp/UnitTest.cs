using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using UniBase.Model;
using UniBase.Model.K2;

namespace UnitTestApp
{
    [TestClass]
    public class UnitTest1
    {
        
        [UITestMethod]
        public void TestMethod1()
        {
            ManageTables mt = new ManageTables();
            Frontpages frontpages = new Frontpages(0, new DateTime(2019, 1, 25), 0, 0, "hej", 1);
            //int weekNumber = mt.FindWeekNumber(frontpages);
            //Assert.AreEqual(4, weekNumber);
            
        }
    }
}
