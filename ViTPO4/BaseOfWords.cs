using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViTPO4
{
    public class BaseOfWords
    {
        public string[] Cities { get; set; }

        public BaseOfWords()
        {
            Cities = File.ReadAllLines("cities.txt");
        }
    }
}
