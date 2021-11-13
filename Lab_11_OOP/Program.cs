using System;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------1");
            Test1 test1 = new Test1("qwerty");
            Console.WriteLine(Reflector<Test1>.Assembly(test1.GetType().FullName));
            Console.WriteLine("--------------------2");

            Test2 test2 = new Test2("wasd", 909, "GamePass");
            Console.WriteLine(Reflector<Test2>.IsTherePublicConstuctors(test2.GetType().FullName));
            Console.WriteLine("--------------------3");

            var pubmet = Reflector<Test2>.GetPublicMethods(test2.GetType().FullName);
            foreach (string el in pubmet)
            {
                Console.WriteLine(el);
            }
            Console.WriteLine("--------------------4");

            var fields = Reflector<Test2>.GetFields(test2.GetType().FullName);
            foreach (string el in fields)
            {
                Console.WriteLine(el);
            }
            Console.WriteLine("--------------------5");

            var infaces = Reflector<Test2>.GetInterfaces(test2.GetType().FullName);
           

            Reflector<Test1>.Invoke(test1, "Add");
            Console.WriteLine("--------------------");

            Test1 newTest1 = Reflector<Test1>.Create(typeof(Test1));
        }
    }
}
