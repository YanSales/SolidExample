// S - SINGLE RESPONSIBILITY PRINCIPLE (SRP)

// Forma Incorreta
public class UserWrong
{
    public string Name { get; set; }
    public string Email { get; set; }
    
    public void SaveToDatabase()
    {
        Console.WriteLine("Saving to database...");
    }
    
    public void SendEmail()
    {
        Console.WriteLine("Sending email...");
    }
    
    public bool ValidateEmail()
    {
        return Email.Contains("@");
    }
}

// Forma Correta
public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
}

public class UserRepository
{
    public void Save(User user)
    {
        Console.WriteLine($"Saving {user.Name} to database...");
    }
}

public class EmailService
{
    public void Send(User user, string message)
    {
        Console.WriteLine($"Sending email to {user.Email}: {message}");
    }
}

public class UserValidator
{
    public bool ValidateEmail(string email)
    {
        return !string.IsNullOrEmpty(email) && email.Contains("@");
    }
}