using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_OOP
{
    public static class AddMethods
    {
            public static bool CheckSort(this Set<int> set)
            {
            List<int> mas = new List<int>();
            foreach (char element in Convert.ToString(set))
            {  
                if (element != ',')
                {
                    mas.Add(element - '0');
                }
                else continue;
            }
            for (int i = 0; i < mas.Count - 1; i++)
            {
                if (mas[i] > mas[i + 1])
                {
                    return false;
                }
            }
            return true;
            }
            public static bool CheckSort(this Set<char> set)
            {
            return true;
            }
            public static string GetCrypto(this Set<char> set, int key)
            {
            string rezult = null;
            
            foreach(char element in Convert.ToString(set))
            {
                if (element != ',')
                {
                    rezult += Convert.ToChar(element + key);                     
                }
            }
            return rezult;
            }
        public static int profit(this Set<int> set)
        {
            int rezult = set.Max() - set.Min();
            return rezult;
        }

        public static int sumM(this Set<int> set)
        {
            int rezult = set.Sum();
            return rezult;
        }
        public static int CountT(this Set<int> set)
        {
            
            return set.Size();
        }

    }
}
