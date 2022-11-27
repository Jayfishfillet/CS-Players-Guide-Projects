namespace RandomExtensions;

public static class RandomExtensions
{
    public static double NextDouble(this Random random, int maxNumber)
    {
        return random.NextDouble() * maxNumber;
    }

    public static string NextString(this Random random, params string[] words)
    {
        int pickedNumber = random.Next(words.Length);
        return words[pickedNumber];
    }

    public static string CoinFlip(this Random random, int headsOdds = 50)
    {
        int roll = random.Next(101);

        if (roll < Math.Clamp(headsOdds, 0, 100))
        {
            return "Heads!";
        }
        else if (roll == 50)
        {
            return "The Coin landed landed exactly on its edge.";
        }
        else return "Tails!";
    }
}