namespace Rayan.AdvancedTopics.Generics;

// Let's suppose whe need a generic list of books, and we don't have either List and Enumerable from C#. We would have to create something like this
// This works! But what if we need to create a similar approach to a Car list for example. We would have duplicate code, or at least a really close looking code
// In order to reuse code and make it simpler we could just create a Object List and then use it right? It would definitely work, but we would pay with performance
// A better approach to solve this up is to use generics
// Using generics improves the performance as in runtime a generic list (or any generics) becomes the type passed on
// This is only a way to explain how generics work, but in real life we would use the generics built in with .net C#. We can find them at System.Collections.Generic
public class BookList
{
    public void Add(Book book)
    {
        throw new NotImplementedException();
    }

    public Book this[int index]
    {
        get => throw new NotImplementedException();
    }
}

public class CarList
{
    public void Add(Car book)
    {
        throw new NotImplementedException();
    }

    public Car this[int index]
    {
        get => throw new NotImplementedException();
    }
}

// Slower as the object has to be boxed when created and unboxed when using types like int
// Also when performing a cast, this casting would have performance penalties
public class ObjectList
{
    public void Add(object book)
    {
        throw new NotImplementedException();
    }

    public Object this[int index]
    {
        get => throw new NotImplementedException();
    }
}

// T here means Type or Template, and it means that the one using this class would have to pass on the type it wants it to be
// See the example at UsingList class 
public class GenericList<T>
{
    public void Add(T item)
    {
        throw new NotImplementedException();
    }

    public T this[int index]
    {
        get => throw new NotImplementedException();
    }
}

// We use Gerenic list with any type we need it to be
public class UsingList
{
    public void AddToList()
    {
        var list = new GenericList<int>();
        list.Add(1);
        var result = list[0];
        
        var bookList = new GenericList<Book>();
        bookList.Add(new Book(){});
        var resultBookList = list[0];
        
        var carList = new GenericList<Car>();
        carList.Add(new Car(){});
        var resultCarList = list[0];
    }    
}

public class Book
{
    
}

public class Car
{
    
}