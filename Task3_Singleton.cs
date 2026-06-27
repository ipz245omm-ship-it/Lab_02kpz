namespace Lab2;

public sealed class Authenticator
{
    private static Authenticator? _instance;
    private static readonly object _lock = new object();
    private List<string> _users = new List<string>();

    private Authenticator()
    {
        Console.WriteLine("  Authenticator створено");
    }

    public static Authenticator Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new Authenticator();
                }
            }
            return _instance;
        }
    }

    public void Login(string username, string password)
    {
        if (password == "1234")
        {
            _users.Add(username);
            Console.WriteLine($"  {username} увійшов успішно");
        }
        else
        {
            Console.WriteLine($"  {username} - невірний пароль");
        }
    }

    public void Logout(string username)
    {
        _users.Remove(username);
        Console.WriteLine($"  {username} вийшов");
    }

    public void ShowUsers()
    {
        Console.WriteLine($"  Онлайн: {string.Join(", ", _users)}");
    }
}

public static class Task3Demo
{
    public static void Run()
    {
        Console.WriteLine("\nЗавдання 3: Singleton");

        var a1 = Authenticator.Instance;
        var a2 = Authenticator.Instance;
        Console.WriteLine($"\n  a1 == a2: {ReferenceEquals(a1, a2)}");

        a1.Login("Іван", "1234");
        a2.Login("Марія", "1234");
        a1.Login("Хакер", "wrongpass");
        a1.ShowUsers();
        a2.Logout("Іван");
        a1.ShowUsers();

        Console.WriteLine("\n  Тест потоків:");
        var threads = new List<Thread>();
        for (int i = 0; i < 4; i++)
        {
            int n = i;
            threads.Add(new Thread(() =>
            {
                var inst = Authenticator.Instance;
                Console.WriteLine($"  Thread {n}: hash={inst.GetHashCode()}");
            }));
        }
        threads.ForEach(t => t.Start());
        threads.ForEach(t => t.Join());
    }
}
