using RandomExtensions;

Console.Title = "Better Random";

Random random = new Random();

Console.WriteLine(random.NextDouble(10));
Console.WriteLine(random.NextString("Up", "Down", "Left", "Right"));
Console.WriteLine(random.CoinFlip(9999));
