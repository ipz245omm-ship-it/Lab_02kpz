namespace Lab2;

public abstract class Subscription
{
    public abstract decimal MonthlyPrice { get; }
    public abstract int MinPeriod { get; }
    public abstract List<string> Features { get; }

    public override string ToString()
    {
        return $"{GetType().Name}: ціна={MonthlyPrice}$/міс, мін.термін={MinPeriod}міс, можливості: {string.Join(", ", Features)}";
    }
}

public class DomesticSubscription : Subscription
{
    public override decimal MonthlyPrice => 5.99m;
    public override int MinPeriod => 1;
    public override List<string> Features => new List<string> { "Базові канали", "SD якість", "1 пристрій" };
}

public class EducationalSubscription : Subscription
{
    public override decimal MonthlyPrice => 3.99m;
    public override int MinPeriod => 3;
    public override List<string> Features => new List<string> { "Освітні канали", "HD якість", "Документальні фільми", "2 пристрої" };
}

public class PremiumSubscription : Subscription
{
    public override decimal MonthlyPrice => 14.99m;
    public override int MinPeriod => 1;
    public override List<string> Features => new List<string> { "Всі канали", "4K якість", "Без реклами", "5 пристроїв", "Офлайн перегляд" };
}

public abstract class SubscriptionCreator
{
    public abstract Subscription CreateSubscription(string type);

    public void BuySubscription(string type)
    {
        var sub = CreateSubscription(type);
        Console.WriteLine($"  {GetType().Name} -> {sub}");
    }
}

public class WebSite : SubscriptionCreator
{
    public override Subscription CreateSubscription(string type)
    {
        if (type == "domestic") return new DomesticSubscription();
        if (type == "educational") return new EducationalSubscription();
        if (type == "premium") return new PremiumSubscription();
        throw new ArgumentException("Невідомий тип");
    }
}

public class MobileApp : SubscriptionCreator
{
    public override Subscription CreateSubscription(string type)
    {
        Console.Write("  (знижка 10% для мобільного) ");
        if (type == "domestic") return new DomesticSubscription();
        if (type == "educational") return new EducationalSubscription();
        if (type == "premium") return new PremiumSubscription();
        throw new ArgumentException("Невідомий тип");
    }
}

public class ManagerCall : SubscriptionCreator
{
    public override Subscription CreateSubscription(string type)
    {
        Console.Write("  (менеджер оформлює...) ");
        if (type == "domestic") return new DomesticSubscription();
        if (type == "premium") return new PremiumSubscription();
        throw new ArgumentException("Менеджер не продає цей тип");
    }
}

public static class Task1Demo
{
    public static void Run()
    {
        Console.WriteLine("\nЗавдання 1: Factory Method");

        Console.WriteLine("\nWebSite:");
        var web = new WebSite();
        web.BuySubscription("domestic");
        web.BuySubscription("educational");
        web.BuySubscription("premium");

        Console.WriteLine("\nMobileApp:");
        var app = new MobileApp();
        app.BuySubscription("domestic");
        app.BuySubscription("premium");

        Console.WriteLine("\nManagerCall:");
        var manager = new ManagerCall();
        manager.BuySubscription("domestic");
        manager.BuySubscription("premium");
    }
}
