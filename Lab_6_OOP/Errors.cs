using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5_OOP
{
    class Errors
    {
    }
    class TestException : Exception
    {
        public TestException(string message):base(message)
        {

        }
    }

    class ExamException : ArgumentException
    {
        public int Value { get; }
        public ExamException(string message, int val) : base(message)
        {
            Value = val;
        }
    }

    class MaskException : Exception
    {
        public MaskException(string message) : base(message)
        {
            
        }
    }
    class AssertException : Exception
    {
        public AssertException(string message): base(message)
        {

        }
    }

}
