using ColoredConsoleLib;

Console.Title = "Colored Console";

string name = ColoredConsole.Prompt("What is your name? ");
ColoredConsole.WriteLine($"Hi {name}", ConsoleColor.Magenta);