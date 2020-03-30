using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViTPO4
{
    public class Timer
    {
        public int Seconds { get; set; }

        public void takeOneSecond() { Seconds--; }
    }
}
