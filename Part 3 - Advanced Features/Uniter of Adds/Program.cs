Console.Title = "Uniter of Adds";

Console.WriteLine(DynamicAdd(1, 2));
Console.WriteLine(DynamicAdd(1.1, 2.2));
Console.WriteLine(DynamicAdd("Hello ", "World"));
Console.WriteLine(DynamicAdd(DateTime.Now, TimeSpan.FromHours(3)));

dynamic DynamicAdd(dynamic a, dynamic b) => a + b;
