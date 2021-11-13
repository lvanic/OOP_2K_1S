using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Test1
    {
        public Test1(string value)
        {
            str1 = value;
        }
        public Test1()
        { }
        public void Add(string det)
        {
            Console.WriteLine("LEGGOOOO");
            str1 += "ADDDD";
        }
        public string str1;
    }
    class Test2
    {
        public Test2()
        { }
        public Test2(string value, int numb, string time)
        {
            str1 = value;
            number = numb;
            str2 = time;
        }
        public void Add(string det)
        {
            
        }
        public string str1;
        public int number;
        public string str2;
    }
}
