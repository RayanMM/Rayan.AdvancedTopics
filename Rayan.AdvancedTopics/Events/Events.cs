namespace Rayan.AdvancedTopics.Events;

// Events is a mechanism for communication between objects
// Used in building loosely coupled applications
// Helps to extend applications
public class Events
{
    public void Run()
    {
        var encoder = new VideoEncoder(); // Publisher
        var sendEmail = new SendEmail(); // subscriber 1
        var sendSms = new SendSms(); // subscriber 2
        
        // To create a subscriber is pretty simple
        // We need to add the handler, with the same signature as our delegate
        // This is basically a pointer to the method that will actually handle the event
        encoder.VideoEncoded += sendEmail.OnVideoEncoded;
        encoder.VideoEncoded += sendSms.OnVideoEncoded;
        
        encoder.EncodeWithEvent(new Video() { Title = "Test" });
        
    }
}

public class VideoEventArgs : EventArgs
{
    public Video Video { get; set; }
}

public class VideoEncoder
{
    public void Encode(Video video)
    {
        // Encoding logic
        
        // Let's suppose every time a video is encoded we want to send an e-mail to the user
        var email = new SendEmail();
        email.Send(video);
        
        // Lately in the future we also want to send a sms to our user
        // we'd have to add a new call to the SMS method
        var sms = new SendSms();
        sms.Send(video);
    }

    // 1 - Define the delegate
    // 2 - Define and event based on that delegate
    // 3 - Raise the event
    // By convention the first parameter on the event handler is an object followed by and EventArgs to pass on additional arguments
    // The subscriber must have the same returning type and signature of this method
    // This delegate point is to illustrate how things work, but behind the curtains .net has done the hard work
    // There is a built-in delegate called EventHandler that comes in two forms EventHandler and EventHandler<TEventArgs>
    public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);

    // Using this discards the need creating a delegate
    public EventHandler<VideoEventArgs> VideoEndoded2;
    
    public event VideoEncodedEventHandler? VideoEncoded;
    
    public void EncodeWithEvent(Video video)
    {
        // Encoding logic
        Thread.Sleep(3000);
        
        OnVideoEncoded(video);
    }

    // By convention an Event Publisher should always be protected, virtual and void. And Its name should Start with On followed by the name of the event
    protected virtual void OnVideoEncoded(Video video)
    {
        if(VideoEncoded != null)
            VideoEncoded(this, new VideoEventArgs() { Video = video });
    }
}

public class SendEmail
{
    public void OnVideoEncoded(object source, VideoEventArgs args)
    {
        Send(args.Video);
    }
    
    public void Send(Video video)
    {
        Console.WriteLine($"Sending email... {video.Title}");
    }
}

public class SendSms
{
    public void OnVideoEncoded(object source, VideoEventArgs args)
    {
        Send(args.Video);
    }
    
    public void Send(Video video)
    {
        Console.WriteLine($"Sending sms... {video.Title}");
    }
}

public class Video
{
    public string? Title { get; set; }
}