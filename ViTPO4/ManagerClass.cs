using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViTPO4
{
    public class ManagerClass
    {
        public int IndexPlayer { get; set; } //индекс текущего игрока

        public List<Player> ListPlayers { get; set; } //список игроков в игре

        List<string> UsedCities { get; set; } //список использованных городов

        public ManagerClass() {
            IndexPlayer = 0;
            ListPlayers = new List<Player>();
            UsedCities = new List<string>();
        }

        public void switchPlayer()
        {
            if (IndexPlayer == ListPlayers.Count - 1)
                IndexPlayer = 0;
            else
                IndexPlayer++;
        }

        public void checkWord(string answer)
        {

        }
    }
}
