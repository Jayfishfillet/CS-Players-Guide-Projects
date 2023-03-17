namespace ColoredConsoleLib;

public static class ColoredConsole
{
    public static string Prompt(string question)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(question);
        string? response = Console.ReadLine();
        Console.ResetColor();
        return response;
    }

    public static void WriteLine(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    public static void Write(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ResetColor();
    }
}