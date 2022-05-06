Console.Title = "Simula's Soup";

(Food food, Ingredient ingredient, Seasoning seasoning) cookedDish = MealCombination();

(Food, Ingredient, Seasoning) MealCombination()
{
    Food foodChoice = 0;
    Ingredient ingredientChoice = 0;
    Seasoning seasoningChoice = 0;
    bool retryChoice;

    do
    {
        Console.WriteLine("What type of meal would you like? We have Soup, Stew, and Gumbo.");
        retryChoice = false;
        switch (Console.ReadLine().ToLower())
        {
            case "soup":
                foodChoice = Food.soup;
                break;
            case "stew":
                foodChoice = Food.stew;
                break;
            case "gumbo":
                foodChoice = Food.gumbo;
                break;
            default:
                Console.WriteLine("We don't have that here.\n");
                retryChoice = true;
                break;
        }
    }
    while (retryChoice == true);

    do
    {
        Console.WriteLine("What ingredient would you like? Mushrooms, Chicken, Carrots, and Potaroes.");
        retryChoice = false;
        switch (Console.ReadLine().ToLower())
        {
            case "mushrooms":
                ingredientChoice = Ingredient.mushrooms;
                break;
            case "chicken":
                ingredientChoice = Ingredient.chicken;
                break;
            case "carrots":
                ingredientChoice = Ingredient.carrots;
                break;
            case "potatoes":
                ingredientChoice = Ingredient.potatoes;
                break;
            default:
                Console.WriteLine("We don't have that here.\n");
                retryChoice = true;
                break;
        }
    } 
    while (retryChoice == true);

    do
    {
        Console.WriteLine("What seasoning would you prefer? Spicy, Salty, or Sweet?");
        retryChoice = false;
        switch (Console.ReadLine().ToLower())
        {
            case "spicy":
                seasoningChoice = Seasoning.spicy;
                break;
            case "salty":
                seasoningChoice = Seasoning.salty;
                break;
            case "sweet":
                seasoningChoice = Seasoning.sweet;
                break;
            default:
                Console.WriteLine("We don't have that here.\n");
                retryChoice = true;
                break;
        }
    }
    while (retryChoice == true);

    return (foodChoice, ingredientChoice, seasoningChoice);


}


Console.WriteLine($"You've chosen to make a {cookedDish.seasoning} {cookedDish.ingredient} {cookedDish.food}, tasty!");

enum Food {soup, stew, gumbo};
enum Ingredient {mushrooms, chicken, carrots, potatoes}
enum Seasoning {spicy, salty, sweet}