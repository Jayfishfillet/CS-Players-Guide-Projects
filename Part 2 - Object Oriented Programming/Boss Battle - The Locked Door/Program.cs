Console.Title = "The Door";
Console.Write("Create a 4 digit passcode for the door. ");
int passcode = Convert.ToInt32(Console.ReadLine());

Door newDoor = new Door(passcode);

while (true)
{
    Console.Write($"\nThe door is {newDoor.DoorState}. What will you do? ");
    newDoor.ChoiceRouter(Console.ReadLine().ToLower());
}


internal class Door
{
    public int Passcode {get; set;}
    public DoorState DoorState { get; set; } = DoorState.Locked;

    public Door(int passcode)
    { 
        Passcode = passcode;
    }

    public void ChoiceRouter(string choice)
    {
        switch (choice)
        {
            case "unlock": UnlockDoor();
                break;
            case "open": OpenDoor();
                break;
            case "close": CloseDoor();
                break;
            case "lock": LockDoor();
                break;
        }
    }
    public void UnlockDoor()
    {
        switch (DoorState)
        {
            case DoorState.Open: Console.WriteLine("Unable to open door. It is already open.");
                break;
            case DoorState.Closed: Console.WriteLine("Door is already unlocked.");
                break;
            case DoorState.Locked: UnlockDoorAttempt();
                break;
        }
    }
    public void OpenDoor()
    {
        switch (DoorState)
        {
            case DoorState.Locked: 
                Console.WriteLine("Door is locked, it must be unlocked first");
                break;
            case DoorState.Closed: 
                DoorState = DoorState.Open;
                break;
            case DoorState.Open: 
                Console.WriteLine("Door is already open.");
                break;
        }
    }
    public void CloseDoor()
    {
        switch (DoorState)
        {
            case DoorState.Locked:
                Console.WriteLine("Door is already closed, and locked.");
                break;
            case DoorState.Closed:
                Console.WriteLine("Door is already closed");
                break;
            case DoorState.Open: DoorState = DoorState.Closed;
                break;
        }

    }
    public void LockDoor()
    {
        switch (DoorState)
        {
            case DoorState.Locked:
                Console.WriteLine("Door is already locked");
                break;
            case DoorState.Closed: 
                DoorState = DoorState.Locked;
                break;
            case DoorState.Open: 
                Console.WriteLine("Door must be closed first.");
                break;
        }
    }

    public void UnlockDoorAttempt()
    {
        Console.Write("Enter Passcode to unlock: ");
        int attempt = Convert.ToInt32(Console.ReadLine());
        if (attempt == Passcode)
        {
            DoorState = DoorState.Closed;
            Console.Write("Door is now unlocked, please set a new passcode: ");
            Passcode = Convert.ToInt32(Console.ReadLine());
        }
        else
        {
            Console.WriteLine("Passcode failed.");
            UnlockDoorAttempt();
        }
    }
}

enum DoorState {Open, Closed, Locked}