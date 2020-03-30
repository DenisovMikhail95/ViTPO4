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

        [TestMethod]
        public void correctSwitchPlayers()
        {
            ManagerClass manager = new ManagerClass();

            manager.ListPlayers.Add(new Player());
            manager.ListPlayers.Add(new Player());

            manager.switchPlayer();
            Assert.AreEqual(1, manager.IndexPlayer);
            manager.switchPlayer();
            Assert.AreEqual(0, manager.IndexPlayer);
        }

        [TestMethod]
        public void timerCallSwitchPlayers()
        {
            ManagerClass manager = new ManagerClass();
            manager.ListPlayers.Add(new Player());
            manager.ListPlayers.Add(new Player());

            Timer MyTimer = new Timer(manager, 2);
            MyTimer.takeOneSecond();
            MyTimer.takeOneSecond();

            Assert.AreEqual(1, manager.IndexPlayer);
        }
    }
}
