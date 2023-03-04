Console.Title = "Charberry Trees";

CharberryTree tree = new CharberryTree();
Harvester harvester = new(tree);
Notifier notifier = new(tree);

while (true)
tree.MaybeGrow();
public class CharberryTree
{
    private Random random = new Random();
    public Action? Ripened;

    public bool Ripe { get; set; }
    public void MaybeGrow()
    {
        // Only a tiny chance of ripening each time, but we try a lot!
        if (random.NextDouble() < 0.00000001 && !Ripe)
        {
            Ripe = true;
            Ripened?.Invoke();
        }
    }
}

class Notifier
{
    private CharberryTree tree;
    public Notifier(CharberryTree tree)
    {
        this.tree = tree;
        tree.Ripened += OnRipened;
    }

    void OnRipened()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("A Charberry fruit has ripened!");
    }
}

class Harvester
{
    private CharberryTree tree;
    private int count;
    public Harvester(CharberryTree tree)
    {
        this.tree = tree;
        tree.Ripened += OnRipened;
    }

    void OnRipened()
    {
        count++;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Harvested a Charberry!");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine($"Charberries Harvested: {count}\n");
        tree.Ripe = false;
    }
}
