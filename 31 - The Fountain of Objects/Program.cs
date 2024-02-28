/* The Fountain of Objects
 * 
 * The world consists of a grid of rooms, where each room can be referenced by its row and column. 
 *  North is up, East is right, South is down, and West is left:
 *   e |   | F |    0
 *  ---+---+---+---
 *     | p |   |    1
 *  ---+---+---+---
 *     |   |   |    2
 *  ---+---+---+---
 *     |   |   |    3   (rows)
 *   0   1   2   3      (columns)
 * The game's flow works like this: The player is told what they can sense in the dark (see, hear, smell).
 *  Then the player gets a chance to perform some action by typing it in. 
 *  Their chosen action is resolved (the player moves, state of things in the game changes, checking for a win or a loss, etc.)
 *  Then the loop repeats.
 * Most rooms are empty rooms, and there is nothing to sense.
 * The player is in one of the rooms and can move between them by typing commands like the following: "move north", "move south", "move east", and "move west".
 *  The player should not be able to move past the end of the map.
 * The room at (Row = 0, Column = 0) is the cavern enterance and exit.The player should start here. The player can sesne light comming from the exit.
 *  "You can see light in this room. This is the cavern enterance."
 * The room at  (Row = 0, Column = 2) is the fountain room, containing the Fountain of Objects itself. 
 *  The fountain can be either enabled or disabled. The player can hear the fountain but hears different things depending on if it is on or not. 
 *  ("You hear the rushing waters from the Fountain of Objects. It has been reactivated!") The fountain is off initially. 
 *  In the fountain room, the player can type "enable fountain" to enable it. 
 *  If the player is not in the fountain room and runs this, there should be no effect, and the player should be told so.
 * The player wins by moving to the fountain room, enabling the Fountain of Objects, and moving back to the cavern enterance. 
 *  If the player is in the enterance and the fountain is on, the player wins.
 * Use different colors to display the different types of text in the console window.
 *  For example narrative items (intro, ending, ect.) may be magenta, desciptive text in white, 
 *  input from the user in cyan, text describing enterance light in yellow, messages about the fountain in blue. 
 *  
 *  Complete 2 of the bonus challenges as well, more if you are feeling it.
 *  
 * ------------------------------------------------------------------------------------------------------------------
 * Small Medium Large
 *  Small = 4x4 
 *  Medium = 6x6
 *  Large = 8x8
 * ------------------------------------------------------------------------------------------------------------------ 
 * Pits
 * Add a pit to your 4x4 cavern. 2 pits to your 6x6 and 4 pits to your 8x8 cavern.
 * Players can sense the draft blowing from all eight surrounding rooms.
 *  "You feel a draft. There is a pit in the nearby room."
 * If a player ends their turn in a room with a pit they DIE.
 * ------------------------------------------------------------------------------------------------------------------
 * Maelstoms
 * Add a mealstrom (1 to small and medium, 2 into the large map)
 * The player can sense maelstrom by hearing them in adjacent rooms
 *  "You hear the growling and groaning of a maelstrom nearby."
 * If a player enters a room with a maelstrom the player moves one space north and two spaces east. 
 *  The maelstrom moves one space south and two spaces west.
 *  When the player is moved tell them so
 *  If this moves the player or the maelstrom outside the maps edge clamp them to the edge of the map or wrap them around.
 *  
 */

Main();

void Main()
{
    string UserInput;
    bool victory = false;
    bool fountainEnabled = false;
    Player player = new(0, 0);

    // query player for map size.
    (int, int) DungeonSize = PromptMapSize();
    
    // Build Empty Dungeon
    Room[,] Dungeon = new Room[DungeonSize.Item1, DungeonSize.Item2];
    for (int i = 0; i < DungeonSize.Item1; i++)
    {
        for (int j = 0; j < DungeonSize.Item2; j++)
        {
            Dungeon[i, j] = Room.Empty;
        }
    }

    // place game pieces
    Dungeon[0, 0] = Room.Enterance;
    Dungeon[0, 2] = Room.Fountain;
    
    // pits for small medium and large maps
    // TODO: why 2-4 pit definitions?
    if (DungeonSize.Item1 == 4)
    {
        Dungeon[1, 1] = Room.Pit;
    }
    if (DungeonSize.Item1 == 6)
    {
        Dungeon[1, 1] = Room.Pit;
        Dungeon[4, 5] = Room.Pit;

    }
    if (DungeonSize.Item1 == 8)
    {
        Dungeon[1, 1] = Room.Pit;
        Dungeon[4, 4] = Room.Pit; 
        Dungeon[5, 2] = Room.Pit;
        Dungeon[7, 7] = Room.Pit;
    }

    // main game loop
    while (!victory)
    {
        // mandatory location information
        Console.WriteLine("---------------------------------------------------\n" +
                          "You are in the room at (Row = {0}, Column = {1}).", player.Row, player.Column);

        //The game's flow works like this: The player is told what they can sense in the dark (see, hear, smell).
        if (Dungeon[player.Row, player.Column].Equals(Room.Enterance))
        {
            //do enterance stuff
            ColoredConsole.WriteLine(ConsoleColor.Yellow, "You see light comming from the cavern enterance.");
        }
        if (Dungeon[player.Row, player.Column].Equals(Room.Fountain))
        {
            // do fountain stuff
            if (fountainEnabled)
            {
                ColoredConsole.WriteLine(ConsoleColor.Blue, "You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
            }
            else
            {
                ColoredConsole.WriteLine(ConsoleColor.Blue, "You hear water dripping in this room. The Fountain of Objects is here!");
            }
        }
        if (CheckForPits(Dungeon, player, Room.Pit))
        {
            // check for nearby pit
            ColoredConsole.WriteLine(ConsoleColor.Red, "You feel a draft. There is a pit in the nearby room.");
        }

        //player dies to pit
        if (Dungeon[player.Row, player.Column].Equals(Room.Pit))
        {
            victory = true;
            ColoredConsole.WriteLine(ConsoleColor.Red, "You fall into a pit and die. Game Over.");
            break;
        }

        //Then the player gets a chance to perform some action by typing it in. 
        Console.WriteLine("What do you want to do?");
        UserInput = ColoredConsole.ColoredInput(ConsoleColor.Cyan);
        //Their chosen action is resolved(the player moves, state of things in the game changes, 
        switch (UserInput)
        {
            case ("move north"):
                player.MoveNorth(Dungeon);
                break;
            case ("move east"):
                player.MoveEast(Dungeon);
                break;
            case ("move south"):
                player.MoveSouth(Dungeon);
                break;
            case ("move west"):
                player.MoveWest(Dungeon);
                break;
            case ("enable fountain"):
                if (fountainEnabled)
                    Console.WriteLine("The fountain is already enabled.");
                if (Dungeon[player.Row, player.Column].Equals(Room.Fountain))
                {
                    fountainEnabled = true;
                }
                else
                {
                    Console.WriteLine("You can't do that here!");
                }
                break;
            default:
                Console.WriteLine("Invalid input.");
                break;
        }

        // checking for a win or a loss, etc.
        if (Dungeon[player.Row, player.Column].Equals(Room.Enterance) && fountainEnabled)
        {
            ColoredConsole.WriteLine(ConsoleColor.Magenta, "The Fountain of Objects has been reactiated, and you have escaped with your life! You win!");
            victory = true; // game over
        }
    }//Then the loop repeats.
}

bool CheckForPits(Room[,] Dungeon, Player player, Room pit)
{
    // TODO: I hate that this was the best I could come up with. Maybe change the dungeon to a 3d array and place NearPit objects in a layer instead.
    var Northbound = false;
    var EastBound = false;
    var SouthBound = false;
    var WestBound = false;
    var NearbyPit = false;

    if (player.Row == 0)
        Northbound = true;
    if (player.Column == Dungeon.GetLength(1) - 1)
        EastBound = true;
    if (player.Row == Dungeon.GetLength(0) - 1)
        SouthBound = true;
    if (player.Column == 0)
        WestBound = true;
    if (!Northbound && !EastBound && !SouthBound && !WestBound)
    {
        //check all eight positions.
        if (Dungeon[player.Row - 1, player.Column - 1].Equals(pit) ||   // in a 3x3 perimiter this is top left
            Dungeon[player.Row - 1, player.Column].Equals(pit) ||       // top middle
            Dungeon[player.Row - 1, player.Column + 1].Equals(pit) ||   // top right
            Dungeon[player.Row, player.Column - 1].Equals(pit) ||       // middle left
            Dungeon[player.Row, player.Column + 1].Equals(pit) ||       // middle right
            Dungeon[player.Row + 1, player.Column - 1].Equals(pit) ||   // bottom left
            Dungeon[player.Row + 1, player.Column].Equals(pit) ||       // bottom middle
            Dungeon[player.Row + 1, player.Column + 1].Equals(pit))     // bottom right
        {
            NearbyPit = true;
        }
    }
    if (Northbound && !EastBound && !SouthBound && !WestBound)
    {
        //check bottom 5 positions.
        if (Dungeon[player.Row, player.Column - 1].Equals(pit) ||       // middle left
            Dungeon[player.Row, player.Column + 1].Equals(pit) ||       // middle right
            Dungeon[player.Row + 1, player.Column - 1].Equals(pit) ||   // bottom left
            Dungeon[player.Row + 1, player.Column].Equals(pit) ||       // bottom middle
            Dungeon[player.Row + 1, player.Column + 1].Equals(pit))     // bottom right
        {
            NearbyPit = true;
        }
    }
    if (Northbound && EastBound && !SouthBound && !WestBound)
    {
        //Check bottom left 3 positions.
        if (Dungeon[player.Row, player.Column - 1].Equals(pit) ||       // middle left
            Dungeon[player.Row + 1, player.Column - 1].Equals(pit) ||   // bottom left
            Dungeon[player.Row + 1, player.Column].Equals(pit))         // bottom middle
        {
            NearbyPit = true;
        }
    }
    if (!Northbound && EastBound && !SouthBound && !WestBound)
    {
        // check left 5 positions.
        if (Dungeon[player.Row - 1, player.Column - 1].Equals(pit) ||   // in a 3x3 perimiter this is top left
           Dungeon[player.Row - 1, player.Column].Equals(pit) ||       // top middle
           Dungeon[player.Row, player.Column - 1].Equals(pit) ||       // middle left
           Dungeon[player.Row + 1, player.Column - 1].Equals(pit) ||   // bottom left
           Dungeon[player.Row + 1, player.Column].Equals(pit))          // bottom middle
        {
            NearbyPit = true;
        }
    }
    if (!Northbound && EastBound && SouthBound && !WestBound)
    {
        //check top left 3 positions
        if (Dungeon[player.Row - 1, player.Column - 1].Equals(pit) ||   // in a 3x3 perimiter this is top left
            Dungeon[player.Row - 1, player.Column].Equals(pit) ||       // top middle
            Dungeon[player.Row, player.Column - 1].Equals(pit))         // middle left
        {
            NearbyPit = true;
        }
    }
    if (!Northbound && !EastBound && SouthBound && !WestBound)
    {
        // check top 5 positions.
        if (Dungeon[player.Row - 1, player.Column - 1].Equals(pit) ||   // in a 3x3 perimiter this is top left
            Dungeon[player.Row - 1, player.Column].Equals(pit) ||       // top middle
            Dungeon[player.Row - 1, player.Column + 1].Equals(pit) ||   // top right
            Dungeon[player.Row, player.Column - 1].Equals(pit) ||       // middle left
            Dungeon[player.Row, player.Column + 1].Equals(pit))          // middle right
        {
            NearbyPit = true;
        }
    }
    if (!Northbound && !EastBound && SouthBound && WestBound)
    {
        // check top right 3 positions.
        if (Dungeon[player.Row - 1, player.Column].Equals(pit) ||       // top middle
            Dungeon[player.Row - 1, player.Column + 1].Equals(pit) ||   // top right
            Dungeon[player.Row, player.Column + 1].Equals(pit))         // middle right
        {
            NearbyPit = true;
        }
    }
    if (!Northbound && !EastBound && !SouthBound && WestBound)
    {
        // check right 5 positions.
        if (Dungeon[player.Row - 1, player.Column].Equals(pit) ||       // top middle
            Dungeon[player.Row - 1, player.Column + 1].Equals(pit) ||   // top right
            Dungeon[player.Row, player.Column + 1].Equals(pit) ||       // middle right
            Dungeon[player.Row + 1, player.Column].Equals(pit) ||       // bottom middle
            Dungeon[player.Row + 1, player.Column + 1].Equals(pit))     // bottom right
        {
            NearbyPit = true;
        }
    }
    if (Northbound && !EastBound && !SouthBound && WestBound)
    {
        // check bottom right 3 positions.
        if (Dungeon[player.Row, player.Column + 1].Equals(pit) ||       // middle right
            Dungeon[player.Row + 1, player.Column].Equals(pit) ||       // bottom middle
            Dungeon[player.Row + 1, player.Column + 1].Equals(pit))     // bottom right
        {
            NearbyPit = true;
        }
    }
    return NearbyPit;
}
// returns tuple for (row, col) dungeon size.
(int, int) PromptMapSize()
{
    while (true)
    {
        ColoredConsole.WriteLine(ConsoleColor.Magenta, "Select a map size; small, medium, or large:");
        string input = ColoredConsole.ColoredInput(ConsoleColor.Cyan);

        switch (input)
        {
            case ("small"):
                return (4, 4);
            case ("medium"):
                return (6, 6);
            case ("large"):
                return (8, 8);
            default:
                Console.WriteLine("Invalid input.");
                break;
        }
    }
}
public static class ColoredConsole
{
    public static void WriteLine(ConsoleColor color, string message)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    public static string ColoredInput(ConsoleColor color)
    {
        string s = "";
        Console.ForegroundColor = color;
        s = Console.ReadLine();
        Console.ResetColor();
        return s;
    }
}
// should indicate where the player is
public class Player
{
    public int Row { get; set; }
    public int Column { get; set; }
    //player spawn location
    public Player(int row, int col)
    {
        Row = row;
        Column = col;
    }
    public void MoveNorth(Room[,] dungeon)
    {
        if (this.Row <= 0)
        {
            bonk();
        }
        else
        {
            this.Row--;
        }
    }
    public void MoveEast(Room[,] dungeon)
    {
        if (this.Column >= dungeon.GetLength(1) - 1)
        {
            bonk();
        }
        else
        {
            this.Column++;
        }
    }
    public void MoveSouth(Room[,] dungeon)
    {
        if (this.Row >= dungeon.GetLength(0) - 1)
        {
            bonk();
        }
        else
        {
            this.Row++;
        }
    }
    public void MoveWest(Room[,] dungeon)
    {
        if (this.Column <= 0)
        {
            bonk();
        }
        else
        {
            this.Column--;
        }
    }
    void bonk()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You bonk into a wall like an idiot.");
        Console.ResetColor();
    }
}
public enum Room { Empty, Enterance, Fountain, Pit }