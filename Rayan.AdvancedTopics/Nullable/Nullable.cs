namespace Rayan.AdvancedTopics.Nullable;

// Value types cannot by default have a null type
// But you can easily work with null using Nullable<DateTime> or DateTime?
public class Nullable
{
    public void Run()
    {
        DateTime? datetime = null;
        DateTime? datetime2 = null;
        
        Console.WriteLine(datetime.HasValue); // Checks up if variable has a value
        Console.WriteLine(datetime.GetValueOrDefault()); // Gets the value or the default value for the given type
        Console.WriteLine(datetime.Value); // gets the value, but if null it will throw an error
        
        // Null coalescing operator
        if (datetime != null)
        {
            datetime2 = datetime.GetValueOrDefault();
        }
        else
        {
            datetime2 = DateTime.Now;
        }
        
        // using null coalescing operator we can do it by using
        datetime2 = datetime ?? DateTime.Now;
    }
}