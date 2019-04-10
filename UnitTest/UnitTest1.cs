using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibrary;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetByIdTest()
        {
            Assert.AreEqual(ModelGenerics.GetById(new Product(), 666));
        }
    }
}
