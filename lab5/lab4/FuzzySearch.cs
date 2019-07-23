using EditDistanceProject;
using System;
using System.Collections.Generic;

namespace lab4
{
    public static class FuzzySearch
    {
        /// <summary>
        /// Нечёткий поиск.
        /// </summary>
        /// <param name="word">Слово для поиска.</param>
        /// <param name="maxDist">Максимальное расстояние для поиска.</param>
        /// <param name="list">Список слов.</param>
        /// <returns></returns>
        public static List<Tuple<string, int>> Search(string word, int maxDist, List<string> list)
        {
            if (string.IsNullOrWhiteSpace(word))
                throw new System.ArgumentException("Word shouldn't be empty or" +
                    "consist only of white-space characters.", "word");

            if (list.Count == 0)
                throw new System.ArgumentException("List shouldn't be empty.", "list");

            if (maxDist < 1 || maxDist > 5)
                throw new System.ArgumentException("The maximum distance should be in the range from 1 to 5.", "maxDist");

            string wordUpper = word.Trim().ToUpper();

            //Временные результаты поиска
            List<Tuple<string, int>> tempList = new List<Tuple<string, int>>();

            foreach (string str in list)
            {
                //Вычисление расстояния Дамерау-Левенштейна
                int dist = EditDistance.Distance(str.ToUpper(), wordUpper);

                //Если расстояние меньше порогового, то слово добавляется в результат
                if (dist <= maxDist)
                    tempList.Add(new Tuple<string, int>(str, dist));

            }

            return tempList;
        }
    }
}
