using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lab_9_OOP
{
    class Program
    {
        static void Main(string[] args)
        {

            PO<int, string> metod = new PO<int, string>();
            metod.Add("qwerty");
            metod.Add("Wasd");
            metod.Add("NOName");
            metod.Add("Yahor");
            metod.Add("Andrei");
            metod.Show();
            
            metod.Insert(2, "qweweww");
            Console.WriteLine("----------------------------");
            metod.Show();
            metod.DeleteFromTo(1, 3);
            Console.WriteLine("----------------------------");
            metod.Show();
            Console.WriteLine("----------------------------");

            for (int i = 0; i < metod.info.Count; i++)
            {
                metod.info1.Add(metod.info.Values[i]);
                Console.WriteLine(metod.info1[i]);
            }

            ObservableCollection<PO<int, string>> task = new ObservableCollection<PO<int, string>>();
            task.Notify += DisplayMessage;
            task.SomeMethod();
            
        }
        private static void DisplayMessage(object sender, PO<int, string> e)
        {
            Console.WriteLine(e.Message);
        }

    }
    class ObservableCollection<PO>
    {
        public event formethod Notify;
        public ObservableCollection<PO<int, string>> SomeMethod()
        {
            Notify?.Invoke(this, new PO<int, string>("Каакой то метод"));
            ObservableCollection<PO<int, string>> xe = new ObservableCollection<PO<int, string>>();

            return xe;
        }
    }


    delegate void formethod(object sender,PO<int, string> e);
    class PO<T, String> : IList<T>
    {
        public string Message { get; }
        public PO(string value)
        {
            Message = value;
        }
        public PO(){}

        static int id = 0;
        public SortedList<int, string> info = new SortedList<int, string>();
        public List<string> info1 = new List<string>();

        public bool IsFixedSize => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        T IList<T>.this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public object this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Add(object value)
        {
            
            info.Add(id, Convert.ToString(value));
            id++;
            return info.Count;
        }

        public void Clear()
        {
            info.Clear();
        }

        public void Insert(int index, object value)
        {
            try
            {
                info.Add(index, Convert.ToString(value));
                
            }
            catch
            {
                for(int i = id; i > index; i--)
                {
                    string bufs = null;
                    info.TryGetValue(i - 1, out bufs);
                    int bufi = info.IndexOfValue(bufs);
                    info.RemoveAt(bufi);
                    info.Add(bufi + 1, bufs);
                }
            }
            finally
            {
                info.Add(index, Convert.ToString(value));
            }
        }

        public void Show()
        {
           foreach(string s in info.Values)
            {
                Console.WriteLine(s);
            }
        }
        public void DeleteFromTo(int start, int end)
        {
            for (int i = start; i < end; end--)
            {
                info.RemoveAt(i);
            }   
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        public void Remove(object value)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    
}
