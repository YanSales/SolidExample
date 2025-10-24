// I - INTERFACE SEGREGATION PRINCIPLE (ISP)

// Forma Incorreta
public interface IWorkerWrong
{
    void Work();
    void Eat();
    void Sleep();
    void ReceiveSalary();
}

public class RobotWrong : IWorkerWrong
{
    public void Work() => Console.WriteLine("Robot working");
    public void Eat() => throw new NotImplementedException("Robot doesn't eat!");
    public void Sleep() => throw new NotImplementedException("Robot doesn't sleep!");
    public void ReceiveSalary() => throw new NotImplementedException("Robot doesn't receive salary!");
}

// forma Correta
public interface IWorkable
{
    void Work();
}

public interface IFeedable
{
    void Eat();
}

public interface ISleepable
{
    void Sleep();
}

public interface IPayable
{
    void ReceiveSalary();
}

public class Human : IWorkable, IFeedable, ISleepable, IPayable
{
    public void Work() => Console.WriteLine("Human working");
    public void Eat() => Console.WriteLine("Human eating");
    public void Sleep() => Console.WriteLine("Human sleeping");
    public void ReceiveSalary() => Console.WriteLine("Human receiving salary");
}

public class Robot : IWorkable
{
    public void Work() => Console.WriteLine("Robot working 24/7");
}