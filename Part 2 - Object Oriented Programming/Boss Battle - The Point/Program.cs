Console.Title = "The point";

Point originPoint = new Point();
Point firstPoint = new Point(2, 3);
Point secondPoint = new Point(-4, 0);

Console.WriteLine($"{firstPoint.xpos}, {firstPoint.ypos}");
Console.WriteLine($"{secondPoint.xpos},{secondPoint.ypos}");



class Point
{ 
    public int xpos { get;}
    public int ypos { get;}

    public Point()
    {
        this.xpos = 0;
        this.ypos = 0;
    }

    public Point(int xpos, int ypos)
    { 
        this.xpos = xpos;
        this.ypos = ypos;
    }
}