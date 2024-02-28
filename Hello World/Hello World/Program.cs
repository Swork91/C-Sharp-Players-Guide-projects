/* Level 7 GAMER
* We're level 11 now, fuckers
* lets fuck this boss
 */

huntTheManticore();

void areaOfTriangle()
{
    while (true)
    {
        Console.WriteLine("Enter a height: ");
        var height = Console.ReadLine();
        Console.WriteLine("Enter a length: ");
        var width = Console.ReadLine();
        var area = Convert.ToDecimal(height) * Convert.ToDecimal(width) / 2;
        Console.WriteLine("area is: " + area + "\n");
    }
}
void chocolateFarm()
{
    var numberOfSisters = 4;
    while (true)
    {
        Console.WriteLine("Enter number of egg");
        var numberOfEggs = Console.ReadLine();
        var remainingEggs = Convert.ToInt32(numberOfEggs) % numberOfSisters;
        Console.WriteLine((Convert.ToInt32(numberOfEggs) / numberOfSisters) + " each with " + remainingEggs + " eggs remaining");
    }
}
void kingdomScore()
{
    while (true)
    {
        var estateScore = 1;
        var dutchyScore = 3;
        var provinceScore = 6;

        Console.WriteLine("Enter number of estates: ");
        var numberOfEstates = Console.ReadLine();
        Console.WriteLine("Enter number of dutchies: ");
        var numberOfDutchies = Console.ReadLine();
        Console.WriteLine("Enter number of provinces: ");
        var numberOfProvinces = Console.ReadLine();

        //var totalScore = estateScore * Convert.ToInt32(numberOfEstates) + dutchyScore * Convert.ToInt32(numberOfDutchies) + provinceScore * Convert.ToInt32(numberOfProvinces);
        estateScore *= Convert.ToInt32(numberOfEstates);
        dutchyScore *= Convert.ToInt32(numberOfDutchies);
        provinceScore *= Convert.ToInt32(numberOfProvinces);
        var totalScore = estateScore +  dutchyScore + provinceScore;

        Console.WriteLine("Your score is " + totalScore + "!");

    }
}
//Console app to move 
void consolas()
{
    Console.Title = "some title";
    while (true)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("Target Row? ");
        byte attackRow = Convert.ToByte(Console.ReadLine());
        Console.Write("Target Column? ");
        byte attackColumn = Convert.ToByte(Console.ReadLine());
        Console.WriteLine("Deploy to:");
        Console.ForegroundColor= ConsoleColor.Green;
        //top
        Console.WriteLine($"({attackRow},{attackColumn + 1})");
        //left
        Console.WriteLine($"({attackRow - 1},{attackColumn})");
        //right
        Console.WriteLine($"({attackRow + 1},{attackColumn})");
        //bottom
        Console.WriteLine($"({attackRow},{attackColumn - 1})");
        // no thanks beep
        //Console.Beep(500, 500);    
    }
}
void theWorstClock()
{
    while (false)
    {
        int input = Convert.ToInt32(Console.ReadLine());
        if ((input % 2) == 0) Console.WriteLine("tick");
        else Console.WriteLine("tock");
    }

    //version 2
    // all one line so it must be better.
    while (true)
    {
        Console.WriteLine((Convert.ToInt32(Console.ReadLine()) % 2) == 0 ? "tick" : "tock");
    }
}
void watchTower()
{
    while(true)
    {
        String direction = "";

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Enter an 'x' Value: ");
        int x = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter an 'y' Value: ");
        int y = Convert.ToInt32(Console.ReadLine());

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("attack at: (" + x + "," + y + ")");

        if (x == 0 && y == 0) direction = "inside";
        else
        {
            if (y > 0)
            {
                direction += "North ";
            }
            else if (y < 0)
            {
                direction += "South ";
            }

            if (x > 0)
            {
                direction += "East";
            }
            else if (x < 0)
            {
                direction += "West";
            }
        }


        Console.WriteLine($"attackers to the {direction}");
    }
}
void watchTower2()
{
    while (true)
    {
        String direction = "";

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Enter an 'x' Value: ");
        int x = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter an 'y' Value: ");
        int y = Convert.ToInt32(Console.ReadLine());

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("attack at: (" + x + "," + y + ")");

        if (x == 0 && y == 0) direction = "inside";
        else if (x == 0)
        {
            //directly to the north/south
            direction += (y > 0) ? "North " : "South ";
        }
        else if (y == 0)
        {
            //direclty east/west
            direction += (x > 0) ? "East" : "West";
        }
        else
        {
            direction += (y > 0) ? "North " : "South ";
            direction += (x > 0) ? "East" : "West";
        }
        Console.WriteLine($"attackers to the {direction}\n");
    }
}
void buyingInventory()
{
    while (true)
    {
        // could put this on one line, but i wont
        Console.WriteLine("\nThe following items are available: ");
        Console.WriteLine("1 - Rope");
        Console.WriteLine("2 - Torches");
        Console.WriteLine("3 - Climbing Equipment");
        Console.WriteLine("4 - Clean Water");
        Console.WriteLine("5 - Machete");
        Console.WriteLine("6 - Canoe");
        Console.WriteLine("7 - Food Supplies");
        Console.WriteLine("what you want: ");

        var userInput = Console.ReadLine();
        switch (Convert.ToInt32(userInput))
        {
            case 1: 
                Console.WriteLine("That is 10 gold");
                break;
            case 2:
                Console.WriteLine("That is 15 gold");
                break;
            case 3:
                Console.WriteLine("That is 25 gold");
                break;
            case 4:
            case 7:
                Console.WriteLine("That is 1 gold");
                break;
            case 5:
                Console.WriteLine("That is 20 gold");
                break;
            case 6:
                Console.WriteLine("That is 200 gold");
                break;
            default:
                Console.WriteLine("this does nothing.");
                break;

        }
    }
}
void buyingInventory2()
{
    while (true)
    {   
        // could put this on one line, but i wont
        Console.WriteLine("\nThe following items are available: ");
        Console.WriteLine("1 - Rope");
        Console.WriteLine("2 - Torches");
        Console.WriteLine("3 - Climbing Equipment");
        Console.WriteLine("4 - Clean Water");
        Console.WriteLine("5 - Machete");
        Console.WriteLine("6 - Canoe");
        Console.WriteLine("7 - Food Supplies");

        Console.WriteLine("what is yer name: ");
        var userName = Console.ReadLine();

        Console.WriteLine("what you want: ");
        var userInput = Console.ReadLine();

        var price = Convert.ToInt32(userInput) switch
        {
            1 => 10,
            2 => 15,
            3 => 25,
            4 => 1,
            5 => 20,
            6 => 200,
            7 => 1,
            _ => 0
        };

        var discount = (userName == "sam") ? 0.5 : 1;
        Console.WriteLine($"That is {price * discount} gold");
    }
}
    ///input rounds number outputs damage from the cannon
int magicCannon(int round)
{
    var blast = 1;
        if (round % 3 == 0)
        {
            blast = 3;
            if ((round % 5) == 0)
            {
                blast = 10;
            }
        }
        else if ((round % 5) == 0)
        {
            blast = 3;
        }
        return blast;
}
void replicator()
{
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.Title = "fuck machine";
    //create array of length 5
    int arraySize = 5;
    int[] arrayToCopy = new int[arraySize];

    //ask user for inputs for array.
    for (int i = 0; i < arraySize; i++)
    {
        Console.Write("Enter an int32:  ");
        arrayToCopy[i] = Convert.ToInt32(Console.ReadLine());
    }

    //make a second array of lenght 5 
    int[] arrayCopied = new int[arraySize];

    //copy arr1 values to arr2
    for (int i = 0; i < arraySize; i++)
    {
        arrayCopied[i] = arrayToCopy[i];
    }

    //dsiplay both contents one at at time.
    Console.WriteLine("first array:  ");
    for (int i = 0; i < arraySize; i++)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(arrayToCopy[i] + " ");
    }

    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine("\ncopied array: ");
    for (int i = 0; i < arraySize; i++)
    {
        Console.ForegroundColor = ConsoleColor.Red;

        Console.Write(arrayCopied[i] + " ");
    }
    Console.ForegroundColor = ConsoleColor.Gray;
}
void freach()
{
    //start with for code that computes array's minimum and average values
    //modify it to use foreach instead.
    int[] array = new int[] { 4, 51, -7, 13, -99, 15, -8,  45, 90};

    int currentSmallest = int.MaxValue; // start with higer than anythign in array
    /*for (int index = 0; index < array.Length;index++)
    {
        if (array[index] < currentSmallest)
            currentSmallest = array[index];
    }*/
    foreach (int i in array)
        if (i < currentSmallest)
            currentSmallest = i;
    Console.WriteLine("smallest: " + currentSmallest);

    int total = 0;
    /*for (int index = 0; index < array.Length; index++)
    {
        total += array[index];
    }*/
    foreach (int index in array)
        total += index;

    float average = (float)total / (float)array.Length;
    Console.WriteLine("average: " + average);
}
int askForNumber(string text) 
{
    Console.WriteLine(text);
    return Convert.ToInt32(text);
}
int askForNumberInRange(string text, int min, int max)
{
    if (min <= Convert.ToInt32(text) && Convert.ToInt32(text) <= max)
        return Convert.ToInt32(text);
    return -1;
}
void noLoopCountdown(int n)
{
    Console.WriteLine(n);
    if (n > 0)
        noLoopCountdown(n - 1);
}

void huntTheManticore()
{
    int round = 1;
    int cityHP = 15;
    int manticoreHP = 10;
    int damage = 1;
    int fireBlastTurn = 3;
    int electricBlastTurn = 5;

    //player 1 enters the range 1-100
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Player 1, how far away from the city do you want to station the Manticore? ");
    int manticorePosition = Convert.ToInt32(Console.ReadLine());
    Console.Clear();

    //player 2 display stats and enter a guess 1-100
    Console.WriteLine("Player 2. it is your turn.");
    while (cityHP > 0 && manticoreHP > 0)
    {
        damage = magicCannon(round);
        int guess = askForNumberInRange(displayStats(round, cityHP, manticoreHP, damage), 1, 100);
        Math.Clamp(guess, 1, 100);

        //provide player 2 feedback on too far/too shallow or direct hit
        if (guess > manticorePosition)
        {
            //too far
            Console.WriteLine("That round OVERSHOT the target.");
        }
        else if (guess < manticorePosition)
        {
            //too shallow
            Console.WriteLine("That round FELL SHORT of the target.");
        }
        else if (guess == manticorePosition)
        {
            //hit
            Console.WriteLine("That round was a DIRECT HIT!");
            manticoreHP -= damage;
        }
        else
            //error
            Console.WriteLine("error");

        //progress round after player action and respsonse.
        round++;

        //resolve manticore attack
        if (manticoreHP > 0)
            cityHP--;
    }

    //game over. resolve victory or defeat
    if (cityHP == 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("the city is fucked");
    }
    else
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("the manticore is destroyed.");

}

string displayStats(int round, int city, int manticore, int damage)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("--------------------------------------------------------------------------");
    Console.WriteLine($"STATUS: Round: {round} City: {city}/15 Manticore: {manticore}/10");
    Console.WriteLine($"The cannon is expected to deal {damage} damge this round.");
    Console.WriteLine("Enter the desired cannon range: ");
    Console.ForegroundColor = ConsoleColor.Gray;
    return Console.ReadLine();
}