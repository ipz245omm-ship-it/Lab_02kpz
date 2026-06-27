namespace Lab2;

public class Virus : ICloneable
{
    public string Name { get; set; }
    public string Species { get; set; }
    public double Weight { get; set; }
    public int Age { get; set; }
    public List<Virus> Children { get; set; } = new List<Virus>();

    public Virus(string name, string species, double weight, int age)
    {
        Name = name;
        Species = species;
        Weight = weight;
        Age = age;
    }

    public object Clone()
    {
        var copy = new Virus(Name + "_copy", Species, Weight, Age);
        foreach (var child in Children)
            copy.Children.Add((Virus)child.Clone());
        return copy;
    }

    public void Print(string indent = "")
    {
        Console.WriteLine($"{indent}- {Name} | {Species} | вага:{Weight}нг | вік:{Age}год");
        foreach (var child in Children)
            child.Print(indent + "  ");
    }
}

public static class Task4Demo
{
    public static void Run()
    {
        Console.WriteLine("\nЗавдання 4: Prototype");

        var root = new Virus("Alpha", "Coronavirus", 0.85, 72);

        var child1 = new Virus("Beta", "Coronavirus", 0.80, 48);
        var child2 = new Virus("Gamma", "Influenza", 0.75, 36);

        child1.Children.Add(new Virus("Delta", "Coronavirus", 0.70, 24));
        child1.Children.Add(new Virus("Epsilon", "Coronavirus", 0.72, 20));
        child2.Children.Add(new Virus("Zeta", "Influenza", 0.68, 18));

        root.Children.Add(child1);
        root.Children.Add(child2);

        Console.WriteLine("\nОригінал:");
        root.Print();

        var clone = (Virus)root.Clone();
        Console.WriteLine("\nКлон:");
        clone.Print();

        clone.Name = "Alpha_MUTATED";
        Console.WriteLine("\nПісля зміни клону - оригінал не змінився:");
        root.Print();
    }
}
