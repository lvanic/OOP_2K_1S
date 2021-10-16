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
}