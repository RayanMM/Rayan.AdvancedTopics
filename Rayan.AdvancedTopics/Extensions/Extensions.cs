namespace Rayan.AdvancedTopics.Extensions;

// Extension method allows us to add methods to an existing class without changing its source code and
// Creating new classes that inherits from it
// The main rule on this is that you will only need to use extension methods if you don't have the source code. If you do go ahead and change the source code!
public class Extensions
{
    public void Run()
    {
        var post = "this is supposed to be a very long blog post that I should shorten given the desired number of words.";
        Console.WriteLine(post.Shorten(5));
    }
}

public static class StringExtensions
{
    public static string Shorten(this string str, int numberOfWords)
    {
        switch (numberOfWords)
        {
            case < 0:
                throw new ArgumentOutOfRangeException(nameof(numberOfWords), "The number of words cannot be negative.");
            case 0:
                return string.Empty;
            default:
            {
                var words = str.Split(' ');
        
                return words.Length < numberOfWords ? str : string.Join(" ", words.Take(numberOfWords));
            }
        }
    }
}