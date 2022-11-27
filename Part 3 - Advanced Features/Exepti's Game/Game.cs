using Exceptions;

class Game
{
    int OatmealRaisinCookie;
    List<int> Choices = new();

    public Game(int oatmealRaisinCookie)
    { 
        OatmealRaisinCookie = oatmealRaisinCookie;
    }

    public void Run()
    {
        while (true)
        {
            GetChoice();
        }
    }

    public void GetChoice()
    {
        Console.Write("Enter a number from 0 - 9: ");
        if (int.TryParse(Console.ReadLine(), out int playerChoice))
        {
            ChoiceValidator();
        }
        else
        {
            Console.WriteLine("Invalid choice, try again.");
            GetChoice();
        }
        
        void ChoiceValidator()
        {
            if (playerChoice > 9 || playerChoice < 0)
            {
                Console.WriteLine("Number out of bounds, choose another.");
                GetChoice();
            }
            else if (Choices.Contains(playerChoice))
            {
                Console.WriteLine("That number has already been picked, try again.");
                GetChoice();
            }
            else if (playerChoice == OatmealRaisinCookie)
            {
                throw new AteCookieException("Haha! You ate the gross Oatmeal Raisin Cookie!");
            }
            else
            {
                Choices.Add(playerChoice);
            }
        }
    }
}