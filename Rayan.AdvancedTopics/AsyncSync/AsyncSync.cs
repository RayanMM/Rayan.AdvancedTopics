namespace Rayan.AdvancedTopics.AsyncSync;

// Synchronous programming the program is executed line by line, one at a time.
// When a function is called program execution has to wait until the function returns
// So when running blocking operations like database access, file reading, the application will be blocked by this and be unresponsive

// Asynchronous programming the program execution continues to the next line, without waiting for the function to complete
// Asynchronous programming improves responsiveness
public interface AsyncSync
{
    // Task is an object that encapsulates the state of an asynchronous operation
    // It comes in two forms, Task and Task<>
    public async Task Run()
    {
        // await is a marker for the compiler to tell that that line is asynchronous.
        var client = new HttpClient();
        
        // When running this line the code will return to the caller of this function.
        // Then when the execution finishes it comes back to the next line and then runs it
        var html = await client.GetStringAsync("http://localhost:5000");

        // another example is that you don't have to await an asynchronous task right away you could do something like this
        var htmlTask = client.GetStringAsync("http://localhost:5000");
        
        // you could do any other work here cause the process will return to html task
        var htmlLatelyAwaited = await htmlTask;
        
        // then when the task is complete it will run the rest of the code
        await using var sr = new StreamWriter(htmlLatelyAwaited);
        await sr.WriteAsync(html);
    }
}