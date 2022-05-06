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
                break;
            case "stew":
                return Food.stew;
                break;
            case "gumbo":
                return Food.gumbo;
                break;
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
                break;
            case "chicken":
                return Ingredient.chicken;
                break;
            case "carrots":
                return Ingredient.carrots;
                break;
            case "potatoes":
                return Ingredient.potatoes;
                break;
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
                break;
            case "salty":
                return Seasoning.salty;
                break;
            case "sweet":
                return Seasoning.sweet;
                break;
            default:
                Console.WriteLine("We don't have that here.\n");
                break;
        }
    }
}

enum Food {soup, stew, gumbo};
enum Ingredient {mushrooms, chicken, carrots, potatoes}
enum Seasoning {spicy, salty, sweet}