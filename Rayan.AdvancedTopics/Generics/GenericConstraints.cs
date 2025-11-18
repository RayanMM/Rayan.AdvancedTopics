namespace Rayan.AdvancedTopics.Generics;

// where T : IComparable (so it will extend some methods like compareTo())
// where T : Book (can be the class book itself or any of its children or any class that inherits it
// where T : struct (any type value, like int, string, double)
// where T : class
// where T : new() (meaning an object that has a default constructor)
public class GenericConstraints
{
    
}

public class Utilities<T> where T : IComparable, new()
{
    public int Max(int a, int b)
    {
        return a > b ? a : b;
    }

    // To be able to instantiate T we need to say in the declaration of class that T has a default constructor
    public void DoSomething()
    {
        var obj = new T();
    }

    public T Max(T a, T b)
    {
        return a.CompareTo(b) > 0 ? a : b;
    }

    public void CheckUpNull()
    {
        var number = new Nullable<int>(5);
        Console.WriteLine($"Has Value {number.HasValue}");
        Console.WriteLine($"Value {number.GetValueOrDefault()}");
    }
}

// the point of this is to turn any non-nullable type into nullable
// again the point is to show how this works, .net has a built in nullable struct that can be found here System.Nullable
public class Nullable<T> where T : struct
{
    private readonly object _value;

    public Nullable()
    {
        
    }

    public Nullable(T value)
    {
        _value = value;
    }

    public bool HasValue => _value != null;

    public T GetValueOrDefault()
    {
        return HasValue ? (T)_value : default(T);
    }
}