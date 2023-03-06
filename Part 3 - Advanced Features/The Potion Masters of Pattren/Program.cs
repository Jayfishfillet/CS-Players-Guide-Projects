Console.Title = "The Potion Masters of Pattren";

Potion potion = Potion.Water;
Ingredients? ingredient = null;

while (true)
{
    try
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Current Potion: {potion}");
        Console.ResetColor();
        Console.WriteLine($"\nWhat would you like to add?\n1. {Ingredients.Stardust}\n2. {Ingredients.SnakeVenom}\n3. {Ingredients.DragonBreath}\n4. {Ingredients.ShadowGlass}\n5. {Ingredients.EyeshineGem}\n");

        ingredient = Console.ReadKey(true).Key switch
        {
            ConsoleKey.D1 or ConsoleKey.NumPad1 => Ingredients.Stardust,
            ConsoleKey.D2 or ConsoleKey.NumPad2 => Ingredients.SnakeVenom,
            ConsoleKey.D3 or ConsoleKey.NumPad3 => Ingredients.DragonBreath,
            ConsoleKey.D4 or ConsoleKey.NumPad4 => Ingredients.ShadowGlass,
            ConsoleKey.D5 or ConsoleKey.NumPad5 => Ingredients.EyeshineGem
        };
    }
    catch (System.Runtime.CompilerServices.SwitchExpressionException) { continue; }

    var potionMix = (potion, ingredient);

    potion = potionMix switch
    {
        (Potion.Water, Ingredients.Stardust) => Potion.Elixir,
        (Potion.Elixir, Ingredients.SnakeVenom) => Potion.Poison,
        (Potion.Elixir, Ingredients.DragonBreath) => Potion.Flying,
        (Potion.Elixir, Ingredients.ShadowGlass) => Potion.Invisibility,
        (Potion.Elixir, Ingredients.EyeshineGem) => Potion.NightSight,
        (Potion.NightSight, Ingredients.ShadowGlass) or (Potion.Invisibility, Ingredients.EyeshineGem) => Potion.CloudyBrew,
        (Potion.CloudyBrew, Ingredients.Stardust) => Potion.Wraith,
        _ => Potion.Ruined
    };

    if (potion != Potion.Water && potion != Potion.Ruined)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"You've completed the {potion} potion, do you want to keep going?\nEnter Y or N");
        Console.ResetColor();
        
        while(true)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Y) break;
            else if(key == ConsoleKey.N) return;
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"A glamorous failure! You ruined it!\n\nWant to try again?\nEnter Y or N");
        Console.ResetColor();

        while(true)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Y)
            {
                potion = Potion.Water;
                ingredient = null;
                break;
            }
            else if(key == ConsoleKey.N)
            {
                return;
            }
        }
    }
}

enum Potion { Water, Elixir, Poison, Flying, Invisibility, NightSight, CloudyBrew, Wraith, Ruined }
enum Ingredients { Stardust, SnakeVenom, DragonBreath, ShadowGlass, EyeshineGem }