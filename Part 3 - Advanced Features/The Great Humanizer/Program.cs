using Humanizer;

Console.Title = "The Great Humanizer";

Console.WriteLine($"When is the feast? {DateTime.UtcNow.AddHours(30).Humanize()}");



