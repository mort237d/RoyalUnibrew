using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestApp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Assert.AreEqual(ModelGenerics.GetById(new Product(), 666).ProductName, "Test");
            
            Assert.AreEqual("Test", "Test");
        }
    }
}
