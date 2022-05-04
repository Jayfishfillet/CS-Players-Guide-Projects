Console.Title = "The Replicator of D'To";

int[] firstArray = new int[5];
int[] secondArray = new int[5];

Console.WriteLine("Let us populate the array with 5 values.");

for (int arrayIndex = 0; arrayIndex < firstArray.Length; arrayIndex++)
{
    Console.Write("Enter a number: ");
    firstArray[arrayIndex] = Convert.ToInt32(Console.ReadLine());
}

Console.WriteLine("\nCopying first Array into a new Array...");

for (int arrayIndex = 0; arrayIndex < secondArray.Length; arrayIndex++)
{
    secondArray[arrayIndex] = firstArray[arrayIndex];
}

Console.WriteLine($"\nArray 1: {firstArray[0]}, {firstArray[1]}, {firstArray[2]}, {firstArray[3]}, {firstArray[4]}");

Console.WriteLine($"\nArray 2: {secondArray[0]}, {secondArray[1]}, {secondArray[2]}, {secondArray[3]}, {secondArray[4]}");





