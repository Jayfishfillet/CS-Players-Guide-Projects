Console.Title = "The Color";

Color firstColor = Color.Purple;
Color secondColor = new Color(12, 21, 36);

class Color
{
    public int R { get; }
    public int G { get; }
    public int B { get; }

    public static Color White = new Color(255, 255, 255);
    public static Color Black = new Color(0, 0, 0);
    public static Color Red = new Color(255, 0, 0);
    public static Color Orange = new Color(255, 165, 0);
    public static Color Yellow = new Color(255, 255, 0);
    public static Color Green = new Color(0, 128, 0);
    public static Color Blue = new Color(0, 0, 255);
    public static Color Purple = new Color(128, 0, 128);


    public Color(int R, int G, int B)
    {
        this.R = R;
        this.G = G;
        this.B = B;
    }



}