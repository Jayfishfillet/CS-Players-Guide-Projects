Console.Title = "Room Coordinates";

Coordinate room1 = new Coordinate(1, 2);
Coordinate room2 = new Coordinate(2, 3);
Coordinate room3 = new Coordinate(3, 4);


Console.WriteLine($"room1 is adjacent to room2: {room1.isAdjecent(room2)}");
Console.WriteLine($"room2 is adjacent to room3: {room2.isAdjecent(room3)}");
Console.WriteLine($"room3 is adjacent to room1: {room3.isAdjecent(room1)}");



struct Coordinate
{
    int Row { get; init; }
    int Column { get; init; }

    public Coordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public bool isAdjecent(Coordinate room)
    {
        bool isAdjecent;

        isAdjecent = this.Row + 1 == room.Row  || this.Row - 1 == room.Row ? true : false;
        isAdjecent = this.Column + 1 == room.Column || this.Column - 1 == room.Column ? true : false;

        return isAdjecent;
    }
}