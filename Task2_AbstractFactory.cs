namespace Lab2;

public interface ILaptop { string GetInfo(); }
public interface INetbook { string GetInfo(); }
public interface IEBook { string GetInfo(); }
public interface ISmartphone { string GetInfo(); }

public class IProneLaptop : ILaptop { public string GetInfo() => "IProne MacBook Pro - M3, 16GB, 512GB SSD"; }
public class IProneNetbook : INetbook { public string GetInfo() => "IProne MacBook Air - M2, 8GB, 256GB SSD"; }
public class IProneEBook : IEBook { public string GetInfo() => "IProne iRead - Retina, 32GB"; }
public class IProneSmartphone : ISmartphone { public string GetInfo() => "IProne 15 Pro - A17, 256GB, Triple camera"; }

public class KiaomiLaptop : ILaptop { public string GetInfo() => "Kiaomi Mi Notebook Pro - i7, 16GB, 1TB SSD"; }
public class KiaomiNetbook : INetbook { public string GetInfo() => "Kiaomi Mi Notebook Air - i5, 8GB, 512GB SSD"; }
public class KiaomiEBook : IEBook { public string GetInfo() => "Kiaomi Mi EBook - E-ink, 16GB, 300ppi"; }
public class KiaomiSmartphone : ISmartphone { public string GetInfo() => "Kiaomi Mi 14 - SD8Gen3, 512GB, 200MP"; }

public class BalaxyLaptop : ILaptop { public string GetInfo() => "Balaxy Book Pro - i9, 32GB, 2TB SSD"; }
public class BalaxyNetbook : INetbook { public string GetInfo() => "Balaxy Book Go - i3, 4GB, 128GB SSD"; }
public class BalaxyEBook : IEBook { public string GetInfo() => "Balaxy Tab S9 - AMOLED, 256GB, S Pen"; }
public class BalaxySmartphone : ISmartphone { public string GetInfo() => "Balaxy S24 Ultra - Exynos2400, 1TB, S Pen"; }

public interface ITechFactory
{
    ILaptop CreateLaptop();
    INetbook CreateNetbook();
    IEBook CreateEBook();
    ISmartphone CreateSmartphone();
}

public class IProneFactory : ITechFactory
{
    public ILaptop CreateLaptop() => new IProneLaptop();
    public INetbook CreateNetbook() => new IProneNetbook();
    public IEBook CreateEBook() => new IProneEBook();
    public ISmartphone CreateSmartphone() => new IProneSmartphone();
}

public class KiaomiFactory : ITechFactory
{
    public ILaptop CreateLaptop() => new KiaomiLaptop();
    public INetbook CreateNetbook() => new KiaomiNetbook();
    public IEBook CreateEBook() => new KiaomiEBook();
    public ISmartphone CreateSmartphone() => new KiaomiSmartphone();
}

public class BalaxyFactory : ITechFactory
{
    public ILaptop CreateLaptop() => new BalaxyLaptop();
    public INetbook CreateNetbook() => new BalaxyNetbook();
    public IEBook CreateEBook() => new BalaxyEBook();
    public ISmartphone CreateSmartphone() => new BalaxySmartphone();
}

public static class Task2Demo
{
    static void PrintDevices(ITechFactory factory)
    {
        Console.WriteLine($"  Laptop:     {factory.CreateLaptop().GetInfo()}");
        Console.WriteLine($"  Netbook:    {factory.CreateNetbook().GetInfo()}");
        Console.WriteLine($"  EBook:      {factory.CreateEBook().GetInfo()}");
        Console.WriteLine($"  Smartphone: {factory.CreateSmartphone().GetInfo()}");
    }

    public static void Run()
    {
        Console.WriteLine("\nЗавдання 2: Abstract Factory");

        Console.WriteLine("\nФабрика IProne:");
        PrintDevices(new IProneFactory());

        Console.WriteLine("\nФабрика Kiaomi:");
        PrintDevices(new KiaomiFactory());

        Console.WriteLine("\nФабрика Balaxy:");
        PrintDevices(new BalaxyFactory());
    }
}
