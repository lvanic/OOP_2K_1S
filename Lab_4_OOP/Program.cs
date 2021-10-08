using System;
using System.Collections.Generic;

namespace Lab_4_OOP
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
            if(test is Contest)
            {
                Console.WriteLine("GetIt");
            }
            List<Contest> list = new List<Contest> { new Test("Egor", "Math", 60), new Exam("Egor", "Rus", 2) };

            Printer printer = new Printer();
            foreach( Contest v in list)
            {
                Console.WriteLine(printer.IAmPrinting(v));
            }

        }
    }
}
