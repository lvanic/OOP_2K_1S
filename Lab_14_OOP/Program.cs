using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace Lab_14_OOP
{
    class Program
    {
        private static EventWaitHandle waitHandle = new ManualResetEvent(initialState: true);
        private static object locker = new object();
        private static string oddAbdEvenNum = "";
        private static void DomainUnloadEvent(object sender, EventArgs e) => Console.WriteLine("Домен выгружен из процесса.");
        private static void DomainAssemlyLoadEvent(object sender, AssemblyLoadEventArgs args) => Console.WriteLine("Сборка загружена.");
        static void Main(string[] args)
        {
            Process[] procList = Process.GetProcesses();
            for (int i = 0; i < procList.Length; i++)
            {
                Console.WriteLine(procList[i].Id);
                Console.WriteLine(procList[i].ProcessName);
                Console.WriteLine(procList[i].BasePriority);
                Console.WriteLine("-----------------------");
                //Console.WriteLine(procList[i].StartTime.Ticks);
                //Console.WriteLine(procList[i].TotalProcessorTime);
            }

            CurrentDomainInfo();
            //CreateDomain();
            Console.WriteLine("-----------------------");
            int number;
            while (true)
            {
                Console.Write("Enter a number: ");
                if (int.TryParse(Console.ReadLine(), out number))
                    break;

                Console.WriteLine("Try again");
            }

            Thread myThread = new Thread(NumbersToConsole);
            myThread.Name = "NumberToConsole";
            Console.WriteLine(myThread.ThreadState.ToString());

            myThread.Start(number);    
            Console.WriteLine("Thread status: " + myThread.ThreadState.ToString());
            Thread.Sleep(100);
            Console.WriteLine("Thread status: " + myThread.ThreadState.ToString());

            //myThread.Suspend();
            //Console.WriteLine("Thread status: " + myThread.ThreadState.ToString());

            //myThread.Abort();
            //Console.WriteLine("Thread status: " + myThread.ThreadState.ToString());



            Thread oddThread = new Thread(OddAndEvenNumbersToConsole);
            oddThread.Name = "oddThread";
            oddThread.Priority = ThreadPriority.Lowest;
            Thread evenThread = new Thread(OddAndEvenNumbersToConsole);
            evenThread.Name = "evenThread";
            evenThread.Priority = ThreadPriority.Lowest;

            // true = odd numbers, false = even numbers
            ValueTuple<int, bool> oddnum = (number, true);
            ValueTuple<int, bool> evennum = (number, false);

            oddThread.Start(oddnum);
            evenThread.Start(evennum);
            Console.WriteLine("-----------------------");

            TimerCallback tm = new TimerCallback(Mes);
            Timer timer = new Timer(tm, 2, 2000, 2000);

            Console.ReadLine();
        }
        public static void Mes(object count)
        {
            Console.WriteLine("hi");
        }
        public static void CurrentDomainInfo()
        {
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine("Domain id: " + domain.Id);
            Console.WriteLine("Domain name: " + domain.FriendlyName);
            Console.WriteLine("Domain base directory: " + domain.BaseDirectory);

            Assembly[] assemblies = domain.GetAssemblies();
            Console.WriteLine("Assemblies:");
            foreach (var item in assemblies)
                Console.WriteLine("Name: " + item.GetName().Name);
        }
        public static void CreateDomain()
        {
            AppDomain domain = AppDomain.CreateDomain("Lab15");
            domain.AssemblyLoad += DomainAssemlyLoadEvent;
            domain.DomainUnload += DomainUnloadEvent;

            Assembly[] assemblies = domain.GetAssemblies();
            for (int i = 0; i < assemblies.Length; i++)
            {
                Console.WriteLine("Name: " + assemblies);
                Thread.Sleep(50);
            }

            AppDomain.Unload(domain);
        }
        static void NumbersToConsole(object num)
        {
            int n = (int)num;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("My thread: " + i);
                Thread.Sleep(0);
            }
        }
     
        public static void OddAndEvenNumbersToConsole(object num)
        {
            // true = odd numbers, false = even numbers
           lock (locker)
            {
                ValueTuple<int, bool> n = (ValueTuple<int, bool>)num;
                for (int i = 0; i < n.Item1; i++)
                {
                    if (i % 2 == 1 && n.Item2)
                    {
                        string str = "Odd Thread: " + i + '\n';
                        Console.Write(str);
                        oddAbdEvenNum += str;
                    }
                    if (i % 2 == 0 && !n.Item2)
                    {
                        string str = "Even Thread: " + i + '\n';
                        Console.Write(str);
                        oddAbdEvenNum += str;
                    }
                }
            }
        }
    }
}
