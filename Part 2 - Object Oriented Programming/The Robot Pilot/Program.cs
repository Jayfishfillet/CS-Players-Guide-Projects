Console.Title = "The Robot Pilot";
Console.ForegroundColor = ConsoleColor.White;

//Starting Stats
int manticoreHealth = 10;
int cityHealth = 15;
int gameRound = 1;
bool didHit;

Random random = new Random();

int manticorePosition = random.Next(100) + 1;//GetManticorePosition("Choose a number for the Manticores position. (0 - 100) ", 0, 100);

//Battle Loop

do
{
    RoundStatus();
    PlayerAttack();
    System.Threading.Thread.Sleep(1000);
    gameRound += 1;
    Outcomes();
}
while (manticoreHealth > 0 && cityHealth > 0);


//Methods
void RoundStatus()
{
    Console.WriteLine("-------------------------------------------------------------");
    Console.WriteLine($"BATTLE STATUS: \nROUND: {gameRound} \nCITY HEALTH: {cityHealth}     MANTICORE HEALTH: {manticoreHealth}");

}
void CannonDamageCalculations()
{
    if (gameRound % 15 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        manticoreHealth -= 10;
        Console.WriteLine("Combined damage! Manticore takes 10 damage! \n");
        Console.ForegroundColor = ConsoleColor.White;
    }
    else if (gameRound % 5 == 0 || gameRound % 3 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        manticoreHealth -= 5;
        Console.WriteLine("Direct elemental damage! Manticore suffers 5 damage! \n");
        Console.ForegroundColor = ConsoleColor.White;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Green;
        manticoreHealth -= 1;
        Console.WriteLine("Hit confirmed! Manticore took 1 damage. \n");
        Console.ForegroundColor = ConsoleColor.White;
    }
}
void PlayerAttack()
{
    Console.Write("\nChoose a position to fire at ");
    int playertarget = Convert.ToInt32(Console.ReadLine());

    if (playertarget == manticorePosition)
    {
        CannonDamageCalculations();
        cityHealth -= 1;
    }
    else if (playertarget < manticorePosition)
    {
        didHit = false;
        PlayerMiss();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Miss! Looks like that shot fell short!.");
        Console.ForegroundColor = ConsoleColor.White;
    }
    else if (playertarget > manticorePosition)
    {
        didHit = false;
        PlayerMiss();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Hmm, seems like it went too far...");
        Console.ForegroundColor = ConsoleColor.White;
    }
}

//Handles a player miss
void PlayerMiss()
{
    if (didHit == false)
    {
        cityHealth -= 1;
    }
}

//Handles a win or loss
void Outcomes()
{
    if (manticoreHealth <= 0)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nYou took down the Manticore! Consolas is saved!");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Press any key to exit, you've deserved a rest!");
        System.Threading.Thread.Sleep(1000);
        Console.ReadKey();
    }
    else if (cityHealth <= 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nConsolas has fallen! RETREAT!");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Press any key to exit and retreat with the others.");
        System.Threading.Thread.Sleep(1000);
        Console.ReadKey();

    }
}

