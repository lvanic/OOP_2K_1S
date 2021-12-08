using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_15_OOP
{
    class Program
    {
        private static object locker = new object();
        static BlockingCollection<string> storage = new BlockingCollection<string>();
        static int Number_Of_Producer = 0;

        static void Main(string[] args)
        {
            
            var sw = new Stopwatch();
            Task task = new Task(Nums);
            sw.Start();
            task.Start();
            Console.WriteLine(task.IsCompleted);
            sw.Stop();
            task.Wait();
            Console.WriteLine("--------");
            Console.WriteLine(task.IsCompleted + " " + task.AsyncState);
            Console.WriteLine("--------");
            Console.WriteLine(sw.ElapsedTicks);

            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            Task<int> fact1 = new Task<int>(() => Factorial(3));
            Task<int> fact2 = new Task<int>(() => Factorial(5));
            Task<int> fact3 = new Task<int>(() => Factorial(4));
            fact1.Start();
            fact2.Start();
            fact3.Start();
            fact1.Wait();
            fact2.Wait();
            fact3.Wait();
            int sum = fact2.Result - fact1.Result - fact3.Result - 80;
            
            lock(locker)
            {
                Task<int> fact_rez = new Task<int>(() => Factorial(sum));
                fact_rez.Start();
                fact_rez.Wait();
                Console.WriteLine(fact_rez.Result);
            }
            Console.WriteLine("--------");
            Task<int> task1 = new Task<int>(() => NumPop(1, 4));
            
            task1.Start();
            Task task2 = task1.ContinueWith(x => Console.WriteLine(Factorial(x.Result)));
            task2.Wait();
            Console.WriteLine("--------");
            Console.WriteLine(task1.GetAwaiter().GetResult());

            var sw1 = new Stopwatch();
            //sw1.Start();
            Console.WriteLine("--------");
            Parallel.For(1, 10, FactorialP);
            Console.WriteLine("----|FOR|----");
            Parallel.ForEach(new List<int>() { 1, 3, 5, 2}, FactorialP);
            Console.WriteLine("----|FOREACH|----");
            Parallel.Invoke(Display, () => { Console.WriteLine("1"); });

            

            TimerCallback tm = new TimerCallback(Producer);
            Timer timer = new Timer(tm, 2, 2000, 2000);
            

            for (int i = 0; i < 16; i++)
            {
                Consumer();     
            }
            GetNumbers();
            
        }
        
        static void Producer(object counter)
        {
            if (Number_Of_Producer == 10)
                Number_Of_Producer = 0;

            if (Number_Of_Producer == 0 || Number_Of_Producer == 5) 
            {
                storage.Add(Products.Coffee);
                Number_Of_Producer++;
                Console.WriteLine("Storage:" + Products.Coffee);
            }
            else if(Number_Of_Producer == 1) 
            {
                storage.Add(Products.Multicooker);
                Number_Of_Producer++;
                Console.WriteLine("Storage:" + Products.Multicooker);
            }
            else if (Number_Of_Producer == 2 || Number_Of_Producer == 7 || Number_Of_Producer == 6) 
            {
                storage.Add(Products.Phone);
                Number_Of_Producer++;
                Console.WriteLine("Storage:" + Products.Phone);
            }
            else if (Number_Of_Producer == 3) 
            {
                storage.Add(Products.Tv);
                Number_Of_Producer++;
                Console.WriteLine("Storage:" + Products.Tv);
            }
            else if (Number_Of_Producer == 4 || Number_Of_Producer == 8 || Number_Of_Producer == 9) 
            {
                storage.Add(Products.Headphones);
                Number_Of_Producer++;
                Console.WriteLine("Storage:" + Products.Headphones);
            }
              
        }
        static async void GetNumbers()
        {
            await Task.Run(() => NumPop(12345, 8));
        }
        static void Consumer()
        { 
            if(storage.Count == 0)
            {
                Thread.Sleep(2050);
                return;    
            }
            Console.WriteLine(storage.Take());
        }
        static void Display()
        {
            Console.WriteLine("----DISPLAY----");
        }
        static void FactorialP(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Console.WriteLine("Integral =" + result);
        }
        static int NumPop(int number, int el)
        {
            if(el < 10 && el >= 0)
           number = (number * 10) + el;
            Console.WriteLine(number);
            return number;
        }
        static void Nums()
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            for (int i = 0; i < 10000; i++)
            {
                bool flag = true;
                for (int n = 2; n < (Convert.ToInt32(Math.Sqrt(i)) + 1); n++)
                {
                    if (i % n == 0)
                    {
                        flag = false;
                        continue;
                    } 
                    if((n == Convert.ToInt32(Math.Sqrt(i))) && flag)
                    {
                        Console.WriteLine(i);
                    }
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Операция прервана");
                        return;
                    }
                    if(i == 9985)
                    {
                        cancelTokenSource.Cancel();
                    }
                }
            }
        }

        static int Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }

            return result;
        }
    }
    static class Products
    {
        public static string Coffee = "Coffee machine";
        public static string Multicooker = "Multicooker";
        public static string Tv = "Television";
        public static string Phone = "Phone";
        public static string Headphones = "Headphones";
    }
}
