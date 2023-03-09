Console.Title = "The Three Lenses";

int[] givenArray = new[] { 1, 9, 2, 8, 3, 7, 4, 6, 5 };

foreach (int i in Procedural(givenArray))
{
    Console.Write(i + " ");
}
Console.WriteLine();
foreach (int i in Keyword(givenArray))
{
    Console.Write(i + " ");
}
Console.WriteLine();
foreach (int i in MethodCall(givenArray))
{
    Console.Write(i + " ");
}


IEnumerable<int> Procedural(int[] array)
{
    List<int> filtered = new List<int>();
    //filter it
    foreach (int i in array)
    {
        if (i % 2 == 0)
        { 
            filtered.Add(i);
        }
    }

    //Order it
    int[] ordered = filtered.ToArray();
    Array.Sort(ordered);

    //double it
    for(int i = 0; i < ordered.Length; i++)
    { 
        ordered[i] *= 2;
    }

    return ordered;

}

IEnumerable<int> Keyword(int[] array)
{
    return from number in array where number % 2 == 0 orderby number select number * 2;
}

IEnumerable<int> MethodCall(int[] input)
{
    return input.Where(n => n % 2 == 0).OrderBy(n => n).Select(n => n * 2);
}