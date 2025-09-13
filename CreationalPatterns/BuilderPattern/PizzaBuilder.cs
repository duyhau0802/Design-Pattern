using System;
using System.Collections.Generic;

public class Pizza
{
    public string Size { get; }
    public bool CheeseCrust { get; }
    public bool SausageCrust { get; }
    public bool Pepperoni { get; }
    public bool Mushroom { get; }
    public bool Olive { get; }
    public string Sauce { get; }

    private Pizza(Builder builder)
    {
        Size = builder.Size!;
        CheeseCrust = builder.CheeseCrust;
        SausageCrust = builder.SausageCrust;
        Pepperoni = builder.Pepperoni;
        Mushroom = builder.Mushroom;
        Olive = builder.Olive;
        Sauce = builder.Sauce!;
    }

    public override String ToString() => $"{Size} {Sauce} Pizza with" +
            $"{(CheeseCrust ? " CheeseCrust" : "")}" +
            $"{(SausageCrust ? " SausageCrust" : "")}" +
            $"{(Pepperoni ? " Pepperoni" : "")}" +
            $"{(Mushroom ? " Mushroom" : "")}" +
            $"{(Olive ? " Olive" : "")}";

    public class Builder
    {
        public string? Size { get; private set; }
        public bool CheeseCrust { get; private set; }
        public bool SausageCrust { get; private set; }
        public bool Pepperoni { get; private set; }
        public bool Mushroom { get; private set; }
        public bool Olive { get; private set; }
        public string? Sauce { get; private set; }

        public Builder SetSize(string size) { Size = size; return this; }
        public Builder AddCheeseCrust() { CheeseCrust = true; return this; }
        public Builder AddSausageCrust() { SausageCrust = true; return this; }
        public Builder AddPepperoni() { Pepperoni = true; return this; }
        public Builder AddMushroom() { Mushroom = true; return this; }
        public Builder AddOlive() { Olive = true; return this; }
        public Builder SetSauce(string sauce) { Sauce = sauce; return this; }

        public Pizza Build()
        {
            if (Size == null) throw new InvalidOperationException("Size is required");
            if (Sauce == null) Sauce = "Tomato"; // default
            return new Pizza(this);
        }
    }

    public class PizzaDirector
    {
        public Pizza CreateVegetarianPizza()
        {
            return new Pizza.Builder()
                .SetSize("Medium")
                .AddMushroom()
                .AddOlive()
                .SetSauce("Tomato")
                .Build();
        }

        public Pizza CreateSpicyPizza()
        {
            return new Pizza.Builder()
                .SetSize("Large")
                .AddPepperoni()
                .AddOlive()
                .SetSauce("Spicy")
                .Build();
        }
    }

    class Program
    {
        static void Main()
        {
            var director = new PizzaDirector();

            Pizza veggie = director.CreateVegetarianPizza();
            Pizza spicy = director.CreateSpicyPizza();

            Pizza custom = new Pizza.Builder()
                .SetSize("Small")
                .AddCheeseCrust()
                .AddPepperoni()
                .SetSauce("BBQ")
                .Build();

            Console.WriteLine(veggie);
            Console.WriteLine(spicy);
            Console.WriteLine(custom);

        }
    }
}
