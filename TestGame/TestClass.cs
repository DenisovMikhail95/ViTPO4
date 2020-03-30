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
            BaseOfWords baseWords = new BaseOfWords();
            ManagerClass manager = new ManagerClass(baseWords);

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
            BaseOfWords baseWords = new BaseOfWords();
            ManagerClass manager = new ManagerClass(baseWords);
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

        [TestMethod]
        public void testSearchCity()
        {
            BaseOfWords baseWords = new BaseOfWords();
            Assert.AreEqual(true, baseWords.searchCity("Барнаул"));
        }

        [TestMethod]
        public void checkWordTesting()
        {
            BaseOfWords baseWords = new BaseOfWords();
            ManagerClass manager = new ManagerClass(baseWords);

            manager.UsedCities.Add("Новосибирск");
            Assert.AreEqual(manager.checkWord("Кемерово"), 1);

            Assert.AreEqual(manager.checkWord("Оаку"), 0);

            manager.UsedCities[0] = "Омск";
            Assert.AreEqual(manager.checkWord("Омск"), -1);

            Assert.AreEqual(manager.checkWord("Барнаул"), -2);

            manager.UsedCities.Add("Астрахань");
            Assert.AreEqual(manager.checkWord("Норильск"), 1);

        }

        [TestMethod]
        public void determWinner()
        {
            BaseOfWords baseWords = new BaseOfWords();
            ManagerClass manager = new ManagerClass(baseWords);

            manager.ListPlayers.Add(new Player("Ilon"));
            manager.ListPlayers[manager.ListPlayers.Count - 1].points = 10;
            manager.ListPlayers.Add(new Player("Mask"));
            manager.ListPlayers[manager.ListPlayers.Count - 1].points = 12;
            manager.ListPlayers.Add(new Player("Oleg"));
            manager.ListPlayers[manager.ListPlayers.Count - 1].points = 11;

            var winners = manager.endGame();
            Assert.AreEqual(winners[0],"Mask");

            manager.ListPlayers[manager.ListPlayers.Count - 1].points = 12;
            winners.Clear();
            winners = manager.endGame();
            Assert.AreEqual(winners[0], "Mask");
            Assert.AreEqual(winners[1], "Oleg");
        }
    }
}
