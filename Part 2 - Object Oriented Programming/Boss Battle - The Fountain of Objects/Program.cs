Console.Title = "The Fountain of Objects";

Console.WriteLine("Welcome to the Fountain of Objects game.\n");
Console.WriteLine("You enter the Cavern of Objects, a dangerous maze in search of the Fountain of Objects.");
Console.WriteLine("Light is visible only in the entrance, and no other light is seen anywhere in the caverns.");
Console.WriteLine("You must navigate the Cavern, activate the fountain, and return to the entrance.\n");
Console.WriteLine("Look out for pits, you'l feel a draft if one is nearby. If you enter a room with a pit, you'll die");
Console.WriteLine("Maelstroms forces of sentient wind. finding with one will send you to another room. You'll hear their roaring if they are nearby\n");
Console.WriteLine("Amaroks roam the caverns.Encountering one is certain death, but you can smell their rotten stench in nearby rooms.");
Console.WriteLine("Luckily, you have a bow, and some arrows. You can shoot monsters in the caverns but be warned: you have a limited supply of 5 arrows.\n");

FountainOfObjects game = new FountainOfObjects();
game.Run();

public class FountainOfObjects
{
    public CavernBuilder Map { get; }
    public Player Player { get; }
    public bool winState { get; set; } = false;
    public bool GameFinished { get; set; } = false;
    public bool IsDead { get; set; } = false;
    private string BoardChoice { get; set; }
    private int[] StartingRowAndColumn = new int[2];
    private int[] fountainCoords = new int[2];

    public FountainOfObjects()
    {
        levelpicker();
        Map = new CavernBuilder(StartingRowAndColumn[0], StartingRowAndColumn[1]);
        Map.RoomSetter(BoardChoice);

        Player = new Player(0, 0);

        Map.CavernGrid[fountainCoords[0], fountainCoords[1]].RoomType = RoomType.Fountain;
        Map.CavernGrid[0, 0].Player = Player;
        Map.CavernGrid[0, 0].RoomType = RoomType.Entrance;
    }

    public void Run()
    {
        while (!GameFinished || IsDead)
        {
            Console.WriteLine("-------------------------------------------------------------------------\n");
            Statemanager(Player);
            if (!IsDead) ActionManager(Player, Map);
            else break;
            Thread.Sleep(1250);
        }
    }

    public string levelpicker()
    {
        Console.WriteLine("Would you like to play a small, medium, or large game?");
        BoardChoice = Console.ReadLine().ToLower();
        switch (BoardChoice)
        {
            case "small":
                StartingRowAndColumn[0] = 4;
                StartingRowAndColumn[1] = 4;
                fountainCoords[0] = 0;
                fountainCoords[1] = 2;
                return BoardChoice;
            case "medium":
                StartingRowAndColumn[0] = 6;
                StartingRowAndColumn[1] = 6;
                fountainCoords[0] = 3;
                fountainCoords[1] = 4;
                return BoardChoice;
            case "large":
                StartingRowAndColumn[0] = 8;
                StartingRowAndColumn[1] = 8;
                fountainCoords[0] = 5;
                fountainCoords[1] = 5;
                return BoardChoice;
            default:
                levelpicker();
                return null;
        }
    }

    public void ActionManager(Player player, CavernBuilder Map)
    {
        Console.WriteLine($"You are currently in room {(Player.CurrentRow, Player.CurrentColumn)}");
        Console.Write("What would you like to do? ");

        switch (Console.ReadLine()?.ToLower())
        {
            case "help":
                Console.WriteLine("\nCommands:\nMove (North/South/East/West)\nShoot (North/South/East/West)\nActivate Fountain\nExit");
                break;
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
                    GameFinished = true;
                }
                else if (!winState && (player.CurrentRow == 0 && player.CurrentColumn == 0))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your fear grew too much to bear, you turn tail and make a dash out of the cavern, never to be seen again.");
                    Console.ResetColor();
                    GameFinished = true;
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

            //shooting Arrows
            case "shoot north":
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                if (player.AmmoCount > 0)
                {
                    if ((Map.CavernGrid[Math.Clamp(player.CurrentRow - 1, 0, Map.TotalRows - 1), player.CurrentColumn].RoomType == RoomType.Maelstrom) || (Map.CavernGrid[Math.Clamp(player.CurrentRow - 1, 0, Map.TotalRows - 1), player.CurrentColumn].RoomType == RoomType.Amarok))
                    {
                        player.AmmoCount--;
                        Console.WriteLine($"\nYou fire an arrow into the north. Sounds like you may have hit something.\nYou now have {player.AmmoCount}/5 Arrow(s)");
                        Map.CavernGrid[Math.Clamp(player.CurrentRow - 1, 0, Map.TotalRows - 1), player.CurrentColumn].RoomType = RoomType.Empty;
                    }
                    else
                    {
                        player.AmmoCount--;
                        Console.WriteLine($"\nYou fire an arrow into the north. Nothing happens. You now have {player.AmmoCount}/5 Arrow(s)");
                    }
                }
                else
                {
                    Console.WriteLine("\nYou have no more arrows to shoot.");
                }
                Console.ResetColor();
                break;
            case "shoot south":
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                if (player.AmmoCount > 0)
                {
                    if ((Map.CavernGrid[Math.Clamp(player.CurrentRow + 1, 0, Map.TotalRows - 1), player.CurrentColumn].RoomType == RoomType.Maelstrom) || (Map.CavernGrid[Math.Clamp(player.CurrentRow + 1, 0, Map.TotalRows - 1), player.CurrentColumn].RoomType == RoomType.Amarok))
                    {
                        player.AmmoCount--;
                        Console.WriteLine($"\nYou fire an arrow into the south. Sounds like you may have hit something.\nYou now have {player.AmmoCount}/5 Arrow(s)");
                        Map.CavernGrid[Math.Clamp(player.CurrentRow + 1, 0, Map.TotalRows - 1), player.CurrentColumn].RoomType = RoomType.Empty;
                    }
                    else
                    {
                        player.AmmoCount--;
                        Console.WriteLine($"\nYou fire an arrow into the south. Nothing happens. You now have {player.AmmoCount}/5 Arrow(s)");
                    }
                }
                else
                {
                    Console.WriteLine("\nYou have no more arrows to shoot.");
                }
                Console.ResetColor();
                break;
            case "shoot east":
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                if (player.AmmoCount > 0)
                {
                    if ((Map.CavernGrid[player.CurrentRow, Math.Clamp(player.CurrentColumn + 1, 0, Map.TotalColumns - 1)].RoomType == RoomType.Maelstrom) || (Map.CavernGrid[player.CurrentRow, Math.Clamp(player.CurrentColumn + 1, 0, Map.TotalColumns - 1)].RoomType == RoomType.Amarok))
                    {
                        player.AmmoCount--;
                        Console.WriteLine($"\nYou fire an arrow into the east. Sounds like you may have hit something.\nYou now have {player.AmmoCount}/5 Arrow(s)");
                        Map.CavernGrid[player.CurrentRow, player.CurrentColumn + 1].RoomType = RoomType.Empty;
                    }
                    else
                    {
                        player.AmmoCount--;
                        Console.WriteLine($"\nYou fire an arrow into the east. Nothing happens. You now have {player.AmmoCount}/5 Arrow(s)");
                    }
                }
                else
                {
                    Console.WriteLine("\nYou have no more arrows to shoot.");
                }
                Console.ResetColor();
                break;
            case "shoot west":
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                if (player.AmmoCount > 0)
                {
                    if ((Map.CavernGrid[player.CurrentRow, Math.Clamp(player.CurrentColumn - 1, 0, Map.TotalColumns - 1)].RoomType == RoomType.Maelstrom) || (Map.CavernGrid[player.CurrentRow, Math.Clamp(player.CurrentColumn - 1, 0, Map.TotalColumns - 1)].RoomType == RoomType.Amarok))
                    {
                        player.AmmoCount--;
                        Console.WriteLine($"\nYou fire an arrow into the west. Sounds like you may have hit something.\nYou now have {player.AmmoCount}/5 Arrow(s)");
                        Map.CavernGrid[player.CurrentRow, Math.Clamp(player.CurrentColumn - 1, 0, Map.TotalColumns - 1)].RoomType = RoomType.Empty;
                    }
                    else
                    {
                        player.AmmoCount--;
                        Console.WriteLine($"\nYou fire an arrow into the west. Nothing happens. You now have {player.AmmoCount}/5 Arrow(s)");
                    }
                }
                else
                {
                    Console.WriteLine("\nYou have no more arrows to shoot.");
                }
                Console.ResetColor();
                break;
        }
    }

    public void Statemanager(Player player)
    {
        Player.PlayerSense(Map);

        if (Map.CavernGrid[player.CurrentRow, player.CurrentColumn].RoomType == RoomType.Entrance)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("There's a warm light coming from the entrance. You're safe here.");
            Console.ResetColor();
        }
        else if (Map.CavernGrid[player.CurrentRow, player.CurrentColumn].RoomType == RoomType.Empty)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
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
        //Death States
        else if (Map.CavernGrid[player.CurrentRow, player.CurrentColumn].RoomType == RoomType.Pit)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("As you stumble into the drafty room, the echo of your footsteps grow louder and louder.\nSuddenly, the floor gives out beneath you, and you plunge into the infinite darkness.\n\nThe End.");
            Console.ResetColor();
            IsDead = true;
            GameFinished = true;

        }
        else if (Map.CavernGrid[player.CurrentRow, player.CurrentColumn].RoomType == RoomType.Amarok)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("As you step into the room, an overwhelming stench assaults your senses. From the dark, a snarling monstrosity leaps forth and proceeds to devour you alive. Your screams echo throughout the cavern...\n\nThe End.");
            Console.ResetColor();
            IsDead = true;
            GameFinished = true;

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

    public void RoomSetter(string choice)
    {
        if (choice == "small")
        {
            CavernGrid[2, 1].RoomType = RoomType.Pit;
            CavernGrid[1, 2].RoomType = RoomType.Maelstrom;
        }
        if (choice == "medium")
        {
            CavernGrid[0, 4].RoomType = RoomType.Pit;
            CavernGrid[2, 2].RoomType = RoomType.Pit;
            CavernGrid[3, 1].RoomType = RoomType.Maelstrom;
            CavernGrid[1, 5].RoomType = RoomType.Amarok;
            CavernGrid[4, 3].RoomType = RoomType.Amarok;

        }
        if (choice == "large")
        {
            CavernGrid[2, 1].RoomType = RoomType.Pit;
            CavernGrid[5, 4].RoomType = RoomType.Pit;
            CavernGrid[1, 6].RoomType = RoomType.Pit;
            CavernGrid[6, 1].RoomType = RoomType.Pit;
            CavernGrid[4, 3].RoomType = RoomType.Maelstrom;
            CavernGrid[3, 5].RoomType = RoomType.Maelstrom;
            CavernGrid[0, 4].RoomType = RoomType.Amarok;
            CavernGrid[4, 1].RoomType = RoomType.Amarok;
            CavernGrid[4, 7].RoomType = RoomType.Amarok;
        }
    }
}

public class Room
{
    public Player? Player { get; set; } = null;
    public RoomType RoomType { get; set; }
    public bool EventTriggered { get; set; } = false;

    public Room(Player? person, RoomType roomtype)
    {
        Player = person;
        RoomType = roomtype;
    }
}

public class Player
{
    public int CurrentRow { get; set; }
    public int CurrentColumn { get; set; }
    public int AmmoCount { get; set; } = 5;

    public Player(int row, int column)
    {
        CurrentRow = row;
        CurrentColumn = column;
    }

    public void MoveToRoom(int row, int column, CavernBuilder map)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        if ((row < map.TotalRows && row >= 0) && (column < map.TotalColumns && column >= 0))
        {
            if (map.CavernGrid[row, column].RoomType == RoomType.Maelstrom)
            {
                map.CavernGrid[row, column].EventTriggered = true;
                map.CavernGrid[CurrentRow, CurrentColumn].Player = null;
                map.CavernGrid[Math.Clamp(row - 1, 0, map.TotalRows - 1), Math.Clamp(column + 2, 0, map.TotalColumns - 1)].Player = this;

                CurrentRow = Math.Clamp(row - 1, 0, map.TotalRows - 1);
                CurrentColumn = Math.Clamp(column + 2, 0, map.TotalColumns - 1);
                Console.WriteLine("You encounter a roaring Maelstrom, but before you could react, a strong gust of wind slams you into another room.");

                map.CavernGrid[row, column].EventTriggered = false;
                map.CavernGrid[row, column].RoomType = RoomType.Empty;

                int newMaelstromRow;
                int newMaelstromColumn;

                if (row + 1 >= map.TotalRows) newMaelstromRow = 0;
                else newMaelstromRow = row + 1;

                if (column - 2 < 0) newMaelstromColumn = map.TotalRows - 2;
                else newMaelstromColumn = column - 2;

                map.CavernGrid[newMaelstromRow, newMaelstromColumn].RoomType = RoomType.Maelstrom;
            }
            else
            {
                map.CavernGrid[CurrentRow, CurrentColumn].Player = null;
                map.CavernGrid[row, column].Player = this;

                CurrentRow = row;
                CurrentColumn = column;
            }
        }
        else
        {
            Console.WriteLine("There's a wall here, you're unable to move that way.");
        }
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    public void PlayerSense(CavernBuilder map)
    {
        Room[]? adjacentRooms = new Room[8]
        {
            RoomGetter(CurrentRow - 1, CurrentColumn + 0, map), //North
            RoomGetter(CurrentRow - 1, CurrentColumn + 1, map), //Northeast
            RoomGetter(CurrentRow + 0, CurrentColumn + 1, map), //East
            RoomGetter(CurrentRow + 1, CurrentColumn + 1, map), //Southeast
            RoomGetter(CurrentRow + 1, CurrentColumn + 0, map), //South
            RoomGetter(CurrentRow + 1, CurrentColumn - 1, map), //Southwest
            RoomGetter(CurrentRow + 0, CurrentColumn - 1, map), //West
            RoomGetter(CurrentRow - 1, CurrentColumn - 1, map)  //Northwest
        };

        foreach (Room room in adjacentRooms)
        {
            if (room?.RoomType == RoomType.Pit)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You feel a steady draft, there must be a pit nearby.");
            }
            if (room?.RoomType == RoomType.Maelstrom)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You hear the intense growling of a Maelstrom nearby.");
            }
            if (room?.RoomType == RoomType.Amarok)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You smell the rotting stench of an Amarok in one of the nearby rooms.");
            }
        }
    }

    public Room? RoomGetter(int row, int col, CavernBuilder Map)
    {
        if ((row < 0 || row >= Map.TotalRows) || (col < 0 || col >= Map.TotalColumns)) return null;
        else return Map.CavernGrid[row, col];
    }
}

public enum RoomType { Empty, Fountain, Entrance, Pit, Maelstrom, Amarok }