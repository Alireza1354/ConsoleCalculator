using static System.Console;
// Additional input validation ommited for brevity

namespace ConsoleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Enter first number");
            int number1 = int.Parse(ReadLine()!);

            WriteLine("Enter second number");
            int number2 = int.Parse(ReadLine()!);

            WriteLine("Enter operation");
            string operation = ReadLine()!.ToUpperInvariant();

            try
            {
                var calculator = new Calculator();
                var result = calculator.Calculate(number1, number2, operation);
                DisplayResult(result);
            }
            catch (ArgumentNullException ex)
            {
                // Log.Error(ex)
                WriteLine($"Operation was not provided. {ex}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Log.Error(ex)
                WriteLine($"Operation is not supported. {ex}");
            }
            catch (Exception ex)
            {
                WriteLine(value: $"Sorry something went wrong. {ex}");
            }
            finally
            {
                WriteLine("...finally...");
                // Calling dispose on objects that implement the IDisposable interface
                // to make sure you clean up any unmanaged resources.
            }

            WriteLine("\nPress enter to exit");
            ReadLine();


            static void DisplayResult(int result) => WriteLine($"Result is: {result}");
        }
    }
}
