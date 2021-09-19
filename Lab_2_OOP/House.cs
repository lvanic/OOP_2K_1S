using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lab_2_OOP
{
    public partial class House
    {
        private readonly int id;
        private int number;
        private float square;
        private int floor;
        private int count;
        private string street;
        private string type;
        private string date;
        public static int _id;
        const string city = "Minsk";

        public int Number
        {
            get { return number; }
            set
            {
                if (value < 0)
                    number = 0;
                else
                    number = value;
            }
        }
        public float Square { get { return square; } set { square = value; } }

        public int Floor { get { return floor; } set { floor = value; } }

        public int Count { get { return count; } set { count = value; } }

        public string Street { get { return street; } set { street = value; } }

        public string Type { get { return type; } set { type = value; } }

        public string Date { get { return date; } set { date = value; } }

        static House()//Используется если нужно создать только один экземпляп из этого конструктора или для инициализации статических данных
        {
            Console.WriteLine("Создан первый House");
        }
        //public House() : this(0, 0, 0, 0, "unknow", "unknow", "unknow")
        //{ }
        public House(int _number) : this(_number, 0, 0, 0, "unknow", "unknow", "unknow")
        { }
        public House(int _number, float _square) : this(_number, _square, 0, 0, "unknow", "unknow", "unknow")
        { }
        public House(int _number, float _square, int _floor) : this(_number, _square, _floor, 0, "unknow", "unknow", "unknow")
        { }
        public House(int _number, float _square, int _floor, int _count) : this(_number, _square, _floor, _count, "unknow", "unknow", "unknow")
        { }
        public House(int _number, float _square, int _floor, int _count, string _street) : this(_number, _square, _floor, _count, _street, "unknow", "unknow")
        { }
        public House(int _number, float _square, int _floor, int _count, string _street, string _type) : this(_number, _square, _floor, _count, _street, _type, "unknow")
        { }
        public House(int _number, float _square, int _floor, int _count, string _street, string _type, string _date)
        {
            _id++;
            this.id = _id;
            this.number = _number;
            this.square = _square;
            if (_floor < 1)
                this.floor = 0;
            else
                this.floor = _floor;

            this.count = _count;
            if (_street.Length < 2)
                this.street = "unknow";
            else
                this.street = _street;

            this.type = _type;
            this.date = _date;
        }

        public void GetInfo()
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine(this.id);
            Console.WriteLine(this.number);
            Console.WriteLine(this.square);
            Console.WriteLine(this.floor);
            Console.WriteLine(this.count);
            Console.WriteLine(this.street);
            Console.WriteLine(this.type);
            Console.WriteLine(this.date);
            Console.WriteLine("-------------------------");
        }
        public void OldOfHouse(string year1, string year2, out string result)
        {
            result = Convert.ToString(Convert.ToInt32(year1) - Convert.ToInt32(year2));
        }
        public void ChangeCount(ref int value)
        {
            value = id;
        }
        private House() {}
        public static int Egor = 10000234;
        static void InfoClass()
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine(Egor);
            Console.WriteLine(_id);
            //Console.WriteLine(House.InfoClass);
            Console.WriteLine("-------------------------");
        }
    }
   
}
