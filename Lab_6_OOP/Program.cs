using System;
using System.Collections.Generic;

namespace Lab_5_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test("Egor", "Math", 60);
            Console.WriteLine(test.student);
            Exam exam = new Exam("Egor", "Rus", 2);
            Console.WriteLine(exam._student);
            Question question = new Question();

            question = test as Question;
            if (test is Contest)
            {
                Console.WriteLine("GetIt");
            }
            List<Contest> list = new List<Contest> { new Test("Egor", "Math", 60), new Exam("Egor", "Rus", 2) };

            Printer printer = new Printer();
            foreach (Contest v in list)
            {
                Console.WriteLine(printer.IAmPrinting(v));
            }
            Session session = new Session();

            Exam exam1 = new Exam("Kirill", "OOP", 3);

            session.ts.Add(test);
            session.ts.Add(exam);
            session.ts.Add(exam1);

            session.GetStud("OOP");
            session.GetNumTest();
            session.GetTests(60);

            Controller controller = new Controller();
            controller.GetTests(60, session);

            Console.WriteLine("---------------------Исключения----------------------");
            Console.WriteLine("-----------------------------------------------------");
            //TestException
            try
            {
                Test test1 = new Test("egor", "math", 100);
            }
            catch(TestException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //ExamException
            Console.WriteLine("----------------------");
            try
            {
                Exam exam2 = new Exam("egor", "math", 4);
            }
            catch (ExamException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("У данного ученика это количество равно: " + ex.Value);
            }
            //DivideByZeroException
            Console.WriteLine("----------------------");
            try
            {
                int y = 0;
                int x = 3000;
                Console.WriteLine(x / y);
            }
            catch(DivideByZeroException)
            {
                Console.WriteLine("На число 0 нельзя делить");
            }
            //MaskException
            Console.WriteLine("----------------------");
            try
            {
                Ip ip = new Ip();
                ip.Value = 0;
            }
            catch(MaskException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Exception
            Console.WriteLine("----------------------");
            try
            {
                int[] x = new int[3];
                Console.WriteLine(x[100]);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Good Work");
            }

            Console.WriteLine("----------------------");
            try
            {
                Testing.Method1();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Catch в Main(why) : {ex.Message}");
                Console.WriteLine($"Catch в Main(where) : {ex.TargetSite}");
                Console.WriteLine($"Catch в Main(how to) : {ex.HelpLink}");
            }
            finally
            {
                Console.WriteLine("Блок finally в Main");
            }

            Console.WriteLine(sqrt(9));
            try
            {
                Console.WriteLine(sqrt(-9));
            }
            catch(AssertException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static int sqrt(int num)
        {
            Assert(num < 0);
            int rez = 0;
            while(rez * rez != num)
            {
                rez++;
            }

            return (rez);
        }

        private static void Assert(bool v)
        {
            if(v)
            throw new AssertException("Недопустимое значение");
        }
    }
    
    class Testing
    {
        public static void Method1()
        {
            try
            {
                Method2();
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Catch в Method1 : {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Блок finally в Method1");
            }
        }
        static void Method2()
        {
            try
            {
                int x = 3000;  
                int y = x / 0;
            }
            finally
            {
                Console.WriteLine("Блок finally в Method2");
            }    
        }
    }

    sealed partial class Question
    {
        public void Next()
        {
            id += 100;
        }
    }
    public class Session
    {
        public List<object> ts = new System.Collections.Generic.List<object>();

        public void GetStud(string sub)
        {
            foreach(Contest v in ts)
            {
                if(v._subjects == sub)
                Console.WriteLine(v._student);
            }
        }
        public void GetNumTest()
        {
            Console.WriteLine(ts.Count);
        }
        public void GetTests(int num)
        {
            string buf;
            for (int i = 0; i < ts.Count; i++)
            {
                buf = Convert.ToString(ts[i]);
                if (buf.Contains(Convert.ToString(num)))
                {
                    Console.WriteLine(buf);
                }
            }
        }
    }
    public class Controller
    {
        public void GetStud(string sub, Session session)
        {
            foreach (Contest v in session.ts)
            {
                if (v._subjects == sub)
                    Console.WriteLine(v._student);
            }
        }
        public void GetNumTest(Session session)
        {
            Console.WriteLine(session.ts.Count);
        }
        public void GetTests(int num, Session session)
        {
            string buf;
            for (int i = 0; i < session.ts.Count; i++)
            {
                buf = Convert.ToString(session.ts[i]);
                if (buf.Contains(Convert.ToString(num)))
                {
                    Console.WriteLine(buf);
                }
            }
        }
    }
    class Ip
    {
        public int Value { get { return Value; }  set 
            {
                if (value == 0)
                    throw new MaskException("Ip не может быть нулевым");
            } }
    }
}