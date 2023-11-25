using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    public class Calculator_Switch_Expression
    {
        // we're creating a switch expression.
        // We've currently got two arms of this switch expression,
        // one for the divide operation and one for the addition operation.
        // But because we can throw exceptions from expressions,
        // we could also add this default switch arm to throw a
        // new ArgumentOutOfRangeException.
        public int Calculate(int number1, int number2, string operation) => operation switch
        {
            "/" => Divide(number1, number2),
            "+" => Add(number1, number2),
            _ => throw new ArgumentOutOfRangeException() // Default switch arm
        };

        private int Divide(int number, int divisor) => number / divisor;
        private int Add(int number1, int number2) => number1 + number2;
    }
}
