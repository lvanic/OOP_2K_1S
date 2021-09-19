using System;

namespace Lab_2_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            House[] house = new House[5];
            

            house[0] = new House(127, 60.3f, 4, 3, "Bobryjskaya", "Panelka", "1981");
            house[1] = new House(128, 66.7f, 4, 3, "Bobryjskaya", "Panelka", "1981");
            house[2] = new House(133, 72.6f, 6, 4, "Tihomirova", "Stalinka", "1951");
            house[3] = new House(54, 67.3f, 2, 4, "Masherova", "Stalinka", "1952");
            house[4] = new House(63, 34.7f, 3, 1, "Knorina", "Panelka", "1973");

            for(int i = 0; i < 5; i++)
            {
                if(house[i].Count == 4)
                {
                    house[i].GetInfo();
                }


                if(house[i].Count == 4 && (house[i].Floor > 3 && house[i].Floor < 9))
                {
                    house[i].GetInfo();
                }
            }
            string result = null;
            house[4].OldOfHouse("2020",  house[4].Date, out result);
            Console.WriteLine(result);
            int x = 0;
            house[4].ChangeCount(ref x);
            Console.WriteLine(x);
            Console.WriteLine(House.Egor);
            Console.WriteLine(house[0].GetHashCode());

            var house12 = new {N = 127,S = 60.3f, F = 4, C = 3, Str = "Bobryjskaya", T = "Panelka", Y = "1981" };
            Console.WriteLine(house12.N);
        }
    }
    partial class House
    {
        //private dynamic n = ;
        public int Value
        {
            get { return this.count; }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            House m = obj as House;
            if (m as House == null)
                return false;

            return m.id == this.id && m.number == this.number && m.square == this.square && m.floor == this.floor;
        }

        public override int GetHashCode()
        {
            return this.id;
        }

        public override string ToString()
        {
            return "Id: " + this.id + "number: " + this.number;
        }
    }
    
}

