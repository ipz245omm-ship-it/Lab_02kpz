namespace Lab2;

public class Character
{
    public string Name { get; set; } = "";
    public string Role { get; set; } = "";
    public int Height { get; set; }
    public string Build { get; set; } = "";
    public string HairColor { get; set; } = "";
    public string EyeColor { get; set; } = "";
    public string Outfit { get; set; } = "";
    public List<string> Inventory { get; set; } = new List<string>();
    public string SpecialAbility { get; set; } = "";
    public List<string> GoodDeeds { get; set; } = new List<string>();
    public List<string> EvilDeeds { get; set; } = new List<string>();

    public override string ToString()
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine($"  Ім'я: {Name}, Роль: {Role}");
        sb.AppendLine($"  Зріст: {Height}см, Статура: {Build}");
        sb.AppendLine($"  Волосся: {HairColor}, Очі: {EyeColor}");
        sb.AppendLine($"  Одяг: {Outfit}");
        sb.AppendLine($"  Інвентар: {string.Join(", ", Inventory)}");
        sb.AppendLine($"  Спецздібність: {SpecialAbility}");
        if (GoodDeeds.Count > 0) sb.AppendLine($"  Добрі справи: {string.Join(", ", GoodDeeds)}");
        if (EvilDeeds.Count > 0) sb.AppendLine($"  Злі справи: {string.Join(", ", EvilDeeds)}");
        return sb.ToString();
    }
}

public interface ICharacterBuilder
{
    ICharacterBuilder SetName(string name);
    ICharacterBuilder SetRole(string role);
    ICharacterBuilder SetHeight(int height);
    ICharacterBuilder SetBuild(string build);
    ICharacterBuilder SetHairColor(string color);
    ICharacterBuilder SetEyeColor(string color);
    ICharacterBuilder SetOutfit(string outfit);
    ICharacterBuilder AddItem(string item);
    ICharacterBuilder SetSpecialAbility(string ability);
    Character Build();
}

public class HeroBuilder : ICharacterBuilder
{
    private Character _c = new Character();

    public ICharacterBuilder SetName(string name) { _c.Name = name; return this; }
    public ICharacterBuilder SetRole(string role) { _c.Role = role; return this; }
    public ICharacterBuilder SetHeight(int height) { _c.Height = height; return this; }
    public ICharacterBuilder SetBuild(string build) { _c.Build = build; return this; }
    public ICharacterBuilder SetHairColor(string color) { _c.HairColor = color; return this; }
    public ICharacterBuilder SetEyeColor(string color) { _c.EyeColor = color; return this; }
    public ICharacterBuilder SetOutfit(string outfit) { _c.Outfit = outfit; return this; }
    public ICharacterBuilder AddItem(string item) { _c.Inventory.Add(item); return this; }
    public ICharacterBuilder SetSpecialAbility(string a) { _c.SpecialAbility = a; return this; }

    public HeroBuilder DoGoodDeed(string deed) { _c.GoodDeeds.Add(deed); return this; }

    public Character Build() => _c;
}

public class EnemyBuilder : ICharacterBuilder
{
    private Character _c = new Character();

    public ICharacterBuilder SetName(string name) { _c.Name = name; return this; }
    public ICharacterBuilder SetRole(string role) { _c.Role = role; return this; }
    public ICharacterBuilder SetHeight(int height) { _c.Height = height; return this; }
    public ICharacterBuilder SetBuild(string build) { _c.Build = build; return this; }
    public ICharacterBuilder SetHairColor(string color) { _c.HairColor = color; return this; }
    public ICharacterBuilder SetEyeColor(string color) { _c.EyeColor = color; return this; }
    public ICharacterBuilder SetOutfit(string outfit) { _c.Outfit = outfit; return this; }
    public ICharacterBuilder AddItem(string item) { _c.Inventory.Add(item); return this; }
    public ICharacterBuilder SetSpecialAbility(string a) { _c.SpecialAbility = a; return this; }

    public EnemyBuilder DoEvilDeed(string deed) { _c.EvilDeeds.Add(deed); return this; }

    public Character Build() => _c;
}

public class CharacterDirector
{
    public Character BuildHero(HeroBuilder builder)
    {
        builder.SetName("Артем")
               .SetRole("Паладин")
               .SetHeight(185)
               .SetBuild("Атлетична")
               .SetHairColor("Русе")
               .SetEyeColor("Синє")
               .SetOutfit("Срібна броня")
               .AddItem("Меч Правосуддя")
               .AddItem("Щит")
               .AddItem("Зілля x5")
               .SetSpecialAbility("Божественне сяйво");
        builder.DoGoodDeed("Врятував місто")
               .DoGoodDeed("Переміг дракона");
        return builder.Build();
    }

    public Character BuildEnemy(EnemyBuilder builder)
    {
        builder.SetName("Малькор")
               .SetRole("Некромант")
               .SetHeight(190)
               .SetBuild("Худорляве")
               .SetHairColor("Сиве")
               .SetEyeColor("Червоне")
               .SetOutfit("Чорний балахон")
               .AddItem("Посох Смерті")
               .AddItem("Книга темної магії")
               .SetSpecialAbility("Воскрешення мертвих");
        builder.DoEvilDeed("Знищив три міста")
               .DoEvilDeed("Відкрив портал у пекло");
        return builder.Build();
    }
}

public static class Task5Demo
{
    public static void Run()
    {
        Console.WriteLine("\nЗавдання 5: Builder");

        var director = new CharacterDirector();

        var hero = director.BuildHero(new HeroBuilder());
        Console.WriteLine("\nГерой:");
        Console.WriteLine(hero);

        var enemy = director.BuildEnemy(new EnemyBuilder());
        Console.WriteLine("Ворог:");
        Console.WriteLine(enemy);
    }
}
