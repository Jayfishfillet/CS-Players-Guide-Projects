Console.Title = "Tic Tac Toe";
TicTacToe game = new TicTacToe();

game.Run();

class TicTacToe
{
    //Initializes 2 players
    Player Player1;
    Player Player2;
    Board Board;

    bool isPlayer1Turn = true;
    private string player1Name;
    private string player2Name;

    public TicTacToe()
    { 
        Player1 = new Player('X');
        Player2 = new Player('O');
        Board = new Board();
    }

    public void Run()
    {
        //Ask for player names
        Console.Write("Player 1, Type your name: ");
        player1Name = Console.ReadLine();

        Console.Write("Player 2, Type your name: ");
        player2Name = Console.ReadLine();

        //Game loops
        while (true)
        {
            if (Endgame.DidPlayerWin('X', Board))
            {
                Board.SetBoard(Board);
                Console.WriteLine($"\n{player1Name} WINS!");
                break;
            }
            if (Endgame.DidPlayerWin('O', Board))
            {
                Board.SetBoard(Board);
                Console.WriteLine($"\n{player2Name} WINS!");
                break;
            }
            if (Endgame.IsDraw(Board))
            {
                Board.SetBoard(Board);
                Console.WriteLine("\nDRAW!");
                break;
            }
            else
            {
                Board.SetBoard(Board);
                TurnManager();
            }
        }
    }

    public void TurnManager()
    {
        if (isPlayer1Turn)
        {
            Player1.GetPlayerSelection($"{player1Name}", Board);
            isPlayer1Turn = false;
        }
        else
        {
            Player2.GetPlayerSelection($"{player2Name}", Board);
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

    public void GetPlayerSelection(string playername, Board board)
    {
        Console.Write($"{playername}, Please select a position: ");
        int positionChoice = (Convert.ToInt32(Console.ReadLine()) - 1);

        //Kicks back user if choice is out of range
        if (positionChoice < 0 || positionChoice > 8)
        {
            Console.Write("Invalid Choice. ");
            this.GetPlayerSelection(playername, board);
        }
        //Kicks back player if position is taken
        else if (board.isPositionTaken[positionChoice])
        {
            Console.Write("Position is taken. ");
            this.GetPlayerSelection(playername, board);
        }
        //flags selected position to taken and marks position with player symbol
        else
        {
            board.isPositionTaken[positionChoice] = true;
            board.Position[positionChoice] = PlayerSymbol;
        }
    }
}

public class Board
{
    //Position Statuses
    public bool[] isPositionTaken { get; set; } = new bool[9];

    //Position on board
    public char[] Position = new char[9] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };

    public void SetBoard(Board Board)
    {
        //clears and re-draws board
        Console.Clear();
        Console.WriteLine($" {Position[6]} | {Position[7]} | {Position[8]} ");
        Console.WriteLine($"---+---+---");
        Console.WriteLine($" {Position[3]} | {Position[4]} | {Position[5]} ");
        Console.WriteLine($"---+---+---");
        Console.WriteLine($" {Position[0]} | {Position[1]} | {Position[2]} ");
        Endgame.DidPlayerWin('X', this);
        Endgame.DidPlayerWin('O', this);

    }
}

public static class Endgame
{
    //Accepts a player symbol to check for win condition
    public static bool DidPlayerWin(char playerIcon, Board board)
    {
        //Horizontal Checks
        if (board.Position[6] == playerIcon && board.Position[7] == playerIcon && board.Position[8] == playerIcon)
        {
            return true;
        }
        else if (board.Position[3] == playerIcon && board.Position[4] == playerIcon && board.Position[5] == playerIcon)
        {
            return true;
        }
        else if (board.Position[0] == playerIcon && board.Position[1] == playerIcon && board.Position[2] == playerIcon)
        {
            return true;
        }
        //Vertical Checks
        else if (board.Position[6] == playerIcon && board.Position[3] == playerIcon && board.Position[0] == playerIcon)
        {
            return true;
        }
        else if (board.Position[7] == playerIcon && board.Position[4] == playerIcon && board.Position[1] == playerIcon)
        {
            return true;
        }
        else if (board.Position[8] == playerIcon && board.Position[5] == playerIcon && board.Position[2] == playerIcon)
        {
            return true;
        }
        //Diagnal Check
        else if (board.Position[6] == playerIcon && board.Position[4] == playerIcon && board.Position[2] == playerIcon)
        {
            return true;
        }
        else if (board.Position[8] == playerIcon && board.Position[4] == playerIcon && board.Position[0] == playerIcon)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //checks array for claimed positions, breaks loop if it finds an unclaimed spot
    //checks if array is full of claimed spots and sets draw to true
    public static bool IsDraw(Board board)
    {
        bool draw = false;

        if (!DidPlayerWin('X', board) && !DidPlayerWin('O', board))
        {
            foreach (bool status in board.isPositionTaken)
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