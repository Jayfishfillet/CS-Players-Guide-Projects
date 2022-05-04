Console.Write("How many Chocolate eggs were harvested today? ");
int eggsGathered = Convert.ToInt32(Console.ReadLine());
int eggsforSisters = eggsGathered / 4;
int eggsDuckBear = eggsGathered % 4;

Console.WriteLine($"{eggsGathered} eggs have been gathered, each sister gets " + eggsforSisters + " and the duckbear gets " + eggsDuckBear);

