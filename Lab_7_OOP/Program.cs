using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                

                
                test1<Egor> test = new test1<Egor>();
                Egor egor = new Egor();
                egor.name = 5;
                test.xe = egor;
                Console.WriteLine(test.xe);

                CollectionType<char> collection = new CollectionType<char>(CollectionType<char>.GetFromFile());
                
                collection.Show();
                collection.Add('E');
                collection.Save();
            }
            catch(Exception ex)
            {
                Console.WriteLine("egor");
            }
            finally
            {
                Console.WriteLine("egorq");
            }
        }
    }
    interface IStand<T>
    {
        public void Add(T element)
        { }
        public void Delete(T element)
        { }
        public void Show()
        { }
    }
    class CollectionType<T> : IStand<T> where T : new()
    {
        private List<T> _list;
        CollectionType()
        {
            _list = new List<T>();
        }
        public CollectionType(params T[] args) : this()
        {
            _list.AddRange(args);
        }
        public CollectionType(IEnumerable<T> mas) : this()
        {
            _list.AddRange(mas);
        }

        public void Save()
        {
            string filee = @"C:\Users\polza\source\repos\ConsoleApp2\out.txt";
            string buf = null;
            using (StreamWriter ex = new StreamWriter(filee))
            {
                
                foreach (T el in this._list)
                {
                    buf += Convert.ToString(el);
                }


                ex.WriteLine(buf);
            }
        }
        public static string GetFromFile()
        {

            string[] lines = File.ReadAllLines(@"C:\Users\polza\source\repos\ConsoleApp2\in.txt");
            string buf = null;

            for (int i = 0; i < lines.Length; i++)
            {    
                buf += lines[i];
            }
            return buf;
            //this._list.Add((T)buf);
        }
        public void Add(T element)
        {
            if (Convert.ToInt16(element) != 0)
            {
                _list.Add(element);
            }
        }
        public void Show()
        {
            foreach (T element in this._list)
            {
                Console.Write(element);
            }
            Console.WriteLine("\n");
        }
        public void Delete(T deleteEl)
        {
            _list.Remove(deleteEl);
        }
    }
    class Egor
    {
        public int name { get; set; }
        //public string surname { get; set; }
    }

    class test1<Egor>
    {

        public Egor xe;
        public test1()
            {
            
            }
        public void Show()
        {
            Console.WriteLine(xe);
        } 
    }
    class Person<T> where T : Egor
    {
        public T egor;
    }
}
