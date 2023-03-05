Console.Title = "The Long Game";

int keyPresses = 0;

Console.Write("What's your name? ");
string? name = Console.ReadLine() switch
{
    null => "User",
    "" =>   "User",
    string enteredName when enteredName.Any(invalidName => Path.GetInvalidFileNameChars().Contains(invalidName)) => "User",
    string enteredName => enteredName
};

try
{
    FileStream readOnlyFileStream = File.OpenRead($"{name}.txt");
    StreamReader streamReader = new StreamReader(readOnlyFileStream);
    keyPresses = Convert.ToInt32(streamReader.ReadLine());
    streamReader.Close();
}

catch (FileNotFoundException) { }

while (true)
{
    Console.Clear();
    if (File.Exists($"{name}.txt"))
    {
        Console.WriteLine($"Hello again {name}, you've pressed {keyPresses} key(s).");
    }
    else
    Console.WriteLine($"Hello {name}, you've pressed {keyPresses} key(s).");
    
    if (Console.ReadKey().Key != ConsoleKey.Enter)
    {
        keyPresses++;
    }
    else break;
}

FileStream fileStream = File.Open($"{name}.txt", FileMode.OpenOrCreate);
StreamWriter streamWriter = new StreamWriter(fileStream);

fileStream.Position = 0;
streamWriter.Write(keyPresses);
streamWriter.Close();