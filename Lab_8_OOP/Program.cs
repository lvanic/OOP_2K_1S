using System;

namespace Lab_8_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker worker = new Worker(2, 43);
            Console.WriteLine(worker.stat + " " + worker.mor);
            worker.Notify += DisplayMessage;
            worker.TurnOn();
            worker.TurnOn();
            worker.Upgrade();
            worker.Upgrade();
            worker.Upgrade();
            worker.Upgrade();

            Console.WriteLine("-----------------------------------------");

            Tech printer = new Tech(25);
            Console.WriteLine(printer.brekage);
            printer.Notify += DisplayMessage;
            printer.Upgrade();
            printer.Upgrade();
            printer.TurnOn();
            printer.TurnOn();
            printer.TurnOn();
            printer.TurnOn();
            printer.TurnOn();
            printer.TurnOn();

            Console.WriteLine("-----------------------------------------");
            Func<string, string> funcStr;
            string str = "Y  . a!  ,  h,    ,o  .  r,,";

            Console.WriteLine($"Исходная строка:        {str}");
            funcStr = StringHandler.RemoveS;
            Console.WriteLine($"Без знаков препинания:  {str = funcStr(str)}");
            funcStr = StringHandler.RemoveSpase;
            Console.WriteLine($"Без пробелов:           {str = funcStr(str)}");
            funcStr = StringHandler.Upper;
            Console.WriteLine($"Заглавными буквами:     {str = funcStr(str)}");
            funcStr = StringHandler.Lower;
            Console.WriteLine($"Строчными буквами:      {str = funcStr(str)}");
            funcStr = StringHandler.AddToString;
            Console.WriteLine($"С добавлением символа:  {str = funcStr(str)}");

        }
        private static void DisplayMessage(object sender, Boss e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public delegate void tech(object sender, Boss e);
    public class Boss
    {
        public string Message { get; }
        public Boss(string mes)
        {
            Message = mes;
        }
    }

    public class Worker
    {
        public event tech Notify;
        public int stat { get; set; }
        public int mor { get; set; }

        public void Upgrade()
        {
            if (stat < 5)
            {
                stat++;
                Notify?.Invoke(this, new Boss($"Уровень сотрудника в компании повышен и равен {stat}"));
            }
            else
            {
                Notify?.Invoke(this, new Boss("К сожалению уровень сотрудника достиг максимального значения"));
            }
            mor += 20;
            if (mor < 100)
            {
                Notify?.Invoke(this, new Boss($"Мораль сотрудника увеличилась и равняется {mor}"));
            }
            else
            {
                mor = 100;
                Notify?.Invoke(this, new Boss("Мораль сотрудника на максимальном значении"));
            }

        }
        public void TurnOn()
        {
            mor -= 40;
            if (mor < 0)
            {
                mor = 0;
                Notify?.Invoke(this, new Boss("Сотрудник сломался сделайте что нибудь для восстановления его морали"));
            }
            else
            {
                Notify?.Invoke(this, new Boss("Мораль сотрудника на значении " + mor));
            }
        }
        public Worker(int num1, int num2)
        {
            stat = num1;
            mor = num2;
        }
    }
    public class Tech
    {
        public event tech Notify;
        public int brekage { get; set; }

        public Tech(int num)
        {
            brekage = num;
        }
        public void Upgrade()
        {

            brekage += 45;
            if (brekage < 100)
            {
                Notify?.Invoke(this, new Boss($"Ваша техника починена до {brekage}%"));
            }
            else
            {
                brekage = 100;
                Notify?.Invoke(this, new Boss("Вам починили технику полностью"));
            }

        }
        public void TurnOn()
        {
            if (brekage != 0)
            {
                brekage -= 20;
                if (brekage < 0)
                {
                    brekage = 0;
                    Notify?.Invoke(this, new Boss("Техника сломалась вызовите мастера"));
                }
                else
                {
                    Notify?.Invoke(this, new Boss($"До поломки техники остальось {brekage}%"));
                }
            }
            else
            {
                Notify?.Invoke(this, new Boss("Ваша техника сломана вызовите матера"));
            }

        }
    }
    public static class StringHandler
    {
        public static string RemoveS(string str)
        {
            str = str.Replace(".", string.Empty);
            str = str.Replace(",", string.Empty);
            str = str.Replace("!", string.Empty);
            str = str.Replace("?", string.Empty);
            return str;
        }
        public static string AddToString(string str)
        {
            return str += "char";
        }
        public static string RemoveSpase(string str)
        {
            return str.Replace(" ", string.Empty);
        }
        public static string Upper(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                str = str.Replace(str[i], char.ToUpper(str[i]));
            }
            return str;
        }
        public static string Lower(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                str = str.Replace(str[i], char.ToLower(str[i]));
            }
            return str;
        }
    }
}
