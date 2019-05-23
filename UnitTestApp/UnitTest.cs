using System;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using UniBase.Model;
using UniBase.Model.K2;
using UniBase.Model.K2.ButtonMethods;

namespace UnitTestApp
{
    [TestClass]
    public class UnitTest1
    {
        
        [UITestMethod]
        public void TestFindWeekNumber()
        {
            FrontpageMethod fm = new FrontpageMethod();
            Frontpages frontpages = new Frontpages(0, new DateTime(2019, 1, 25), 0, 0, "hej", 1);
            //int weekNumber = fm.FindWeekNumber(frontpages.Date);
            //Assert.AreEqual(4, weekNumber);
            
        }
   
        [UITestMethod]
        public void TestChangeListViewColor()
        {
            SolidColorBrush whiteColorBrush = new SolidColorBrush(Colors.White);
            SolidColorBrush salmonColorBrush = new SolidColorBrush(Colors.LightSalmon);
            SolidColorBrush returnOutOfRangeColor = OutOfBoundColorChange.ChangeListViewColor(1, 3, 9);
            SolidColorBrush returnInRangeColor = OutOfBoundColorChange.ChangeListViewColor(29, 14, 200);
            Assert.AreEqual(salmonColorBrush.Color, returnOutOfRangeColor.Color);
            Assert.AreEqual(whiteColorBrush.Color, returnInRangeColor.Color);
        }
    }
}
