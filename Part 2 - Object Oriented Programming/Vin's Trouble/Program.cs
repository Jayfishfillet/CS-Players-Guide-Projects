﻿Console.Title = "Vin's Trouble";

Arrow completedArrow = new Arrow(GetArrowhead(), GetFletching(), GetArrowLength());

Console.WriteLine($"{completedArrow.returnArrowhead()} arrowhead, {completedArrow.returnFletching()} fletching, and a length of {completedArrow.returnLength()}");
Console.WriteLine($"This completed arrow will cost {completedArrow.GetCost()}");

ArrowHead GetArrowhead()
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

Fletching GetFletching()
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

float GetArrowLength()
{
    Console.WriteLine("How long would you like the arrow to be? (60 - 100)");
    return Convert.ToSingle(Console.ReadLine());
}
class Arrow
{
    private ArrowHead arrowHead;
    private Fletching fletching;
    private float length;

    public Arrow(ArrowHead arrowHead, Fletching fletching, float length)
    {
        this.arrowHead = arrowHead;
        this.fletching = fletching;
        this.length = length;
    }

    public ArrowHead returnArrowhead()
    {
        return arrowHead;
    }

    public Fletching returnFletching()
    {
        return fletching;
    }

    public float returnLength()
    { 
        return length;
    }

    public float GetCost()
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

enum ArrowHead { Steel, Wood, Obsidian }
enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }