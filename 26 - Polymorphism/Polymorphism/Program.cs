/* Level 26 pt II - The Old Robot
 * Make OnCommand and OffCommand classes that inherit from RobotCommand and turn the robot on or off by overridding the Run method. 
 * Make a NorthCommand, SouthCommand, WestCommand, and EastCommand that move the robot...
 *  1 unit in the +Y direction, 1 unit in the -Y direction, 1 unit in the -X direction, and 1 unit in the the +X direction.
 *  Also ensure that these commands only work if the robot's IsPowered property is true.
 * Make your main method able to collect three commands from the console window. Generate new RobotCommand objects on the text enteted.
 *  After filling the robot's command set with these new RobotCommand objects, use the robot's Run method to execute them.
 *  Ex:
 *  on
 *  north
 *  west
 *  
 *  [0 0 True]
 *  [0 1 True]
 *  [-1 1 True]
 *  
 */

/* Level 27 - Robotic Interface
 * Change your abstract RobotCommand class into an IRobotCommand interface.
 * Remove the unnecessary public and abstract keywords from the RUn method.
 * Change the Robot class to use IRobotCommand instread of RobotCOmmand,
 * Make all of your commands implement this new interfave instead of extending the RobotCommand class that no longer exists. 
 *  You will also want to remove the override keywords in these classes.
 * Ensure your program still comiles and runs.
 * ANSWER: is this an improvement? why or not.
 */ 

Main();

void Main()
{
    Robot robot = new();
    OnCommand on = new();
    OffCommand off = new();
    NorthCommand north = new();
    SouthCommand south = new();
    WestCommand west = new();
    EastCommand east = new();
    int i = 0;

    Console.WriteLine("\nEnter an item to create and add or enter \"0\" for a list of options:");
    while (robot.Commands[2] == null)
    {
        string? userInput = Console.ReadLine();
        switch (userInput)
        {
            case "0":
                Console.WriteLine("Options are \"On\", \"Off\", \"North\", \"South\", \"West\", \"East\", and \"0\".");
                break;
            case "On":
                on.Run(robot);
                break;
            case "Off":
                off.Run(robot);
                break;
            case "North":
                robot.Commands[i] = north;
                i++;
                break;
            case "South":
                robot.Commands[i] = south;
                i++;
                break;
            case "West":
                robot.Commands[i] = west;
                i++;
                break;
            case "East":
                robot.Commands[i] = east;
                i++;
                break;
            default:
                Console.WriteLine("not a valid option.");
                break;
        }
    }
    // Commands full. Run it.
    robot.Run();
}

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public IRobotCommand?[] Commands { get; } = new IRobotCommand?[3];
    public void Run()
    {
        foreach (IRobotCommand? command in Commands) 
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public interface IRobotCommand
{
    public void Run(Robot robot);
}

public class OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y++;
        }
    }
}

public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y--;
        }
    }
}

public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X--;
        }
    }
}

public class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X++;
        }
    }
}