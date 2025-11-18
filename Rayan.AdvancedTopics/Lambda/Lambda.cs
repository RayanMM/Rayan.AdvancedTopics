namespace Rayan.AdvancedTopics.Lambda;

// Lambda expressions are an anonymous method that has no access modifier, no name, no return statement
public class Lambda
{
    public void  Run()
    {
        // args => expression
        // reads args goes to expression
        // number => number*number;
        
        // We can use delegates and use lambda expressions to execute something
        // Like instead of writing a method to calculate square we could do something like this
        // () => ... no arguments
        // x => ... one argument
        // (x, y, z) => ... multiple arguments
        Func<string> noArgument = () => "noArgument";
        Func<int, int> square = number => number * number;
        Func<int, int, int> multiply = (number1, number2) => number1 * number2;
        
        // Then call it like this
        Console.WriteLine(noArgument());
        Console.WriteLine(square(5));
        Console.WriteLine(multiply(7, 5));
        
        // Lambdas expressions also can be run using variables, constants declared within the method they being declared in

        const int number = 7;

        Func<int, int> divide = n => n / number;
        
        var result = divide(5);

        Console.WriteLine(result);
        
        // Retrieving data from 'database'
        var books = new BookRepository().GetBooks();
        
        // Predicate method is a delegate that returns true or false if certain condition is satisfied
        // We usually see predicate methods when working with collections, like Find methods for lists
        // What happens here is that the Find method iterate the list and passes the object as an argument for the Predicate method
        var cheaper = books.Find(IsBookLessThenTenDolars);
        
        // We easily could replace it by a lambda function
        var cheaperLambda = books.Find(x => x.Price < 10);
    }

    static bool IsBookLessThenTenDolars(Book book)
    {
        return book.Price < 10;
    }
    
    public static int Square(int number)
    {
        return number * number;
    }
}

public class BookRepository
{
    public List<Book> GetBooks()
    {
        return new List<Book>()
        {
            new Book() { Title = "Millennium: The girl with the dragon tattoo", Price = 7 },
            new Book() { Title = "Millennium: The girl who played with fire", Price = 10 },
            new Book() { Title = "Millennium: the girl who kicked the hornets' nest", Price = 3 }
        };
    }
}

public class Book
{
    public string? Title { get; set; }
    public int Price { get; set; }
}