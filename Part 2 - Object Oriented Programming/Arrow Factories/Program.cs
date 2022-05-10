Console.Title = "Arrow Factories";

while (true)
{
    Console.WriteLine("Would you like a custom arrow, or a premade arrow? (custom/premade)");
    string choice = Console.ReadLine().ToLower();

    if (choice == "custom")
    {
        CustomArrow();
        break;
    }
    else if (choice == "premade")
    {
        PremadeArrowSelection();
        break;
    }
    else
    {
        Console.WriteLine("That isnt an option.\n");
    }
}
void CustomArrow()
{
    Arrow completedArrow = new Arrow(MakeCustomArrow.GetArrowhead(), MakeCustomArrow.GetFletching(), MakeCustomArrow.GetArrowLength());

    Console.WriteLine($"{completedArrow.arrowHead} arrowhead, {completedArrow.fletching} fletching, and a length of {completedArrow.length}");
    Console.WriteLine($"This completed arrow will cost {completedArrow.Cost}");
}

void PremadeArrowSelection()
{
    while (true)
    {
        Console.WriteLine("What Arrow would you like? (Elite/Beginner/Marksman)");
        switch (Console.ReadLine().ToLower())
        {
            case "elite":
            Arrow.CreateEliteArrow();
            Console.WriteLine($"{Arrow.CreateEliteArrow().arrowHead} arrowhead, {Arrow.CreateEliteArrow().fletching} fletching, and a length of {Arrow.CreateEliteArrow().length}");
            Console.WriteLine($"This completed arrow will cost {Arrow.CreateEliteArrow().Cost}");
                return;

            case "beginner":
            Arrow.CreateEliteArrow();
            Console.WriteLine($"{Arrow.CreateBeginnerArrow().arrowHead} arrowhead, {Arrow.CreateBeginnerArrow().fletching} fletching, and a length of {Arrow.CreateBeginnerArrow().length}");
            Console.WriteLine($"This completed arrow will cost {Arrow.CreateBeginnerArrow().Cost}");
                return;

            case "marksman":
            Arrow.CreateMarksmanArrow();
            Console.WriteLine($"{Arrow.CreateMarksmanArrow().arrowHead} arrowhead, {Arrow.CreateMarksmanArrow().fletching} fletching, and a length of {Arrow.CreateMarksmanArrow().length}");
            Console.WriteLine($"This completed arrow will cost {Arrow.CreateMarksmanArrow().Cost}");
                return;

            default:
            Console.WriteLine("That isnt an arrow I can make.\n");
                break;
        }
    }
}


static class MakeCustomArrow
{
    public static ArrowHead GetArrowhead()
    {
        while (true)
        {
            Console.WriteLine("Choose an arrowhead material (Steel/Wood/Obsidian)");
            switch (Console.ReadLine().ToLower())
            {
                case "steel": return ArrowHead.Steel;
                case "wood": return ArrowHead.Wood;
                case "obsidian": return ArrowHead.Obsidian;
                default:
                    Console.WriteLine("That isnt an arrow head material.\n");
                    break;
            }
        }
    }

    public static Fletching GetFletching()
    {
        while (true)
        {
            Console.WriteLine("Choose a fletching material (Plastic/TurkeyFeathers/GooseFeathers)");
            switch (Console.ReadLine().ToLower())
            {
                case "plastic": return Fletching.Plastic;
                case "turkeyfeathers": return Fletching.TurkeyFeathers;
                case "goosefeathers": return Fletching.GooseFeathers;
                default:
                    Console.WriteLine("That isnt a fletching head material.\n");
                    break;
            }
        }

    }

    public static float GetArrowLength()
    {
        Console.WriteLine("How long would you like the arrow to be? (60 - 100)");
        return Convert.ToSingle(Console.ReadLine());
    }
}


class Arrow
{
    public ArrowHead arrowHead { get; }
    public Fletching fletching { get; }
    public float length { get; }
    public float Cost
    {
        get
        {
            float arrowHeadCost = this.arrowHead switch
            {
                ArrowHead.Steel => 10f,
                ArrowHead.Wood => 3f,
                ArrowHead.Obsidian => 5f
            };

            float fletchingCost = this.fletching switch
            {
                Fletching.Plastic => 10f,
                Fletching.TurkeyFeathers => 5f,
                Fletching.GooseFeathers => 3f
            };

            float lengthCost = this.length * 0.05f;
            return (arrowHeadCost + fletchingCost + lengthCost);
        }
    }

    public Arrow(ArrowHead arrowHead, Fletching fletching, float length)
    {
        this.arrowHead = arrowHead;
        this.fletching = fletching;
        this.length = length;
    }

    public static Arrow CreateEliteArrow()
    {
        return new Arrow(ArrowHead.Steel, Fletching.Plastic, 95);
    }

    public static Arrow CreateBeginnerArrow()
    {
        return new Arrow(ArrowHead.Wood, Fletching.GooseFeathers, 75);
    }

    public static Arrow CreateMarksmanArrow()
    {
        return new Arrow(ArrowHead.Steel, Fletching.GooseFeathers, 65);
    }
}

internal enum ArrowHead { Steel, Wood, Obsidian }
internal enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }