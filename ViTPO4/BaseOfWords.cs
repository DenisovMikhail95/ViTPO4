﻿using System;
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

        public bool searchCity(string answer)
        {
            foreach (var city in Cities)
            {
                if (string.Compare(city, answer, true) == 0)
                    return true;
            }
            return false;
        }
    }
}
