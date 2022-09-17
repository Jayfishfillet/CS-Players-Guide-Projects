Console.Title = "Room Coordinates";

Coordinate room1 = new Coordinate(1, 1);
Coordinate room2 = new Coordinate(2, 2);
Coordinate room3 = new Coordinate(2, 3);

Console.WriteLine($"room1 is adjacent to room2: {room1.IsAdjacentTo(room2)}"); //should resolve to FALSE
Console.WriteLine($"room2 is adjacent to room3: {room2.IsAdjacentTo(room3)}"); //should resolve to TRUE
Console.WriteLine($"room3 is adjacent to room1: {room3.IsAdjacentTo(room1)}"); //should resolve to FALSE

struct Coordinate
{
    int Row { get; init; }
    int Column { get; init; }

    public Coordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public bool IsAdjacentTo(Coordinate room)
    {
        bool isAdjacent = false;
        bool isAdjacentOnRow = this.Row == room.Row && (this.Column -1 == room.Column || this.Column +1 == room.Column);
        bool isAdjacentOnColumn = this.Column == room.Column && (this.Row - 1 == room.Row || this.Row + 1 == room.Row);

        if (isAdjacentOnRow || isAdjacentOnColumn) isAdjacent = true;
        return isAdjacent;
    }
}