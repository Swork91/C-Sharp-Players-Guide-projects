// level 24
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

//method to run
//TicTacToe();
//Part1();
//Part2();
//Part3();
Part4();
//Part5();

//point
void Part1()
{
    Point testpoint = new(2, 3);
    Point testpoint2 = new(-4, 0);
    testpoint.DisplayPointToConole();
    testpoint2.DisplayPointToConole();
}

//color
void Part2()
{
    Color testcolor1 = new(1, 1, 1);
    Color testcolor2 = Color.Yellow();
    testcolor1.DisplayColorToConole();
    testcolor2.DisplayColorToConole();
}

//part 3 - create and dsiplay the whole 56 card deck
void Part3()
{
    int numberOfCardColors = Enum.GetNames(typeof(CardColors)).Length;
    int numberOfCardRanks = Enum.GetNames(typeof(CardRanks)).Length;
    for (int i = 0; i < numberOfCardColors; i++)
    {
        for (int j = 0; j < numberOfCardRanks; j++)
        {
            Card c = new Card((CardColors)i, (CardRanks)j);
            c.DisplayCard();
        }
    }
}

//part 4 door
void Part4()
{
    Console.WriteLine("Enter a starting passcode:");
    string? userInput = Console.ReadLine();
    Door d = new(DoorStates.open, Convert.ToInt32(userInput));
    Console.WriteLine($"The door is {d.State}. What do you do?");
    while (userInput != "exit")
    {
        userInput = Console.ReadLine();
        switch (userInput)
        {
            case "open":
                d.OpenDoor();
                Console.WriteLine($"You try to open the door. It is {d.State}:");
                break;
            case "close":
                d.CloseDoor();
                Console.WriteLine($"You try to close the door. It is {d.State}:");
                break;
            case "lock":
                d.LockDoor();
                Console.WriteLine($"You try to lock the door. It is {d.State}:");
                break;
            case "unlock":
                Console.WriteLine("Enter the code:");
                string? codeGuess = Console.ReadLine();
                if (isInt(codeGuess))
                {
                    d.UnlockDoor(Convert.ToInt32(codeGuess));
                }
                Console.WriteLine($"You try to unlock the door. It is {d.State}:");
                break;
            case "change":
                Console.WriteLine("Enter the old code:");
                string? oldCode = Console.ReadLine();
                Console.WriteLine("Enter the new code:");
                string? newCode = Console.ReadLine();
                if (isInt(oldCode) && isInt(newCode))
                {
                    d.ChangePasscode(Convert.ToInt32(oldCode), Convert.ToInt32(newCode));
                }
                if (d.Code == Convert.ToInt32(newCode)) Console.WriteLine("Code Changed.");
                break;
            default:
                Console.WriteLine("I don't understand.");
                //TODO: list options for switch.
                break;

        }

    }
}

//part 5 passwords validator
void Part5()
{
    while (true)
    {
        Console.WriteLine("Enter a password:");
        string? userInput = Console.ReadLine();
        PasswordValidator enteredPassword = new(userInput);
        if (enteredPassword.IsValid())
            Console.WriteLine("Password is valid");
        else
            Console.WriteLine("Password is invalid");
    }
}

//object oriented design part 1
void TicTacToe()
{
    GameBoard board = new GameBoard();
    int move = 0;
    string userInput;

    while (board.GameOver == false)
    {
        board.Display();
        userInput = Console.ReadLine();
        if (isInt(userInput)) //check if user is trying to break rules
        {
            move = Convert.ToInt32(userInput);
            if (board.ValidMove(move)) // check if user input is valid
            {
                board.SetBox(move);
            }
        }
        board.CheckVictory();
    }
    //gameover show board last state
    board.DisplayBoardOnly();
}
/* Just checks if the Convert will throw any errors 
 * @return boolean true false depending on errors
 */
bool isInt(string a)
{
    try
    {
        Convert.ToInt32(a);
    }
    catch (Exception e)
    {
        return false;
    }
    return true;
}

internal class Point
{
    public int Xcoord { get; init; }
    public int Ycoord { get; init; }
    public Point(int x, int y)
    {
        Xcoord = x;
        Ycoord = y;
    }
    public void DisplayPointToConole()
    {
        Console.WriteLine($"({Xcoord}, {Ycoord})");
    }
    public Point():this (0, 0) { }
}
internal class Color
{
    public byte RedValue { get; init; }
    public byte GreenValue { get; init; }
    public byte BlueValue { get; init; }
    public static Color White() => new(255, 255, 255);
    public static Color Black() => new(0, 0, 0);
    public static Color Red() => new(255, 0, 0);
    public static Color Orange() => new(255, 165, 0);
    public static Color Yellow() => new(255, 255, 0);
    public static Color Green() => new(0, 128, 0);
    public static Color Blue() => new(0, 0, 255);
    public static Color Purple() => new(128, 0, 128);
    public void DisplayColorToConole()
    {
        Console.WriteLine($"[{RedValue}, {GreenValue}, {BlueValue}]");
    }
    public Color(byte red, byte green, byte blue)
    {
        RedValue = red;
        GreenValue = green;
        BlueValue = blue;
    }
    public Color(): this (200, 200, 200) { }
}
internal class Card
{
    public CardColors Suite { get; init; }
    public CardRanks Value { get; init; }
    public Card(CardColors color, CardRanks rank)
    {
        Suite = color;
        Value = rank;
    }
    public bool IsCardANumberCard(Card card) => card.Value switch
    {
        CardRanks.one => true,
        CardRanks.two => true,
        CardRanks.three => true,
        CardRanks.four => true,
        CardRanks.five => true,
        CardRanks.six => true,
        CardRanks.seven => true,
        CardRanks.eight => true,
        CardRanks.nine => true,
        CardRanks.ten => true,
        CardRanks.dollar => false,
        CardRanks.percent => false,
        CardRanks.carrot => false,
        CardRanks.ampersand => false,
        _ => throw new ArgumentOutOfRangeException(nameof(card.Value), $"Not expected card value: {card.Value}"),
    };
    public void DisplayCard()
    {
        Console.WriteLine($"The {Suite} {Value}");
    }
}
internal class Door
{
    public DoorStates State { get; set; }
    public int Code { get; set; }
    public void OpenDoor()
    {
        if (State == DoorStates.closed) State = DoorStates.open;
    }
    public void CloseDoor()
    {
        if (State == DoorStates.open) State = DoorStates.closed;
    }
    public void LockDoor()
    {
        if (State == DoorStates.closed) State = DoorStates.locked;
    }
    public void UnlockDoor(int codeEntered)
    {
        if (State == DoorStates.locked && codeEntered == Code) State = DoorStates.closed;
    }
    public void ChangePasscode(int codeEntered, int newCode)
    {
        if (codeEntered == Code) Code = newCode;
    }
    public Door(DoorStates state, int code)
    {
        State = state;
        Code = code;
    }
}
internal class PasswordValidator
{
    private static readonly int _passwordMaxLength = 13;
    private static readonly int _passwordMinLength = 6;
    private static readonly int _passwordRequiredCapitals = 1;
    private int _numberOfCapitals = 0;
    private static readonly int _passwordRequiredLowercase = 1;
    private int _numberOfLowercase = 0;
    private static readonly int _passwordRequiredNumbers = 1;
    private int _numberOfNumbers = 0;
    public string? Password { get; set; }
    // 6-13 characters
    // one uppercase, one lowerase, and one number
    //passwords can not contrain a capital T or and ampersand (&).
    public bool IsValid()
    {
        if (Password.Length > _passwordMaxLength)
            return false;
        if (Password.Length < _passwordMinLength)
            return false;
        //count upper, lower and number
        //check for special characters.
        foreach (char letter in Password)
        {
            if (char.IsUpper(letter))
                _numberOfCapitals++;
            if (char.IsLower(letter))
                _numberOfLowercase++;
            if (char.IsNumber(letter))
                _numberOfNumbers++;
            if (letter == Convert.ToChar("T") || letter == Convert.ToChar("&"))
                return false;
        }
        if (_numberOfCapitals < _passwordRequiredCapitals || _numberOfLowercase < _passwordRequiredLowercase || _numberOfNumbers < _passwordRequiredNumbers)
            return false;
        return true;
    }
    public PasswordValidator(string p)
    {
        Password = p;
    }
}
internal class GameBoard
{
    public bool GameOver { get; set; }
    private char Piece { get { if (Turn % 2 == 0) return 'X'; else return 'O'; } set { } }
    private int Turn { get; set; }
    private char BoxOne { get; set; }
    private char BoxTwo { get; set; }
    private char BoxThree { get; set; }
    private char BoxFour { get; set; }
    private char BoxFive { get; set; }
    private char BoxSix { get; set; }
    private char BoxSeven { get; set; }
    private char BoxEight { get; set; }
    private char BoxNine { get; set; }
    public void Display()
    {
        Console.WriteLine($"It is {Piece}'s turn.");
        Console.WriteLine($" {BoxOne} | {BoxTwo} | {BoxThree} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {BoxFour} | {BoxFive} | {BoxSix} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {BoxSeven} | {BoxEight} | {BoxNine} ");
        Console.WriteLine("what square do you want?");
    }
    public void DisplayBoardOnly()
    {
        Console.WriteLine($" {BoxOne} | {BoxTwo} | {BoxThree} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {BoxFour} | {BoxFive} | {BoxSix} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {BoxSeven} | {BoxEight} | {BoxNine} ");
    }
    public bool ValidMove(int move)
    {
        //check if user entered an acutal square's value
        if (move < 1) return false;
        if (move > 9) return false;
        //check if empty square
        switch (move)
        {
            case 1:
                if (BoxOne.Equals(' ')) 
                {
                    return true;
                }
                break;
            case 2:
                if (BoxTwo.Equals(' '))
                {
                    return true;
                }
                break;
            case 3:
                if (BoxThree.Equals(' '))
                {
                    return true;
                }
                break;
            case 4:
                if (BoxFour.Equals(' '))
                {
                    return true;
                }
                break;
            case 5:
                if (BoxFive.Equals(' '))
                {
                    return true;
                }
                break;
            case 6:
                if (BoxSix.Equals(' '))
                {
                    return true;
                }
                break;
            case 7:
                if (BoxSeven.Equals(' '))
                {
                    return true;
                }
                break;
            case 8:
                if (BoxEight.Equals(' '))
                {
                    return true;
                }
                break;
            case 9:
                if (BoxNine.Equals(' '))
                {
                    return true;
                }
                break;
        }
        return false; //square already taken
    }
    public void SetBox(int m)
    {
        switch (m)
        {
            case 1:
                BoxOne = Piece; break;
            case 2:
                BoxTwo = Piece; break;
            case 3:
                BoxThree = Piece; break;
            case 4:
                BoxFour = Piece; break;
            case 5:
                BoxFive = Piece; break;
            case 6:
                BoxSix = Piece; break;
            case 7:
                BoxSeven = Piece; break;
            case 8:
                BoxEight = Piece; break;
            case 9:
                BoxNine = Piece; break;
        }
        Turn++;

    }
    internal void CheckVictory()
    {
        char x = 'X';
        char o = 'O';
        //horizontal
        if (BoxOne.Equals(x) && BoxTwo.Equals(x) && BoxThree.Equals(x))
        {
            Console.WriteLine($"{x} wins, gameover");
            GameOver = true;
        }
        else if (BoxOne.Equals(o) && BoxTwo.Equals(o) && BoxThree.Equals(o))
        {
            Console.WriteLine($"{o} wins, gameover");
            GameOver = true;
        }
        if (BoxFour.Equals(x) && BoxFive.Equals(x) && BoxSix.Equals(x))
        {
            Console.WriteLine($"{x} wins, gameover");
            GameOver = true;
        }
        else if (BoxFour.Equals(o) && BoxFive.Equals(o) && BoxSix.Equals(o))
        {
            Console.WriteLine($"{o} wins, gameover");
            GameOver = true;
        }
        if (BoxSeven.Equals(x) && BoxEight.Equals(x) && BoxNine.Equals(x))
        {
            Console.WriteLine($"{x} wins, gameover");
            GameOver = true;
        }
        else if (BoxSeven.Equals(o) && BoxEight.Equals(o) && BoxNine.Equals(o))
        {
            Console.WriteLine($"{o} wins, gameover");
            GameOver = true;
        }
        //vertical
        if (BoxOne.Equals(x) && BoxFour.Equals(x) && BoxSeven.Equals(x))
        {
            Console.WriteLine($"{x} wins, gameover");
            GameOver = true;
        }
        else if (BoxOne.Equals(o) && BoxFour.Equals(o) && BoxSeven.Equals(o))
        {
            Console.WriteLine($"{o} wins, gameover");
            GameOver = true;
        }
        if (BoxTwo.Equals(x) && BoxFive.Equals(x) && BoxEight.Equals(x))
        {
            Console.WriteLine($"{x} wins, gameover");
            GameOver = true;
        }
        else if (BoxTwo.Equals(o) && BoxFive.Equals(o) && BoxEight.Equals(o))
        {
            Console.WriteLine($"{o} wins, gameover");
            GameOver = true;
        }
        if (BoxThree.Equals(x) && BoxSix.Equals(x) && BoxNine.Equals(x))
        {
            Console.WriteLine($"{x} wins, gameover");
            GameOver = true;
        }
        else if (BoxThree.Equals(o) && BoxSix.Equals(o) && BoxNine.Equals(o))
        {
            Console.WriteLine($"{o} wins, gameover");
            GameOver = true;
        }
        //Diagonal
        if (BoxOne.Equals(x) && BoxFive.Equals(x) && BoxNine.Equals(x))
        {
            Console.WriteLine($"{x} wins, gameover");
            GameOver = true;
        }
        else if (BoxOne.Equals(o) && BoxFive.Equals(o) && BoxNine.Equals(o))
        {
            Console.WriteLine($"{o} wins, gameover");
            GameOver = true;
        }
        if (BoxThree.Equals(x) && BoxFive.Equals(x) && BoxSeven.Equals(x))
        {
            Console.WriteLine($"{x} wins, gameover");
            GameOver = true;
        }
        else if (BoxThree.Equals(o) && BoxFive.Equals(o) && BoxSeven.Equals(o))
        {
            Console.WriteLine($"{o} wins, gameover");
            GameOver = true;
        }
        //check if out of moves and draw
        if (Turn == 10)
        {
            Console.WriteLine("DRAW, gameover");
            GameOver = true;
        }
    }
    public GameBoard (char a, char b, char c, char d, char e, char f, char g, char h, char i)
    {
        Turn = 1;
        GameOver = false;
        BoxOne = a;
        BoxTwo = b;
        BoxThree = c;
        BoxFour = d;
        BoxFive = e;
        BoxSix = f;
        BoxSeven = g;
        BoxEight = h;
        BoxNine = i;
    }
    public GameBoard()
    {
        Turn = 1;
        GameOver = false;
        BoxOne = ' ';
        BoxTwo = ' ';
        BoxThree = ' ';
        BoxFour = ' ';
        BoxFive = ' ';
        BoxSix = ' ';
        BoxSeven = ' ';
        BoxEight = ' ';
        BoxNine = ' ';
    }
}
enum CardColors { red, green, blue, yellow }
enum CardRanks { one, two, three, four, five, six, seven, eight, nine, ten, dollar, percent, carrot, ampersand }
enum DoorStates { open, closed, locked }