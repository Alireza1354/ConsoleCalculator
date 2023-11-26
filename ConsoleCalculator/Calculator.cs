using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    internal class Calculator
    {

        public int Calculate(int number1, int number2, string operation)
        {
            // Throw ArgumentNullException for demo purposes. Set ParamName property for operation.
            // throw new ArgumentNullException(nameof(operation)); ---> Operation was not provided.
            // throw new ArgumentNullException(nameof(number2)); ---> An argument was null.

            string nonNullOperation =
                operation ?? throw new ArgumentNullException(nameof(operation));

            if (nonNullOperation == "/")
            {
                return Divide(number: number1, divisor: number2);
            }
            else
            {
                throw new
                    ArgumentOutOfRangeException(
                    paramName: nameof(operation),
                    message: "The mathematical operator is not supported.");
            }
        }
        private int Divide(int number, int divisor) => number / divisor; // Expression body
    }
}
