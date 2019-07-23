using System.Collections.Generic;

namespace lab4
{
    public static class SimpleSearch
    {

        public static List<string> Search(string word, List<string> list)
        {
            if (string.IsNullOrWhiteSpace(word))
                throw new System.ArgumentException("Word shouldn't be empty or" +
                    "consist only of white-space characters.", "word");
            
            if (list.Count == 0)
                throw new System.ArgumentException("List shouldn't be empty.", "list");

            List<string> tempList = new List<string>();
            string tmp = word.Trim().ToUpper();

            foreach (string str in list)
            {
                if (str.ToUpper().Contains(tmp))
                    tempList.Add(str);
            }
       
            return tempList;
        }
    }
}
