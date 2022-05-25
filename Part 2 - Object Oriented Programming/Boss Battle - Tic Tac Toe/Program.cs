Console.Title = "Tic Tac Toe";
TicTacToe game = new TicTacToe();

game.Run();

class TicTacToe
{
    //Initializes 2 players
    Player Player1 = new Player('X');
    Player Player2 = new Player('O');
    bool isPlayer1Turn = true;
    private string player1Name;
    private string player2Name;

    public void Run()
    {
        //Ask for player names
        Console.Write("Player 1, Type your name: ");
        player1Name = Console.ReadLine();

        Console.Write("Player 2, Type your name: ");
        player2Name = Console.ReadLine();

        //Game loopm if player wins, print win message.
        //If the game is a draw, print a message
        //If a win/draw condition isnt met, keep going
        while (true)
        {
            if (Endgame.DidPlayerWin('X'))
            {
                Board.SetBoard();
                Console.WriteLine($"\n{player1Name} WINS!");
                break;
            }
            if (Endgame.DidPlayerWin('O'))
            {
                Board.SetBoard();
                Console.WriteLine($"\n{player2Name} WINS!");
                break;
            }
            if (Endgame.IsDraw())
            {
                Board.SetBoard();
                Console.WriteLine("\nDRAW!");
                break;
            }
            else
            {
                Board.SetBoard();
                TurnManager();
            }
        }
    }

    public void TurnManager()
    {
        if (isPlayer1Turn)
        {
            Player1.GetPlayerSelection($"{player1Name}");
            isPlayer1Turn = false;
        }
        else
        {
            Player2.GetPlayerSelection($"{player2Name}");
            isPlayer1Turn = true;
        }
    }
}

class Player
{
    char PlayerSymbol { get; }

    public Player(char playerSymbol)
    {
        PlayerSymbol = playerSymbol;
    }

    public void GetPlayerSelection(string playername)
    {
        Console.Write($"{playername}, Please select a position: ");
        int positionChoice = (Convert.ToInt32(Console.ReadLine()) - 1);

        //Kicks back user if choice is out of range
        if (positionChoice < 0 || positionChoice > 8)
        {
            Console.Write("Invalid Choice. ");
            this.GetPlayerSelection(playername);
        }
        //Kicks back player if position is taken
        else if (Board.isPositionTaken[positionChoice])
        {
            Console.Write("Position is taken. ");
            this.GetPlayerSelection(playername);
        }
        //flags selected position to taken and marks position with player symbol
        else
        {
            Board.isPositionTaken[positionChoice] = true;
            Board.Position[positionChoice] = PlayerSymbol;
        }
    }
}

static class Board
{
    //Position Statuses
    public static bool[] isPositionTaken { get; set; } = new bool[9];

    //Position on board
    public static char[] Position = new char[9] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };

    public static void SetBoard()
    {
        //clears and re-draws board
        Console.Clear();
        Console.WriteLine($" {Position[6]} | {Position[7]} | {Position[8]} ");
        Console.WriteLine($"---+---+---");
        Console.WriteLine($" {Position[3]} | {Position[4]} | {Position[5]} ");
        Console.WriteLine($"---+---+---");
        Console.WriteLine($" {Position[0]} | {Position[1]} | {Position[2]} ");
        Endgame.DidPlayerWin('X');
        Endgame.DidPlayerWin('O');

    }
}

public static class Endgame
{
    public static bool Draw { get; private set; }

    //Accepts a player symbol to check for win condition
    public static bool DidPlayerWin(char playerIcon)
    {
        //Horizontal Checks
        if (Board.Position[6] == playerIcon && Board.Position[7] == playerIcon && Board.Position[8] == playerIcon)
        {
            return true;
        }
        else if (Board.Position[3] == playerIcon && Board.Position[4] == playerIcon && Board.Position[5] == playerIcon)
        {
            return true;
        }
        else if (Board.Position[0] == playerIcon && Board.Position[1] == playerIcon && Board.Position[2] == playerIcon)
        {
            return true;
        }
        //Player 1 Vertical Checks
        else if (Board.Position[6] == playerIcon && Board.Position[3] == playerIcon && Board.Position[0] == playerIcon)
        {
            return true;
        }
        else if (Board.Position[7] == playerIcon && Board.Position[4] == playerIcon && Board.Position[1] == playerIcon)
        {
            return true;
        }
        else if (Board.Position[8] == playerIcon && Board.Position[5] == playerIcon && Board.Position[2] == playerIcon)
        {
            return true;
        }
        //Player 1 Diagnal Check
        else if (Board.Position[6] == playerIcon && Board.Position[4] == playerIcon && Board.Position[2] == playerIcon)
        {
            return true;
        }
        else if (Board.Position[8] == playerIcon && Board.Position[4] == playerIcon && Board.Position[0] == playerIcon)
        {
            return true;
        }
        else
        {
            Draw = true;
            return false;
        }
    }

    //checks array for claimed positions, breaks loop if it finds an unclaimed spot
    //checks if array is full of claimed spots and sets draw to true
    public static bool IsDraw()
    {
        bool draw = false;

        if (!DidPlayerWin('X') && !DidPlayerWin('O'))
        {
            foreach (bool status in Board.isPositionTaken)
            {
                if (!status)
                {
                    draw = false;
                    break;
                }
                else
                {
                    draw = true;
                }
            }
        }
        else
        { 
            draw = false;
        }

        return draw;
    }
}