Console.Title = "Tic Tac Toe";
TicTacToe game = new TicTacToe();

game.Run();

class TicTacToe
{
    //Initializes 2 players
    Player Player1 = new Player('X');
    Player Player2 = new Player('O');
    bool isPlayer1Turn = true;

    public void Run()
    {
        while (true)
        {
            if (Endgame.DidPlayer1Win())
            {
                Board.SetBoard();
                Console.WriteLine("\nPlayer 1 WINS!");
                break;
            }
            if (Endgame.DidPlayer2Win())
            {
                Board.SetBoard();
                Console.WriteLine("\nPlayer 2 WINS!");
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
            Player1.GetPlayerSelection("Player 1");
            isPlayer1Turn = false;
        }
        else
        {
            Player2.GetPlayerSelection("Player 2");
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
        Endgame.DidPlayer1Win();
    }
}

public static class Endgame
{
    public static bool Draw { get; private set; }
    public static bool DidPlayer1Win()
    {
        //Player 1 Horizontal Checks
        if (Board.Position[6] == 'X' && Board.Position[7] == 'X' && Board.Position[8] == 'X')
        {
            return true;
        }
        else if (Board.Position[3] == 'X' && Board.Position[4] == 'X' && Board.Position[5] == 'X')
        {
            return true;
        }
        else if (Board.Position[0] == 'X' && Board.Position[1] == 'X' && Board.Position[2] == 'X')
        {
            return true;
        }
        //Player 1 Vertical Checks
        else if (Board.Position[6] == 'X' && Board.Position[3] == 'X' && Board.Position[0] == 'X')
        {
            return true;
        }
        else if (Board.Position[7] == 'X' && Board.Position[4] == 'X' && Board.Position[1] == 'X')
        {
            return true;
        }
        else if (Board.Position[8] == 'X' && Board.Position[5] == 'X' && Board.Position[2] == 'X')
        {
            return true;
        }
        //Player 1 Diagnal Check
        else if (Board.Position[6] == 'X' && Board.Position[4] == 'X' && Board.Position[2] == 'X')
        {
            return true;
        }
        else if (Board.Position[8] == 'X' && Board.Position[4] == 'X' && Board.Position[0] == 'X')
        {
            return true;
        }
        else
        {
            Draw = true;
            return false;
        }
    }

    public static bool DidPlayer2Win()
    {
        //Player 2 Horizontal Checks
        if (Board.Position[6] == 'O' && Board.Position[7] == 'O' && Board.Position[8] == 'O')
        {
            return true;
        }
        else if (Board.Position[3] == 'O' && Board.Position[4] == 'O' && Board.Position[5] == 'O')
        {
            return true;
        }
        else if (Board.Position[0] == 'O' && Board.Position[1] == 'O' && Board.Position[2] == 'O')
        {
            return true;
        }
        //Player 2 Vertical Checks
        else if (Board.Position[6] == 'O' && Board.Position[3] == 'O' && Board.Position[0] == 'O')
        {
            return true;
        }
        else if (Board.Position[7] == 'O' && Board.Position[4] == 'O' && Board.Position[1] == 'O')
        {
            return true;
        }
        else if (Board.Position[8] == 'O' && Board.Position[5] == 'O' && Board.Position[2] == 'O')
        {
            return true;
        }
        //Player 2 Diagnal Check
        else if (Board.Position[6] == 'O' && Board.Position[4] == 'O' && Board.Position[2] == 'O')
        {
            return true;
        }
        else if (Board.Position[8] == 'O' && Board.Position[4] == 'O' && Board.Position[0] == 'O')
        {
            return true;
        }
        //Draw Check
        else
        {
            Draw = true;
            return false;
        }
    }

    public static bool IsDraw()
    {
        bool draw = false;

        if (!DidPlayer1Win() && !DidPlayer2Win())
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