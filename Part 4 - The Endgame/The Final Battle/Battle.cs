using EndGame.CharacterUnits;
namespace EndGame.Battle;

class Battle
{
    int round = 1;
    bool battleOver = false;
    private int battleNumber;
    Random random = new();
    private List<CharacterUnit> heroParty = new();
    private List<CharacterUnit> enemyParty = new();

    public Battle(List<CharacterUnit> heroParty, List<CharacterUnit> enemyParty, int battleNumber)
    {
        this.heroParty = heroParty;
        this.enemyParty = enemyParty;
        this.battleNumber = battleNumber;
    }

    public void BeginBattle()
    {
        Console.Clear();
        while (!battleOver)
        {
            PartyChecker(heroParty, "Hero Party");
            PartyChecker(enemyParty, "Enemy Party");
            if (!battleOver)
            {
                Console.WriteLine($"======= Battle: {battleNumber} | Round: {round} =======\n");
                TurnManager();
                round++;
            }
        }

        void TurnManager()
        {
            foreach (CharacterUnit hero in heroParty)
            {
                if (hero.isAlive)
                {
                    Console.WriteLine($"It is {hero.Name}'s turn...\n");
                    Thread.Sleep(500);
                    var randomAliveUnit = enemyParty.Where(e => e.isAlive).ToList();
                    hero.PerformAction(random.Next(hero.Actions.Count), randomAliveUnit[random.Next(randomAliveUnit.Count)]);
                    Thread.Sleep(2000);
                }
            }
            foreach (CharacterUnit enemy in enemyParty)
            {
                if (enemy.isAlive)
                {
                    Console.WriteLine($"It is {enemy.Name}'s turn...\n");
                    Thread.Sleep(500);
                    var randomAliveUnit = heroParty.Where(e => e.isAlive).ToList();
                    enemy.PerformAction(random.Next(enemy.Actions.Count), randomAliveUnit[random.Next(randomAliveUnit.Count)]);
                    Thread.Sleep(2000);
                }
            }
        }

        void PartyChecker(List<CharacterUnit> party, string partyName)
        {
            if (party.All(p => p.isAlive == false))
            {
                battleOver = true;
                Console.WriteLine($"{partyName} has been defeated.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey(true);
            }
        }
    }