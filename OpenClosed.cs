// O - OPEN/CLOSED PRINCIPLE (OCP)

// Forma Incorreta
public class DiscountCalculatorWrong
{
    public decimal CalculateDiscount(string customerType, decimal amount)
    {
        if (customerType == "Regular")
            return amount * 0.05m;
        else if (customerType == "Premium")
            return amount * 0.10m;
        else if (customerType == "VIP")
            return amount * 0.20m;
        
        return 0;
    }
}

// forma Correta
public interface IDiscountStrategy
{
    decimal Calculate(decimal amount);
}

public class RegularDiscount : IDiscountStrategy
{
    public decimal Calculate(decimal amount)
    {
        return amount * 0.05m; 
    }
}

public class PremiumDiscount : IDiscountStrategy
{
    public decimal Calculate(decimal amount)
    {
        return amount * 0.10m; 
    }
}

public class VIPDiscount : IDiscountStrategy
{
    public decimal Calculate(decimal amount)
    {
        return amount * 0.20m; 
    }
}

public class DiscountCalculator
{
    private readonly IDiscountStrategy _strategy;
    
    public DiscountCalculator(IDiscountStrategy strategy)
    {
        _strategy = strategy;
    }
    
    public decimal Calculate(decimal amount)
    {
        return _strategy.Calculate(amount);
    }
}