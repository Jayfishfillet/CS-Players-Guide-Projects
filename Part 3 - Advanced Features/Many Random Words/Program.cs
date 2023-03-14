Console.Title = "Many Random Words";

while (true)
{
    Console.Write("Enter a word: ");
    string word = Console.ReadLine().ToLower();
    await Task.Run(() => TaskRunner(word));
}

async Task TaskRunner(string word)
{
    Task<(long, TimeSpan)> randomlyRecreateTask = Task.Run(() => RandomlyRecreate(word));
    (long attempts, TimeSpan totalTime) result = await randomlyRecreateTask;

    Console.WriteLine($"You generated \"{word}\" in {result.totalTime.Seconds}s {result.totalTime.Milliseconds}ms\nAttempts: {result.attempts}\n");
}

(long, TimeSpan) RandomlyRecreate(string word)
{
    Random random = new Random();
    string generatedWord = "";
    int attempts = 0;

    DateTime startTime = DateTime.Now;
    while (true)
    {
        attempts++;

        for (int i = 0; i < word.Length; i++)
        {
            generatedWord += (char)('a' + random.Next(26));
        }

        if (generatedWord == word) 
        {
            DateTime endTime = DateTime.Now;
            TimeSpan totalTime = endTime - startTime;
            return (attempts, totalTime);
        }
        else generatedWord = ""; continue;
    }
}