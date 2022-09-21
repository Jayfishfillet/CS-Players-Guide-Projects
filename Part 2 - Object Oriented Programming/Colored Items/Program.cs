Console.Title = "Colored Items";

ColoredItem<Sword> sword = new ColoredItem<Sword>(new Sword(), ConsoleColor.Blue);
ColoredItem<Bow> bow = new ColoredItem<Bow>(new Bow(), ConsoleColor.Red);
ColoredItem<Axe> axe = new ColoredItem<Axe>(new Axe(), ConsoleColor.Green);

sword.Display();
bow.Display();
axe.Display();

public class ColoredItem<Thing>
{
    public Thing Weapon { get; }
    public ConsoleColor Color { get; }

    public ColoredItem(Thing weapon, ConsoleColor color)
    { 
        Weapon = weapon;
        Color = color;
    }

    public void Display()
    { 
        Console.ForegroundColor = Color;
        Console.WriteLine(Weapon);
        Console.ForegroundColor = ConsoleColor.Gray;
    }

}

public class Sword { }
public class Bow { }
public class Axe { }