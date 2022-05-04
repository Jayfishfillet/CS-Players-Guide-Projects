Console.Title = "The Prototype";

int pilotNumber = AskForNumber("Pilot, enter a number ");

int AskForNumber(string text)
{
    Console.Write(text);
    int pilotnumber = Convert.ToInt32(Console.ReadLine());

    return pilotnumber;
}

//Older code - Changed because of Level 13 "Taking a Number"
//
//Console.Write("Pilot, enter a number ");
//int pilotNumber = Convert.ToInt32(Console.ReadLine());



while (pilotNumber < 0 || pilotNumber > 100)
{
    Console.Write("That number is out of range, pick a new number ");
    pilotNumber = Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine("That's a good number, press any key to continue.");
Console.ReadKey();
Console.Clear();

//player2 starts from here

Console.Write("Hunter, guess Pilot's number, what is your guess? ");
int hunterGuess = Convert.ToInt32(Console.ReadLine());

do
{
    if (hunterGuess < pilotNumber)
    {
        Console.Write($"{hunterGuess} is too low, try another number ");
        hunterGuess = Convert.ToInt32(Console.ReadLine());
    }

    else if (hunterGuess > pilotNumber)
    {
        Console.Write($"{hunterGuess} is too high, try another number ");
        hunterGuess = Convert.ToInt32(Console.ReadLine());
    }

    else if (hunterGuess == pilotNumber)
    {
        Console.WriteLine($"You got it! Pilot's number was {pilotNumber}");
    }
}
while (hunterGuess != pilotNumber);