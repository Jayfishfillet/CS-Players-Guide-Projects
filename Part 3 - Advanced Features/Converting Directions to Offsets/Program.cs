Console.Title = "Converting Directions to Offsets";

Console.WriteLine(new BlockCoordinate(1, 1) + new BlockOffset(2, 0));
Console.WriteLine(new BlockCoordinate(0, 1) + Direction.North);

BlockCoordinate newBlockCoord = new BlockCoordinate(9, 10);
Console.WriteLine($"{newBlockCoord[0]}, {newBlockCoord[1]}");

Console.Write(Direction.North + ": ");
Console.WriteLine((BlockOffset)Direction.North);

public record BlockCoordinate(int Row, int Column)
{
    public int this[int index]
    {
        get
        {
            return index == 0 ? Row : Column;
        }
    }
    public static BlockCoordinate operator +(BlockCoordinate a, BlockOffset b) => new BlockCoordinate(a.Row + b.RowOffset, a.Column + b.ColumnOffset);
    public static BlockCoordinate operator +(BlockCoordinate a, Direction b)
    {
        return new BlockCoordinate(a + (b switch
        {
            Direction.North => new BlockOffset(-1, 0),
            Direction.South => new BlockOffset(+1, 0),
            Direction.West => new BlockOffset(0, -1),
            Direction.East => new BlockOffset(0, +1),
        }));
    }
}
public record BlockOffset(int RowOffset, int ColumnOffset)
{
    public static implicit operator BlockOffset(Direction d) => d switch
    {
        Direction.North => new BlockOffset(-1, 0),
        Direction.South => new BlockOffset(+1, 0),
        Direction.West => new BlockOffset(0, -1),
        Direction.East => new BlockOffset(0, +1),
    };
};
public enum Direction { North, East, South, West }