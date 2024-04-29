namespace Application_Code.Handler;

public abstract class HandlerException : Exception
{

    public HandlerException(string message) : base(message)
    {
    }

    public HandlerException(string message, Exception inner) : base(message, inner)
    {
    }
}

public class InvalidInputException(string input) : HandlerException("Invalid Input " + input);

public class ElementExistsException(string id) : HandlerException("Element already exists with id: " + id);

public class InvalidMethodException(string methodName) : HandlerException("Invalid method: " + methodName);