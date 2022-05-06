Chest chestStatus = Chest.locked;


while (true)
{
    Ask();
    switch (Console.ReadLine().ToLower())
    {
        case "unlock":
            if (chestStatus == Chest.locked)
            {
                chestStatus = Chest.closed;
            }
            else if (chestStatus == Chest.open)
            {
                Console.WriteLine($"Chest can't be opened");
            }
            else if (chestStatus == Chest.closed)
            {
                Console.WriteLine("Chest is alreay unlocked.");
            }
            break;

        case "open":
            if (chestStatus == Chest.locked)
            {
                Console.WriteLine($"Chest can not be opened.");
            }
            else if (chestStatus == Chest.open)
            {
                Console.WriteLine($"Chest is already {chestStatus}.");
            }
            else if (chestStatus == Chest.closed)
            {
                chestStatus = Chest.open;
            }
            break;

        case "lock":
            if (chestStatus == Chest.locked)
            {
                Console.WriteLine($"Chest is already {chestStatus}.");
            }
            else if (chestStatus == Chest.open)
            {
                Console.WriteLine($"Chest must be closed first.");
            }
            else if (chestStatus == Chest.closed)
            {
                chestStatus = Chest.locked;
            }
            break;

        case "close":
            if (chestStatus == Chest.locked)
            {
                Console.WriteLine($"Chest is already closed.");
            }
            else if (chestStatus == Chest.open)
            {
                chestStatus = Chest.closed;
            }
            else if (chestStatus == Chest.closed)
            {
                Console.WriteLine($"Chest is already {chestStatus}.");
            }
            break;
        default:
            Console.WriteLine("That doesnt seem to work.");
            break;

    }
}


void Ask()
{
    Console.Write($"Chest is {chestStatus}. What will you do? ");
}

enum Chest  { locked, closed, open  };