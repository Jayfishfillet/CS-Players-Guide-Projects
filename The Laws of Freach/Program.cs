Console.Title = "The Laws of Freach";

int[] array = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };
int currentSmallest = int.MaxValue; // Start higher than anything in the array.

foreach (int number in array)
{
    if (number < currentSmallest)
    {
        currentSmallest = number;
    }

}
Console.WriteLine(currentSmallest);

int total = 0;
foreach (int number in array)
{
    total += number;
}

float average = (float)total / array.Length;
Console.WriteLine(average);