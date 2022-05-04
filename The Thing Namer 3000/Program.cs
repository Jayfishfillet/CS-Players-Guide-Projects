//Answer this question: Aside from comments, what else could you do to make this code more
//understandable?

//Answer: Space out the lines, use interpolation, combine string C and D


Console.WriteLine("What kind of thing are we talking about?");
string a = Console.ReadLine(); //Sets the name of the thing

Console.WriteLine("How would you describe it? Big? Azure? Tattered?");
string b = Console.ReadLine(); /* Sets a description of the thing*/

string c = "of Doom";
string d = "3000";
Console.WriteLine("The " + b + " " + a + " " + c + " " + d + "!");