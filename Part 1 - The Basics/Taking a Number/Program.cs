Console.Title = "Taking a Number";


int result = AskForNumber("What is the airspeed velocity of an unladen swallow? ");
int rangeResult = AskForNumberInRange("Enter a number: ", 0, 100);


int AskForNumber(string text)
{
    Console.Write(text);
    int response = Convert.ToInt32(Console.ReadLine());

    return response;
}

int AskForNumberInRange(string text, int min, int max)
{
    Console.Write(text);
    int response = Convert.ToInt32(Console.ReadLine());

    while (response < min || response > max)
    {
        Console.WriteLine("That Number is out of range, try again.");
        response = Convert.ToInt32(Console.ReadLine());
    }
    return response;
}
