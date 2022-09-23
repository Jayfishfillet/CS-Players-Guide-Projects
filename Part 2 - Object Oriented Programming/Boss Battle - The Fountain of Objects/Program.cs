Console.Title = "The Fountain of Objects";

FountainOfObjects game = new FountainOfObjects();

game.Run();

public class FountainOfObjects
{
    public CavernBuilder Map { get; }
    public Player Player { get; }
    public bool winState { get; set; } = false;
    public bool breakLoop { get; set; } = false;
    public FountainOfObjects()
    {
        Map = new CavernBuilder(4, 4);
        Player = new Player(0, 0);

        Map.CavernGrid[0, 2] = new FountainRoom();
        Map.CavernGrid[0, 0].Player = Player;
        Map.CavernGrid[0, 0] = new Entrance();
    }
    public void Run()
    {
        while (!breakLoop)
        {
            Console.WriteLine("-------------------------------------------------------------------------");
            Statemanager(Player);
            ActionManager(Player, Map);
            Thread.Sleep(1250);
            //Console.WriteLine(" ");
        }
    }

    public void ActionManager(Player player, CavernBuilder Map)
    {
        Console.WriteLine($"You are currently in room {(Player.CurrentRow, Player.CurrentColumn)}");
        Console.Write("What would you like to do? ");


        switch (Console.ReadLine()?.ToLower())
        {
            case "move north":
                Player.MoveToRoom(Player.CurrentRow - 1, Player.CurrentColumn, Map);
                break;
            case "move south":
                Player.MoveToRoom(Player.CurrentRow + 1, Player.CurrentColumn, Map);
                break;
            case "move east":
                Player.MoveToRoom(Player.CurrentRow, Player.CurrentColumn + 1, Map);
                break;
            case "move west":
                Player.MoveToRoom(Player.CurrentRow, Player.CurrentColumn - 1, Map);
                break;
            case "activate fountain":
                if (Map.CavernGrid[Player.CurrentRow, player.CurrentColumn].RoomType == RoomType.Fountain && !winState)
                {
                    winState = true;
                }
                else if (Map.CavernGrid[Player.CurrentRow, player.CurrentColumn].RoomType == RoomType.Fountain && winState)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("The Fountain has already been activated");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is no fountain here to activate.");
                    Console.ResetColor();
                }
                break;
            case "exit":
                if (winState && (player.CurrentRow == 0 && player.CurrentColumn == 0))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You made it! The Fountain of Objects breathes new life, and you've escaped victorious!");
                    Console.ResetColor();
                    breakLoop = true;
                }
                else if (!winState && (player.CurrentRow == 0 && player.CurrentColumn == 0))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your fear grew too much to bear, you turn tail and make a dash out of the cavern, never to be seen again.");
                    Console.ResetColor();
                    breakLoop = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There's nowhere to escape! Find the exit!");
                    Console.ResetColor();
                }
                break;
            default:
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You scratch your head in confusion, you don't know what to do.");
                Console.ResetColor();
                break;

        }
    }

    public void Statemanager(Player player)
    {
        if (Map.CavernGrid[player.CurrentRow, player.CurrentColumn].RoomType == RoomType.Entrance)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("There's a warm light coming from the entrance. You're safe here.");
            Console.ResetColor();
        }
        else if (Map.CavernGrid[player.CurrentRow, player.CurrentColumn].RoomType == RoomType.Empty)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("The Darkness seemingly stretches forever, but you can feel that the room is empty.");
            Console.ResetColor();
        }
        else if ((Map.CavernGrid[player.CurrentRow, player.CurrentColumn].RoomType == RoomType.Fountain) && winState == false)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("You hear dripping in this dimly lit room. The Fountain of Objects is here!");
            Console.ResetColor();
        }
        else if ((Map.CavernGrid[player.CurrentRow, player.CurrentColumn].RoomType == RoomType.Fountain) && winState == true)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("The Fountain bursts forth with a torrent of water! The fountain is activated once more!");
            Console.ResetColor();
        }
    }
}

public class CavernBuilder
{
    public int TotalRows { get; }
    public int TotalColumns { get; }
    public Room[,] CavernGrid { get; set; }

    public CavernBuilder(int totalRows, int totalColumns)
    {
        TotalRows = totalRows;
        TotalColumns = totalColumns;
        CavernGrid = new Room[TotalRows, TotalColumns];

        RoomPopulator();
    }

    public void RoomPopulator()
    {
        for (int i = 0; i < CavernGrid.GetLength(0); i++)
        {
            for (int j = 0; j < CavernGrid.GetLength(1); j++)
            {
                CavernGrid[i, j] = new Room(null, RoomType.Empty);
            }
        }
    }
}

public class Room
{
    public Player? Player { get; set; } = null;
    public RoomType RoomType { get; }

    public Room(Player? person, RoomType roomtype)
    {
        Player = person;
        RoomType = roomtype;
    }
}
public class FountainRoom : Room
{
    public FountainRoom() : base(null, RoomType.Fountain)
    {
    }
}
public class Entrance : Room
{
    public Entrance() : base(null, RoomType.Entrance)
    {
    }
}

public class Player
{
    public int CurrentRow { get; set; }
    public int CurrentColumn { get; set; }

    public Player(int row, int column)
    {
        CurrentRow = row;
        CurrentColumn = column;
    }

    public void MoveToRoom(int row, int column, CavernBuilder layout)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        if ((row < layout.TotalRows && row >= 0) && (column < layout.TotalColumns && column >= 0))
        {
            //sets current room player to null and moves player object to new room
            layout.CavernGrid[CurrentRow, CurrentColumn].Player = null;
            layout.CavernGrid[row, column].Player = this;

            CurrentRow = row;
            CurrentColumn = column;
        }
        else
        {
            Console.WriteLine("There's a wall here, you're unable to move that way.");
        }
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}

public enum RoomType { Empty, Fountain, Entrance }