// Interface chung
public interface ICoffee
{
    string GetDescription();
    double GetCost();
}

// Coffee cơ bản
public class SimpleCoffee : ICoffee
{
    public string GetDescription() => "Simple Coffee";
    public double GetCost() => 2.0;
}

// Decorator cơ bản
public abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee _coffee;

    public CoffeeDecorator(ICoffee coffee)
    {
        _coffee = coffee;
    }

    public virtual string GetDescription() => _coffee.GetDescription();
    public virtual double GetCost() => _coffee.GetCost();
}

// Decorator cụ thể: Thêm sữa
public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription() => base.GetDescription() + ", Milk";
    public override double GetCost() => base.GetCost() + 0.5;
}

// Decorator cụ thể: Thêm đường
public class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription() => base.GetDescription() + ", Sugar";
    public override double GetCost() => base.GetCost() + 0.2;
}

// Demo
class Program
{
    static void Main()
    {
        ICoffee coffee = new SimpleCoffee();
        Console.WriteLine($"{coffee.GetDescription()} - ${coffee.GetCost()}");

        coffee = new MilkDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} - ${coffee.GetCost()}");

        coffee = new SugarDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} - ${coffee.GetCost()}");
    }
}
