// D - DEPENDENCY INVERSION PRINCIPLE (DIP)

// Forma Incorreta
public class EmailSender
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending email: {message}");
    }
}

public class NotifierWrong
{
    private EmailSender _emailSender = new EmailSender();
    
    public void Notify(string message)
    {
        _emailSender.Send(message);
    }
}

// forma Correta
public interface INotifier
{
    void Send(string message);
}

public class EmailNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine($"Email: {message}");
    }
}

public class SMSNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine($"SMS: {message}");
    }
}

public class PushNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine($"Push: {message}");
    }
}

public class Notifier
{
    private readonly INotifier _notifier;
    
    public Notifier(INotifier notifier)
    {
        _notifier = notifier;
    }
    
    public void Notify(string message)
    {
        _notifier.Send(message);
    }
}