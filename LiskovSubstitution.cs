// L - LISKOV SUBSTITUTION PRINCIPLE (LSP)

// Forma Incorreta
public class BirdWrong
{
    public virtual void Fly()
    {
        Console.WriteLine("Flying...");
    }
}

public class PenguinWrong : BirdWrong
{
    public override void Fly()
    {
        throw new NotImplementedException("Penguin can't fly!");
    }
}

// forma Correta
public abstract class Bird
{
    public string Name { get; set; }
    public abstract void Move();
}

public class Eagle : Bird
{
    public override void Move()
    {
        Console.WriteLine($"{Name} is flying high!");
    }
}

public class Penguin : Bird
{
    public override void Move()
    {
        Console.WriteLine($"{Name} is swimming!");
    }
}

public class Ostrich : Bird
{
    public override void Move()
    {
        Console.WriteLine($"{Name} is running fast!");
    }
}