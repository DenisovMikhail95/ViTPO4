using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViTPO4
{
    public class Timer
    {
        public int Seconds { get; set; } //количество секунд

        public void takeOneSecond() { Seconds--; } //вычитание секунд

        public ManagerClass Manager { get; set; } //управляющий класс
    }
}
