using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator;


public class CalculationException : Exception
{
    // Default message if the user of this exception doesn't provide a custome message string.
    private const string DefaultMessage =
        "That An error occurred during calculation, " +
        "Ensure that the operator is supported and that the values are within the valid range of values " +
        "for the requested operation.";

    /// <summary>
    /// Create a new <see cref="CalculationException"/> with a predefind message
    /// This constructor will automatically set a default message
    /// </summary>
    public CalculationException() : base(message: DefaultMessage) { }

    /// <summary>
    /// Create a new <see cref="CalculationException"/> with a user-supplied message
    /// The message provided by user
    /// </summary>
    /// <param name="message"></param>
    public CalculationException(string message) : base(message: message) { }

    /// <summary>
    /// Create a new <see cref="CalculationException"/> with a predefind message and a wrapped inner exception.
    /// This will be the exception passed into this constructor by user.
    /// </summary>
    /// <param name="innerException"></param>
    public CalculationException(Exception innerException) : base(DefaultMessage, innerException) { }

    /// <summary>
    /// Create a new <see cref="CalculationException"/> with a user-supplied message and a wrapped innerException.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public CalculationException(string message, Exception innerException):base(message: message, innerException) { }

}
