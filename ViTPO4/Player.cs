using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViTPO4
{
    public class Player
    {
        public string Name { get; set; } //имя

        public int points { get; set; } //количество очков

        public Player(string name) { Name = name; points = 0; }
        public void addPoint() { points++; }
        public void resetPoint() { points = 0; }
    }
}
