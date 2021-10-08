using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_OOP
{
    public abstract class Contest
    {
        private string student;
        public virtual string _student { get { return student; } set { student = value; } }

        private string subjects;
        public virtual string _subjects { get { return subjects; } set { subjects = value; } }
        public abstract bool DoClone();
        
        public Contest(string Student, string Subject )
        {
            student = Student;
            subjects = Subject;
        }
        public Contest(string Student)
        {
            student = Student;
            subjects = null;
        }
        public Contest()
        {
            student = null;
            subjects = null;
        }
    }
    public class Test : Contest
    {
        private int numbOfQu;
        public int _numbOfQu { get { return numbOfQu; } set { numbOfQu = value; } }
        public virtual string student { get { return (_student + " сдает тест"); } set { _student = value; } }
        public virtual string subjects { get { return ("Тест по : " + _subjects); } set { _subjects = value; } }

        public override bool DoClone()
        {
            return false;
        }
        public Test(string Student, string Subject, int Number)
        {
            _student = Student;
            _subjects = Subject;
            _numbOfQu = Number;
        }
        public Test()
        { }
        public override string ToString()
        {
            string rez = this._student + this._subjects + this._numbOfQu;
            return rez;
        }
    }
    public class Exam : Contest, IClonable
    {
        private int attemp;
        public int _attemp { get { return attemp; } set { attemp = value; } }
        public override bool DoClone()
        {
            return true;
        }
        public Exam(string Student, string Subject, int Number)
        {
            _student = Student;
            _subjects = Subject;
            _attemp = Number;
        }
        public override string ToString()
        {
            string rez = this._student + this._subjects + this._attemp;
            return rez;
        }
    }
    class FinalExam : Exam 
    {
        static readonly int numberOfExams = 4;
        public FinalExam(string Student, string Subject, int Number, int Numb): base(Student, Subject, Number){}
        public override string ToString()
        {
            string rez = this._student + this._subjects + numberOfExams;
            return rez;
        }
    }
    sealed class Question : Test
    {
        private int id;
        public int _id { get { return id; } set { id = value; } }

        public Question(string Student, string Subject, int Number) : base(Student, Subject, Number) { }
        public Question() : base()
        {
            id = 123;
        }
        public void Next()
        {
            id = 100;
        }
    }

    interface IClonable
    {
        bool DoClone();
    }

    public class Printer
    {
        public string IAmPrinting(Contest someobj)
        {
            return someobj.ToString();
        }
        public string IAmPrinting(Test someobj)
        {
            return someobj.ToString();
        }
        public string IAmPrinting(Exam someobj)
        {
            return someobj.ToString();
        }
    }
}
