public class Program
{
    public static void Main()
    {
        Console.WriteLine("TESTING SOLID PRINCIPLES\n");
        
        // S - Single Responsibility
        Console.WriteLine("S: Single Responsibility");
        var user = new User { Name = "John", Email = "john@email.com" };
        var repo = new UserRepository();
        var emailSvc = new EmailService();
        var validator = new UserValidator();
        
        if (validator.ValidateEmail(user.Email))
        {
            repo.Save(user);
            emailSvc.Send(user, "Welcome!");
        }
        
        // O - Open/Closed
        Console.WriteLine("\nO: Open/Closed");
        var calc1 = new DiscountCalculator(new RegularDiscount());
        var calc2 = new DiscountCalculator(new VIPDiscount());
        Console.WriteLine($"Regular Discount: $ {calc1.Calculate(100)}");
        Console.WriteLine($"VIP Discount: $ {calc2.Calculate(100)}");
        
        // L - Liskov Substitution
        Console.WriteLine("\nL: Liskov Substitution");
        Bird[] birds = { 
            new Eagle { Name = "Eagle" },
            new Penguin { Name = "Penguin" },
            new Ostrich { Name = "Ostrich" }
        };
        foreach (var bird in birds)
        {
            bird.Move();
        }
        
        // I - Interface Segregation
        Console.WriteLine("\nI: Interface Segregation");
        var human = new Human();
        human.Work();
        human.Eat();
        var robot = new Robot();
        robot.Work();
        
        // D - Dependency Inversion
        Console.WriteLine("\nD: Dependency Inversion");
        var notif1 = new Notifier(new EmailNotifier());
        var notif2 = new Notifier(new SMSNotifier());
        var notif3 = new Notifier(new PushNotifier());
        notif1.Notify("Hello via Email!");
        notif2.Notify("Hello via SMS!");
        notif3.Notify("Hello via Push!");
    }
}