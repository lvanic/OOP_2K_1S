using System;
using System.Text;
using System.Linq;

namespace Lab_OOP_1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool q = false;// true false
            byte w = 1;// 1 byte 0-255
            sbyte e = -1;// 1 byte -128-127
            short r = 255;// 2 byte -32768-32767
            ushort t = 1234;// 2 byte 0-65535
            int y = 1234123;// 4 byte -2147483648-2147483647
            uint u = 123456;// 4 byte 0-4294967295
            long i = 10000000000000; // 8 byte
            ulong o = 1000000000000000;
            float p = 123.23f;// 4 byte
            double a = 123.23d;// 8 byte
            decimal s = 123.123m;// 16 byte
            char d = 'A';// 2 byte Unicode
            string f = "Hello";
            object g = 6;// 4 byte(8 byte) base for types and classes

            int h = Convert.ToInt16(s);
            int j = (int)p;
            bool k = Convert.ToBoolean(w);
            int l = (int)g;
            object z = (object)u;

            int x = w;
            double c = p;
            long v = y;
            object b = s;
            int n = d;

            var m = 10;
            m++;

            Nullable<int> qq = 5;
            if (qq.HasValue)
                Console.WriteLine("True");

            var ww = "qwerty";
            //ww = 5;

            string ee = "artur";
            string rr = "popok";
            if (ee == rr)
                Console.WriteLine("1");

            String.Equals(ee, rr);
            String.Compare(ee, rr);

            string tt = "qwerty";
            string yy = "asdfgh";
            string uu = "zxcvbn asdf qwetty";

            string ii = String.Concat(tt, yy);
            string oo = rr;
            string[] pp = uu.Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries
                );
            string aa = rr.Trim(new char[] {'o','p'});
            string ss = rr.Insert(3, tt);
            string dd = rr.Remove(2, 2);

            Console.WriteLine($"I am {w} years old and have {i} iq so i also have {m * w} friends");

            string ff = "";
            string gg = null;

            if (string.IsNullOrEmpty(ff))
                Console.WriteLine(1);

            if (string.IsNullOrEmpty(gg))
                Console.WriteLine(1);

            StringBuilder hh = new StringBuilder("asdfgasd");
            hh.Remove(3, 3);
            hh.Append("NEW");
            hh.Insert(0, "OLD");
            Console.WriteLine(hh);

            int[,] jj = { { 1, 2, 3 }, { 1, 2, 3 }, { 3, 2, 1 } };

            int rows = jj.GetUpperBound(0) + 1;
            int columns = jj.Length / rows;


            for (int pop = 0; pop < rows; pop++)
            {
                for (int kek = 0; kek < columns; kek++)
                {
                    Console.Write($"{jj[pop, kek]} \t");
                }
                Console.WriteLine();
            }
            string[] kk = {"qwerty", "asdfgh", "zxcvbn" };

            Console.WriteLine(kk.Length);

            foreach(string oop in kk)
            {
                Console.WriteLine(oop);
            }

            kk[1] = "popopop";

            int[][] ll = new int[3][];
            ll[0] = new int[] {1,3};
            ll[1] = new int[] { 1, 3, 5 };
            ll[2] = new int[] { 1, 3, 4, 7 };

            foreach (int[] row in ll)
            {
                foreach (int number in row)
                {
                    Console.Write($"{number} \t");
                }
                Console.WriteLine();
            }

            var zz = new object[0];

            (int, string, char, string, ulong) xx = (5, "tom", 'q', "besedkin", 12345);
            Console.WriteLine(xx);
            Console.WriteLine(xx.Item1);
            Console.WriteLine(xx.Item3);
            Console.WriteLine(xx.Item5);

            (int aaa, string bbb, char ccc, string ddd, ulong eee) = xx;

            int qe = xx.Item1;

            (int aaaa, _, char cccc, string dddd, ulong eeee) = xx;

            int[] iq = { 3, 2, 3, 4, 5, 9, 3 };
            string nic = "Nikita";

            (int, int, int, char) Func(int[]iq, string nic)
            {
                (int, int, int, char) qw;
                qw.Item1 = iq.Max();
                qw.Item2 = iq.Min();
                qw.Item3 = iq.Sum();
                qw.Item4 = nic.First();

                return qw;
            }
            (int, int, int, char) qw = Func(iq, nic);
            Console.WriteLine(qw);

            void Func1()
            {
                checked
                {
                    int bebra = int.MaxValue;
                }
            }
            void Func2()
            {
                unchecked
                {
                    int bebra = int.MaxValue;
                }
            }
        }
    }
}
