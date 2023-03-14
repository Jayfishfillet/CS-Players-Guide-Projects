Console.Title = "Asynchronous Random Words";

Console.Write("Enter a word: ");
string? word = Console.ReadLine().ToLower();

DateTime startTime = DateTime.Now;

Task<long> randomlyRecreateTask = Task.Run(() => RandomlyRecreate(word));
long attempts = await randomlyRecreateTask;

DateTime endTime = DateTime.Now;
TimeSpan totalTime = endTime - startTime;

Console.WriteLine($"\nyou generated {word} in {totalTime.Seconds}s {totalTime.Milliseconds}ms, and took {attempts} attempts");

long RandomlyRecreate(string word)
{
    Random random = new Random();
    string generatedWord = "";
    int attempts = 0;

    while (true)
    {
        for (int i = 0; i < word.Length; i++)
        {
            attempts++;
            generatedWord += (char)('a' + random.Next(26));
        }

        if (generatedWord == word) return attempts;
        else generatedWord = ""; continue;
    }
}