namespace Rayan.AdvancedTopics.ExceptionHandling;

// We can handle unexpected or expected exceptions by wrapping our code in try/catch block
// in the catch block we can handle the exception like logging it, rethrowing or let it pass
// in order to have a better understanding on exceptions look for exceptions handling middleware
public class ExceptionHandling
{
    public void Run()
    {
        try
        {
            var result = 5d / 0;
        }
        catch (RayanException rex)
        {
            Console.WriteLine(rex.Message);
        }
        catch (Exception ex)
        {
            // there are another types of exceptions like DivideByZeroExceptions but all exceptions drive from exception
            Console.WriteLine(ex);
        }
        finally
        {
            // always execute
            // we should clean up resources here like using a dispose() (also we could just wrap the code in using(){} statement so we dispose it "automatically"
        }
    }
}

public class RayanException : Exception
{
    public RayanException(string message, Exception innerException) : base(message, innerException)
    {
        
    }
}