using Exceptions;

Console.Title = "Exepti's Game";

Random random = new Random();
int oatmealRaisinCookie = random.Next(10);

Game ExeptisGame = new Game(oatmealRaisinCookie);

try
{
    ExeptisGame.Run();
}
catch (AteCookieException)
{
    Console.WriteLine("Haha! You ate the gross Oatmeal Raisin Cookie! You lose!");
}
