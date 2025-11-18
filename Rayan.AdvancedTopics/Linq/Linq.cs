using Rayan.AdvancedTopics.Lambda;

namespace Rayan.AdvancedTopics.Linq;

// Language integrated query
// Gives you the capability to query objects
// You can query objects in memory (eg. Collections)
// Databases, XML, ADO Net data sets
public class Linq
{
    public void Run()
    {
        var repository = new BookRepository();
        
        var allBooks = repository.GetBooks();
        
        // Linq Query operator
        // Less powerful as all keys will be translated to extension methods
        var queryBooks = from book in allBooks
            where book.Price < 10
            orderby book.Title
            select book.Title;

        foreach (var book in queryBooks)
        {
            Console.WriteLine(book);
        }
        
        // Linq Extension Methods
        var books = allBooks
            .Where(w => w.Price < 10)
            .OrderBy(w => w.Title)
            .CustomSelect(s => s.Title);

        foreach (var book in books)
        {
            Console.WriteLine(book);
        }
    }
    
    
}

public static class LinqExtensions
{
    public static IEnumerable<TResult> CustomSelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector){
        foreach (var item in source)
        { 
            yield return selector(item);
        }
    }
}