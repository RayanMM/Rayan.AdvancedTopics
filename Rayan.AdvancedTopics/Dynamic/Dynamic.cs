namespace Rayan.AdvancedTopics.Dynamic;

// It allows us to run code without knowing the type, it skips the compile-time checking and instead be resolved at runtime
// Dynamic runs on DLR - dynamic language runtime
// that sits on CLR - Common language runtime, responsible for loading and executing code in .net platform such as C#, VB, F#
public class Dynamic
{
    // For example, we should be able to solve an unidentified type by using reflection, but reflection charges a lot in performance
    // and written code
    public void Run()
    { 
        object obj = "Mosh";
        
        // Note to myself. Study more about this
        var methodInfo = obj.GetType().GetMethod("GetHashCode");
        methodInfo.Invoke(null, null);
        
        // Using dynamic
        dynamic excelObject = "Mosh";
        excelObject.Optimize();
        
        // Dynamic allows changing variable type without throwing an error
        // Be aware that when using dynamics you should write more unit tests in order to guarantee the application will work as expected
        // But having a type will always be the better option
        dynamic name = "Good person name";
        name = 10;
    }
    
}