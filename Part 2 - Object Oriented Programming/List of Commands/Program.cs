Console.Title = "List of Commands";

Robot robot = new Robot();

Console.WriteLine($"Robot is Powered: {robot.IsPowered}\nAvailable commands: On, Off, North, South, East, West, Stop\nEnter as many commands as you'd like, then enter 'Stop' to run all of the commands:\n");

Commandloop();
robot.Run();

void Commandloop()
{
    while (true)
    {
        string choice = Console.ReadLine()!.ToLower();
        switch (choice)
        {
            case "on":
                robot.Commands.Add(new OnCommand());
                break;
            case "off":
                robot.Commands.Add(new OffCommand());
                break;
            case "north":
                robot.Commands.Add(new NorthCommand());
                break;
            case "south":
                robot.Commands.Add(new SouthCommand());
                break;
            case "east":
                robot.Commands.Add(new EastCommand());
                break;
            case "west":
                robot.Commands.Add(new WestCommand());
                break;
            case "stop":
                return;
            default:
                break;
        }
    }
}

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public List<RobotCommand> Commands { get; } = new List<RobotCommand>();
    public void Run()
    {
        foreach (RobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");

        }
    }
}

public abstract class RobotCommand
{
    public abstract void Run(Robot robot);
}

public class OnCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}
public class NorthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X++;
        }
    }
}

public class SouthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X--;
        }
    }
}

public class EastCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y++;
        }
    }
}
public class WestCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y--;
        }
    }
}