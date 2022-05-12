Console.Title = "The Color";

Color firstColor = Color.Purple;
Color secondColor = new Color(12, 21, 36);

Console.WriteLine($"Purple = ({firstColor.R}, {firstColor.G}, {firstColor.B})");
Console.WriteLine($"Custom Color = ({secondColor.R}, {secondColor.G}, {secondColor.B})");

class Color
{
    public int R { get; }
    public int G { get; }
    public int B { get; }

    public static Color White  { get; } = new Color(255, 255, 255);
    public static Color Black  { get; } = new Color(0, 0, 0);
    public static Color Red    { get; } = new Color(255, 0, 0);
    public static Color Orange { get; } = new Color(255, 165, 0);
    public static Color Yellow { get; } = new Color(255, 255, 0);
    public static Color Green  { get; } = new Color(0, 128, 0);
    public static Color Blue   { get; } = new Color(0, 0, 255);
    public static Color Purple { get; } = new Color(128, 0, 128);

    public Color(int R, int G, int B)
    {
        this.R = R;
        this.G = G;
        this.B = B;
    }
}
