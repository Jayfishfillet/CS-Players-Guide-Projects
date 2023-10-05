Console.Title = "Program-Making Program";

Func<string, string> getUnit = (u) => { Console.WriteLine($"Pick a {u}:"); return Console.ReadLine(); };
(string unit, String type) = (getUnit("measurement unit"), getUnit("type"));

string code = $$"""
Console.WriteLine("Enter the width (in {{unit}}) of the triangle: ");
{{type}} width = {{type}}.Parse(Console.ReadLine());
Console.WriteLine("Enter the height (in {{unit}}) of the triangle: ");
{{type}} height = {{type}}.Parse(Console.ReadLine());
{{type}} result = width * height / 2;
Console.WriteLine($"{result} square {unit}"); 
""";

Console.WriteLine(code);