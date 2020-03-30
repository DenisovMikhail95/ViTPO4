using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViTPO4;

namespace TestGame
{
    [TestClass]
    public class TestClass
    {
        [TestMethod]
        public void timerClassTakeOneSecond()
        {
            Timer MyTimer = new Timer();

            MyTimer.Seconds = 5;
            MyTimer.takeOneSecond();
            Assert.AreEqual(4, MyTimer.Seconds);
        }
    }
}
