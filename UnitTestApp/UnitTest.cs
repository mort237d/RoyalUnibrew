﻿using System;
using Windows.UI;
using Windows.UI.Xaml.Media;
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
        public void TestFindWeekNumber()
        {
            ManageTables mt = ManageTables.Instance;
            Frontpages frontpages = new Frontpages(0, new DateTime(2019, 1, 25), 0, 0, "hej", 1);
            //int weekNumber = mt.FindWeekNumber(frontpages);
            //Assert.AreEqual(4, weekNumber);
            
        }
   
        [UITestMethod]
        public void TestChangeListViewColor()
        {
            SolidColorBrush whiteColorBrush = new SolidColorBrush(Colors.White);
            SolidColorBrush salmonColorBrush = new SolidColorBrush(Colors.LightSalmon);
            OutOfBoundColorChange outOfBound = new OutOfBoundColorChange();
            SolidColorBrush returnOutOfRangeColor = outOfBound.ChangeListViewColor(1, 3, 9);
            SolidColorBrush returnInRangeColor = outOfBound.ChangeListViewColor(29, 14, 200);
            Assert.AreEqual(salmonColorBrush.Color, returnOutOfRangeColor.Color);
            Assert.AreEqual(whiteColorBrush.Color, returnInRangeColor.Color);
            
        }
    }
}
