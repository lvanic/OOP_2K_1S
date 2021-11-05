using System;
using System.Linq;

namespace Lab_3_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Set<int> q = new Set<int>(1, 2, 3);
            q.Add(6);
            Console.WriteLine(q);

            Set<int> q1 = new Set<int>(1, 2, 3);
            q1.Add(5);
            Console.WriteLine(q1);
            Console.WriteLine(q.Equals(q1));

            Set<char> q3 = new Set<char>('E', 'g', 'o');
            q3.Add('r');
            Console.WriteLine(q3);

            Console.WriteLine(q3.Sum());
            Console.WriteLine(q1.Sum());
            Console.WriteLine(q3.CheckSort());
            Console.WriteLine(q.GetEl(2));

            Console.WriteLine(q >= q1);
            Console.WriteLine(q3.GetCrypto(3));
            Set<char> q4 = new Set<char>(q3.GetCrypto(3));
            Console.WriteLine(q4.GetCrypto(-3));

            Console.WriteLine(q);
            q++;
            Console.WriteLine(q);
            Console.WriteLine(q.owner.company);
            Console.WriteLine(q);

            Set<int> q5 = new Set<int>();
            q5 = q + q1;
            Console.WriteLine(q5);
            Console.WriteLine(q5 <= q1);
            Console.WriteLine((int)q1);
            Console.WriteLine(q1 % 3);

            Console.WriteLine(q1.sumM());
            Console.WriteLine(q1.CountT());
            Console.WriteLine(q1.profit());

        }
    }
}
