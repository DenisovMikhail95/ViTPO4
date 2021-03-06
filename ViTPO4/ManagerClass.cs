﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViTPO4
{
    public class ManagerClass
    {
        public BaseOfWords BaseWords { get; set; } //индекс текущего игрока
        public int IndexPlayer { get; set; } //индекс текущего игрока

        public List<Player> ListPlayers { get; set; } //список игроков в игре

        public List<string> UsedCities { get; set; } //список использованных городов

        public ManagerClass(BaseOfWords baseW) {
            IndexPlayer = 0;
            ListPlayers = new List<Player>();
            UsedCities = new List<string>();
            BaseWords = baseW;
        }

        public void switchPlayer()
        {
            if (IndexPlayer == ListPlayers.Count - 1)
                IndexPlayer = 0;
            else
                IndexPlayer++;
        }

        public int checkWord(string answer)
        {
            //несовпадение со словарем
            if (BaseWords.searchCity(answer) == false)
                return 0;

            if (UsedCities.Count == 0)
            {
                UsedCities.Add(answer);
                return 1;
            }

            string pastWord = UsedCities[UsedCities.Count - 1];
            //несовпадение последней бувы с первой
            if (pastWord[pastWord.Length - 1] == 'ы' || pastWord[pastWord.Length - 1] == 'ь' || pastWord[pastWord.Length - 1] == 'Ы' || pastWord[pastWord.Length - 1] == 'Ь')
            {
                if (string.Compare(answer[0].ToString(), pastWord[pastWord.Length - 2].ToString(), true) != 0)
                    return -2;
            }
            else
            {
                if (string.Compare(answer[0].ToString(), pastWord[pastWord.Length - 1].ToString(), true) != 0)
                    return -2;
            }
            
            // слово уже использовалось
            foreach(var city in UsedCities)
            {
                if (city == answer)
                    return -1;
            }

            UsedCities.Add(answer); //добавляем город в использованные 

            return 1;
        }

        public List<string> endGame()
        {
            int max = 0;
            List<string> winners = new List<string>();

            for(int i = 0; i < ListPlayers.Count; i++)
            {
                if (ListPlayers[i].points > max)
                    max = ListPlayers[i].points;
            }
            for (int i = 0; i < ListPlayers.Count; i++)
            {
                if (ListPlayers[i].points == max)
                    winners.Add(ListPlayers[i].Name);
            }
            return winners;
        }
    }
}
