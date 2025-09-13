using System;
using System.Collections.Generic;
using System.Linq;

class CopyHeroPrototype
{
    // ---- Interface Prototype ---
    public interface IPrototype<T>
    {
        T DeepClone();
    }

    // ---- Item Class ----
    public class Item : IPrototype<Item>
    {
        public string Name { get; set; }
        public int Power { get; set; }

        public Item(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }

        // Deep copy
        public Item DeepClone()
        {
            return new Item(Name, Power);
        }
    }

    // ---- Hero Class ----
    public class Hero : IPrototype<Hero>
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public List<Item> Inventory { get; set; }

        public Hero(string name, int level)
        {
            this.Name = name;
            this.Level = level;
            this.Inventory = new List<Item>();
        }

        // Shallow copy
        public Hero ShallowClone()
        {
            return (Hero)this.MemberwiseClone();
        }

        // Deep copy
        public Hero DeepClone()
        {
            Hero cloneHero = new Hero(Name, Level);
            foreach (var item in Inventory)
            {
                cloneHero.Inventory.Add(item.DeepClone());
            }
            return cloneHero;
        }

        // Copy with optional parameters
        public Hero CopyWith(string? name = null, int? level = null, List<Item>? inventory = null)
        {
            return new Hero(name ?? this.Name, level ?? this.Level)
            {
                Inventory = inventory ?? this.Inventory.Select(i => i.DeepClone()).ToList()
            };
        }

        // Show information
        public void ShowInfo()
        {
            Console.WriteLine($"Hero: {Name}, Level: {Level}");
            Console.WriteLine("Inventory:");
            foreach (var item in Inventory)
            {
                Console.WriteLine($"- {item.Name} (Power: {item.Power})");
            }
        }
    }

    // ---- Main ----
    static void Main()
    {
        // Original hero
        Hero originalHero = new Hero("Arthur", 10);
        originalHero.Inventory.Add(new Item("Sword", 50));
        originalHero.Inventory.Add(new Item("Shield", 30));

        Console.WriteLine("Original Hero:");
        originalHero.ShowInfo();

        // Shallow copy
        Hero shallowCopiedHero = originalHero.ShallowClone();
        shallowCopiedHero.Name = "Lancelot";
        shallowCopiedHero.Level = 12;

        Console.WriteLine("\nShallow Copied Hero:");
        shallowCopiedHero.ShowInfo();

        // Deep copy
        Hero clonedHero = originalHero.DeepClone();
        clonedHero.Name = "Lancelot";
        clonedHero.Level = 12;
        clonedHero.Inventory[0].Name = "Magic Sword";
        clonedHero.Inventory[0].Power = 80;

        Console.WriteLine("\nDeep Cloned Hero:");
        clonedHero.ShowInfo();

        // CopyWith modification
        Hero modifiedHero = originalHero.CopyWith(name: "Gawain", level: 11);
        modifiedHero.Inventory.Add(new Item("Helmet", 20));

        Console.WriteLine("\nModified Hero (using CopyWith):");
        modifiedHero.ShowInfo();

        Console.WriteLine("\nOriginal Hero after modifications:");
        originalHero.ShowInfo();
    }
}
