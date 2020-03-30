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

        public ManagerClass Manager { get; set; } //управляющий класс

        public Timer(){}
        public Timer(ManagerClass manager, int sec)
        {
            Manager = manager;
            Seconds = sec;
        }

        public void takeOneSecond()//вычитание секунд
        { 
            Seconds--;
            checkNeedSwitchPlayer();
        } 

        public void checkNeedSwitchPlayer() //проверка надобности переключения игрока
        {
            if (Seconds == 0)
                Manager.switchPlayer();
        }

    }
}
