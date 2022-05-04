Console.Title = "Countdown";

//for (int x = 10; x > 0; x--)
//{
//    Console.WriteLine(x);
//}

int startingNumber = recursive(10);

int recursive(int number)
{
    if (number == 1)
    {
        return 1;
    }
    return recursive(number - 1);
}

Console.WriteLine(startingNumber);

