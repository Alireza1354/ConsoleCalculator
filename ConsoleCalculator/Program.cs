﻿using static System.Console;
// Additional input validation ommited for brevity

namespace ConsoleCalculator
{
    internal class Program
    {
        static void Main()
        {

            AppDomain currentAppDomain = AppDomain.CurrentDomain;
            // This event will fire when there's an unhandled exception that's been thrown.
            currentAppDomain.UnhandledException += new UnhandledExceptionEventHandler(HandleException);
            // hold down Ctrl+period and hit Enter to generate 'HandleException' method.


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
            catch (ArgumentNullException ex) when (ex.ParamName == nameof(operation))
            {
                // Log.Error(ex)
                WriteLine($"Operation was not provided. {ex}");
            }
            catch (ArgumentNullException ex)
            {
                // Log.Error(ex)
                WriteLine($"An argument was null. {ex}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                string suppliedOperation = "Unknown";
                if (ex.Data.Contains("SUPPLIED_OPERATION"))
                {
                    suppliedOperation = (string)ex.Data["SUPPLIED_OPERATION"];
                }

                WriteLine($"Operation '{operation}' is not supported. {ex}");

            }
            catch (CalculationOperationNotSupportedException ex)
            {
                // Log.Error(ex)
                WriteLine($"CalculationOperationNotSupportedException caught '{ex.Operation}'");
                WriteLine(ex);
            }
            catch (CalculationException ex)
            {
                // Log.Error(ex).
                WriteLine($"CalculationException caught");
                WriteLine(ex);
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

        private static void HandleException(object sender, UnhandledExceptionEventArgs e)
        {
            WriteLine($"Sorry there was a problem and we need to close. Details: {e.ExceptionObject}");
            //throw new NotImplementedException();
        }
    }
}
