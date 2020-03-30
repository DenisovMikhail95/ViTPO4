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

            manager.ListPlayers.Add(new Player("Ivan"));
            manager.ListPlayers.Add(new Player("Pasha"));

            manager.switchPlayer();
            Assert.AreEqual(1, manager.IndexPlayer);
            manager.switchPlayer();
            Assert.AreEqual(0, manager.IndexPlayer);
        }

        [TestMethod]
        public void timerCallSwitchPlayers()
        {
            ManagerClass manager = new ManagerClass();
            manager.ListPlayers.Add(new Player("Ivan"));
            manager.ListPlayers.Add(new Player("Pasha"));

            Timer MyTimer = new Timer(manager, 2);
            MyTimer.takeOneSecond();
            MyTimer.takeOneSecond();

            Assert.AreEqual(1, manager.IndexPlayer);
        }

        [TestMethod]
        public void addAndResetPlayersPoint()
        {
            Player player1 = new Player("Ivan");
            player1.addPoint();
            Assert.AreEqual(1, player1.points);
            player1.resetPoint();
            Assert.AreEqual(0, player1.points);
        }

        [TestMethod]
        public void loadBaseOfCities()
        {
            BaseOfWords baseWords = new BaseOfWords();

            Assert.AreEqual(1121, baseWords.Cities.Length);
        }

    }
}
