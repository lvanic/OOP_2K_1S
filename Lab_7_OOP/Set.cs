using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_OOP
{
    public class Set<T>
    {
        private readonly List<T> _list;
        
        public Owner owner = new Owner(1, "Egor", "BSTU");
        

        /// <summary>
        Set()
        {
            _list = new List<T>();
        }
        public Set(params T[] args) : this()
        {
            _list.AddRange(args);
        }
        public Set(IEnumerable<T> mas) : this()
        {
            _list.AddRange(mas);
        }
        /// </summary>
        /// <summary>
        public void Add(T el)
        {
            _list.Add(el);
        }
        public void Add(params T[] parms)
        {
            foreach (T el in parms)
            {
                Add(el);
            }
        }
        public void Add(Set<T> arr)
        {
            for (int i = 0; i < arr._list.Count; i++)
            {
                Add(arr.GetEl(i));
            }
        }
        /// </summary>
        public T GetEl(int index)
        {
            T based = default(T);

            if (index > _list.Count || index < 0)
            {
                throw new Exception("GetEl: Неверный index. (" + index.ToString() + ')');
            }
            else
            {
                int counter = 0;
                foreach (T element in _list)
                {
                    if (counter == index)
                        return element;
                    if (Convert.ToChar(element) != ',')
                        counter++;
                }
            }
            return based;
        }
        public Set<T> Union(Set<T> Source)//
        {
            return new Set<T>(_list.Union(Source._list));
        }

        public bool Equals(object obj)
        {
            if (!(obj is Set<T>)) return false;
            Set<T> arr = obj as Set<T>;
            if (this._list.Count != arr._list.Count) return false;
            for (int i = 0; i < this._list.Count; i++)
            {
                if (!(this.GetEl(i).Equals(arr.GetEl(i)))) return false;
            }
            return true;
        }
    
        public int Sum()
        {
            int rezult = 0;
            foreach(T element in _list)
            {
                rezult += Convert.ToInt32(element);
            }
            return rezult;
        }
        public int Max()
        {
            int rezult = Convert.ToInt32(_list.Max());
            return rezult;
        }
        public int Min()
        {
            int rezult = Convert.ToInt32(_list.Min());
            return rezult;
        }
        public int Size()
        {
            return _list.Count;
        }
        public override string ToString()
        {
            return string.Join(",", _list);
        }

        public static Set<T> operator ++(Set<T> set)
        {
            Random random = new Random();
            object newNumber = random.Next();            
            set.Add((T)newNumber);
            return set;
        }
        public static Set<T> operator +(Set<T> arr1, Set<T> arr2)
        {
            Set<T> result = new Set<T>();
            result.Add(arr1);
            result.Add(arr2);
            return result;
        }
        public static bool operator <=(Set<T> arr1, Set<T> arr2)
        {
            return !(arr1 >= arr2);
        }
        public static bool operator >=(Set<T>arr1, Set<T> arr2)
        {
            if (arr1._list.Count != arr2._list.Count)
                return false;

            return arr1.Equals(arr2);
        }
        public static implicit operator int (Set<T> set)
        {
            return set._list.Count;
        }
        public static int operator %(Set<T> set, int index)
        {
            return Convert.ToInt32(set.GetEl(index));
        }
    }
    public class Owner
    {
        public int id { get; set; }
        public string name { get; set; }
        public string company { get; set; }
        public static class Date
        {
            public static DateTime DateAndTime = Convert.ToDateTime("25/09/2021 12:57");
        }
        public Owner(int id, string name, string company)
        {
            this.id = id;
            this.name = name;
            this.company = company;
        }
    }
}
