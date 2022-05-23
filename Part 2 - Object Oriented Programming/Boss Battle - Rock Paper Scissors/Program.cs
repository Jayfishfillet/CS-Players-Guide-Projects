Console.Title = "Rock, Paper, Scissors";
RPSGame newGame = new();
newGame.Rungame();


public class RPSGame
{
    Player playerOne = new Player();
    Player playerTwo = new Player();

    public void RoundResolver()
    {
       PlayerChoice p1choice =  playerOne.GetChoice();
        PlayerChoice p2choice = playerTwo.GetChoice();

        if (p1choice == p2choice)
        {
            Console.WriteLine("Draw");
            BookKeeper.draws++;
        }
        else if (p1choice == PlayerChoice.Rock && p2choice == PlayerChoice.Scissors)
        {
            Console.WriteLine("Player 1 Wins");
            BookKeeper.player1Wins++;
        }
        else if (p1choice == PlayerChoice.Paper && p2choice == PlayerChoice.Rock)
        {
            Console.WriteLine("Player 1 Wins");
            BookKeeper.player1Wins++;
        }
        else if (p1choice == PlayerChoice.Scissors && p2choice == PlayerChoice.Paper)
        {
            Console.WriteLine("Player 1 Wins");
            BookKeeper.player1Wins++;
        }
        else
        {
            Console.WriteLine("Player 2 Wins");
            BookKeeper.player2Wins++;
        }
    }

    public void Rungame()
    {
        while (true)
        {
            RoundResolver();
        }
    }
}

public class Player
{
    public PlayerChoice GetChoice()
    {
        PlayerChoice choice;

        Console.Write("Rock, Paper, or Scissors? ");
        choice = Console.ReadLine().ToLower() switch
         {
             "rock"     => PlayerChoice.Rock,
             "paper"    => PlayerChoice.Paper,
             "scissors" => PlayerChoice.Scissors,
             _          => PlayerChoice.Rock
        };
        return choice;
    }
}

public static class BookKeeper
{
    public static int player1Wins { get; set; }
    public static int player2Wins { get; set; }
    public static int draws { get; set; }
}

public enum PlayerChoice { Rock, Paper, Scissors}