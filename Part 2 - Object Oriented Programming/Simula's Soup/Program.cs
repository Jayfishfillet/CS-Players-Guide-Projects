Console.Title = "Simula's Soup";

(Food food, Ingredient ingredient, Seasoning seasoning) cookedDish = MealCombination();
Console.WriteLine($"You've chosen to make a {cookedDish.seasoning} {cookedDish.ingredient} {cookedDish.food}, tasty!");

(Food, Ingredient, Seasoning) MealCombination()
{
    Food foodChoice = GetFoodChoice();
    Ingredient ingredientChoice = GetIngredientChoice();
    Seasoning seasoningChoice = GetSeasoningChoice();

    return (foodChoice, ingredientChoice, seasoningChoice);


}

Food GetFoodChoice()
{
    while(true)
    {
        Console.WriteLine("What type of meal would you like? We have Soup, Stew, and Gumbo.");
        switch (Console.ReadLine().ToLower())
        {
            case "soup":
                return Food.soup;
            case "stew":
                return Food.stew;
            case "gumbo":
                return Food.gumbo;
            default:
                Console.WriteLine("We don't have that here.\n");
                break;
        }
    }
}
Ingredient GetIngredientChoice()
{
    while (true)
    {
        Console.WriteLine("What ingredient would you like? Mushrooms, Chicken, Carrots, and Potatoes.");
        switch (Console.ReadLine().ToLower())
        {
            case "mushrooms":
                return Ingredient.mushrooms;
            case "chicken":
                return Ingredient.chicken;
            case "carrots":
                return Ingredient.carrots;
            case "potatoes":
                return Ingredient.potatoes;
            default:
                Console.WriteLine("We don't have that here.\n");
                break;
        }
    }
}
Seasoning GetSeasoningChoice()
{
    while(true)
    {
        Console.WriteLine("What seasoning would you prefer? Spicy, Salty, or Sweet?");
        switch (Console.ReadLine().ToLower())
        {
            case "spicy":
                return Seasoning.spicy;
            case "salty":
                return Seasoning.salty;
            case "sweet":
                return Seasoning.sweet;
            default:
                Console.WriteLine("We don't have that here.\n");
                break;
        }
    }
}

enum Food {soup, stew, gumbo};
enum Ingredient {mushrooms, chicken, carrots, potatoes}
enum Seasoning {spicy, salty, sweet}