namespace Rayan.AdvancedTopics.Delegates;

// A delegate is an object that know how to call a method (or a group of methods)
// A reference to a function
// We need delegates for designing extensible and flexible applications (eg frameworks)
// An alternative to delegates are interfaces, but how to decide how to use them?
// We use delegates when Event design patterns is used
// The caller doesn't need to access other properties or methods on the object implementing the method
public class Delegates
{
    public void Run()
    {
        var processor = new PhotoProcessor();
        var filters = new PhotoFilters();
        
        // Here we can use an already defined method, and we can pass on our own
        // Under the curtains our filter handle is driven by System.MulticastDelegate which allows us to have multiple pointers to multiple methods
        // and System.MulticastDelegate is driven by System.Delegate which has two public properties, Method and Target.
        // Method represents the method that the delegate is pointing to and Target is the class that holds the method
        PhotoProcessor.PhotoFilterHandler filterHandler = filters.ApplyContrast;
        filterHandler += filters.ApplyContrast;
        filterHandler += ApplyRedEyeFilter;
        
        processor.Process("photo.jpg", filterHandler);
        
        // Using action
        Action<Photo> filterHandler2 = filters.ApplyContrast;
        
        processor.Process("photo2.jpg", filterHandler2);
    }

    public static void ApplyRedEyeFilter(Photo photo)
    {
        Console.WriteLine("ApplyRedEyeFilter");
    }
}

// Let's suppose we have a photo processor and this is available for installing as a package from nugget
// We provide three default functionalities with our lib/framework. But what if each one of the users of the lib wants to create new functionalities?
// Like removing red eye? We would have to create a new feature and deploy it, but what if twenty users want a different functionality?
// To remove the need of deploying everytime we could let those users set what they want this processor to do. Using delegates
public class PhotoProcessor
{
    // This custom delegates is to illustrate how delegates work, but there's built in options to use it. Generic Action and Generic Func delegates
    public delegate void PhotoFilterHandler(Photo photo);
    
    public void Process(string path, PhotoFilterHandler photoFilterHandler)
    {
        var photo = Photo.Load(path);

        photoFilterHandler(photo);

        photo.Save();    
    }


    // The difference between Action and Func is that func points to a method that returns a value while Actions points to a method that returns void
    // System.Action 
    // System.Func
    public void Process(string path, Action<Photo> photoFilterHandler)
    {
        var photo = Photo.Load(path);
        
        photoFilterHandler(photo);
        
        photo.Save();
    }
}

public class Photo
{
    public static Photo Load(string path)
    {
        return new Photo();
    }

    public void Save(){}
}

public class PhotoFilters
{
    public void ApplyContrast(Photo photo)
    {
        Console.WriteLine("ApplyContrast");
    }

    public void ApplyBrightness(Photo photo)
    {
        Console.WriteLine("ApplyBrightness");
    }

    public void Resize(Photo photo)
    {
        Console.WriteLine("Resize");
    }
}