namespace ConsoleCalculator;

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
            try
            {
                return Divide(number: number1, divisor: number2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("...logging...");
                throw new CalculationException(ex);
            }
        }
        //else
        //{
        //    throw new
        //        CalculationOperationNotSupportedException(operation);
        //}
        else
        {
            var ex = new ArgumentOutOfRangeException(nameof(operation),
                "The mathematical operator is not supported.");
            // Once we've created this variable (ex), we can access the data property.
            ex.Data.Add(key: "SUPPLIED_OPERATION", value: operation);
            // Once we've added the additional supplementary information
            // to the exception instance, we can simply go and throw it.
            throw ex;
        }
    }
    private int Divide(int number, int divisor) => number / divisor; // Expression body
}
