namespace ConsoleCalculator;

public class CalculationOperationNotSupportedException : CalculationException
{
    private const string DefaultMessage =
         "Specified operation was out of range of valid values.";

    // First, we can add one or more properties
    // to add additional data to this custom exception type.
    // we could have this string property called Operation
    // that we can set to indicate the operation that caused this exception.
    public string? Operation { get; }

    /// <summary>
    /// Create a new <see cref="CalculationOperationNotSupportedException"/> with a predefined message.
    /// </summary>
    public CalculationOperationNotSupportedException()
        : base(DefaultMessage) { }

    /// <summary>
    /// Create a new <see cref="CalculationOperationNotSupportedException"/> with a predefined message and a wrapped innerException.
    /// </summary>
    /// <param name="innerException"></param>
    public CalculationOperationNotSupportedException(Exception innerException)
        : base(DefaultMessage, innerException) { }

    /// <summary>
    /// Create a new <see cref="CalculationOperationNotSupportedException"/> with a user-supplied message and a wrapped innerException.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public CalculationOperationNotSupportedException(string message, Exception innerException)
        : base(message, innerException) { }


    // We can also add constructor overloads to allow the user to specify the Operation property value.

    /// <summary>
    /// Create a new <see cref="CalculationOperationNotSupportedException"/> with a default message and the operation that is not supported.
    /// </summary>
    /// <param name="operation"></param>
    public CalculationOperationNotSupportedException(string operation)
        : this() => Operation = operation;

    /// <summary>
    /// Create a new <see cref="CalculationOperationNotSupportedException"/> with the operation that is not supported and a user supplied-message.
    /// </summary>
    /// <param name="operation"></param>
    /// <param name="message"></param>
    public CalculationOperationNotSupportedException(string operation, string message)
        : base(message) => Operation = operation;

    public override string Message
    {
        get
        {
            if (Operation == null)
            {
                return base.Message;
            }
            return base.Message + Environment.NewLine + $"Unsupported operation: {Operation}";
        }
    }
}
