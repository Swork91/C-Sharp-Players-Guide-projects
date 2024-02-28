/* Book part 2 
 * 
 */

//we looping this main
while (true)
{
    arrowSelling();
}

//level 16 
void boxing()
{
    //define this enum box as locked
    boxState lockbox = boxState.Locked;

    //play with box FOREVER
    while(lockbox != boxState.Open)
    {
        lockbox = userInput(lockbox);
    }
    Console.WriteLine("you opened the box!");

}
boxState userInput(boxState state)
{
    Console.WriteLine($"The chest is {state}, What do you want to do? ");
    string action = Console.ReadLine();

    switch (action) 
    {
        case "close":
            if (state == boxState.Open) 
            {
                state = boxState.Closed;
            }
            break;
        case "open":
            if (state == boxState.Closed)
            {
                state = boxState.Open;
            }
            break;
        case "lock":
            if (state == boxState.Closed)
            {
                state = boxState.Locked;
            }
            break;
        case "unlock":
            if (state == boxState.Locked)
            {
                state = boxState.Closed;
            }
            break;
        default: 
            Console.WriteLine("invalid selction");
            break;
    }
    return state;
}

//level 17
void soup() 
{
    displaySoup(soupMenu());
}
//Displays the 3 enum values to the console
void displaySoup((Enum soupStyle, Enum mainIngredient, Enum seasoning) soup)
{
    Console.WriteLine($"{soup.seasoning} {soup.mainIngredient} {soup.soupStyle}!");
}
(Enum,  Enum,  Enum) soupMenu()
{
    Console.WriteLine($"Slect a food type: {foodType.soup}, {foodType.stew}, or {foodType.gumbo}");
    var input = Console.ReadLine();
    foodType userFood = default;
    switch (input)
    {
        case "soup":
            userFood = foodType.soup;
            break;
        case "stew":
            userFood = foodType.stew;
            break;
        case "gumbo":
            userFood = foodType.gumbo;
            break;
        default:
            Console.WriteLine("invalid selction, using default value");
            break;
    }

    Console.WriteLine($"Slect a ingredient: {mainIngredient.mushroom}, {mainIngredient.chicken}, {mainIngredient.potato}, or {mainIngredient.carrot}");
    input = Console.ReadLine();
    mainIngredient userIngredient = default;
    switch (input)
    {
        case "mushroom":
            userIngredient = mainIngredient.mushroom;
            break;
        case "chicken":
            userIngredient = mainIngredient.chicken;
            break;
        case "carrot":
            userIngredient = mainIngredient.carrot;
            break;
        case "potato":
            userIngredient = mainIngredient.potato;
            break;
        default:
            Console.WriteLine("invalid selction, using default value");
            break;
    }

    Console.WriteLine($"Slect a seasoning: {seasoning.spicy}, {seasoning.salty}, or {seasoning.sweet}");
    input = Console.ReadLine();
    seasoning userSeasoning = default;
    switch (input)
    {
        case "spicy":
            userSeasoning = seasoning.spicy;
            break;
        case "salty":
            userSeasoning = seasoning.salty;
            break;
        case "sweet":
            userSeasoning = seasoning.sweet;
            break;
        default:
            Console.WriteLine("invalid selction, using default value");
            break;
    }

    return (userFood, userIngredient, userSeasoning);
}

//level 18, 19, 20, 21
void arrowSelling()
{
    Console.WriteLine("elite, beginner, marksman, or custom");
    var selection = Console.ReadLine();
    switch (selection)
    {
        case "custom":
            Arrow userCraftedArrow = new(arrowHeadMenu(), fletchingMenu(), shaftMenu());
            userCraftedArrow.GetCost();
            break;
        case "elite":
            Arrow elite = Arrow.CreateElieteArrow();
            elite.GetCost();
            break;
        case "beginner":
            Arrow beginner = Arrow.CreateBeginnerArrow();
            beginner.GetCost();
            break;
        case "marksman":
            Arrow marksman = Arrow.CreateMarksmanArrow();
            marksman.GetCost();
            break;
        default: 
            Console.WriteLine("default");
            break;
    }


}
Arrowhead arrowHeadMenu()
{
    Console.WriteLine($"Slect a arrowhead type: {Arrowhead.wood}:3, {Arrowhead.obsidian}:5, or {Arrowhead.steel}:10");
    var input = Console.ReadLine();
    switch (input)
    {
        case "wood":
            Console.WriteLine($"{Arrowhead.wood} selected");
            return (Arrowhead.wood);
        case "obsidian":
            Console.WriteLine($"{Arrowhead.obsidian} selected");
            return Arrowhead.obsidian;
        case "steel":
            Console.WriteLine($"{Arrowhead.steel} selected");
            return Arrowhead.steel;
        default:
            Console.WriteLine("invalid selction. using default");
            return 0;
    }
}
Fletching fletchingMenu()
{
    Console.WriteLine($"Slect a feather type: {Fletching.goose}:3, {Fletching.turkey}:5, or {Fletching.plastic}:10");
    var input = Console.ReadLine();
    switch (input)
    {
        case "goose":
            Console.WriteLine($"{Fletching.goose} selected");
            return Fletching.goose;
        case "turkey":
            Console.WriteLine($"{Fletching.turkey} selected");
            return Fletching.turkey;
        case "plastic":
            Console.WriteLine($"{Fletching.plastic} selected");
            return Fletching.plastic;
        default:
            Console.WriteLine("invalid selction. using default");
            return 0;
    }
}
float shaftMenu() 
{
    const byte min = 60;
    const byte max = 100;
    Console.WriteLine($"Select a shaft size between {min} and {max}");
    var selection = Console.ReadLine();
    //return result doesn't say anything to user if selection invalid, but look its all on one line (:
    return min <= Convert.ToSingle(selection) && Convert.ToSingle(selection) <= max ? Convert.ToSingle(selection) : (float)60; 
}
internal class Arrow
{
    /// <summary>
    /// Will calculate the cost of an arrow using the provided fields as variables.
    /// </summary>
    /// <returns>
    /// Returns a float, but you can just call it on its own for it to write results to the console.
    /// </returns>
    public float GetCost()
    {
        float arrowHeadCost = Arrowhead switch
        {
            Arrowhead.wood => 3,
            Arrowhead.obsidian => 5,
            Arrowhead.steel => 10,
        };
        float fletchingCost = Fletching switch
        {
            Fletching.goose => 3,
            Fletching.turkey => 5,
            Fletching.plastic => 10,
        };
        float totalCost = ShaftLength * (float)0.05 + arrowHeadCost + fletchingCost;
        Console.WriteLine($"A {Fletching} fletched arrow {ShaftLength}cm in length with a {Arrowhead} arrowhead.");
        Console.WriteLine("Total cost is " + totalCost);
        return totalCost;
    }
    public float ShaftLength { get; init; }//60 to 100cm. 0.05 per cm
    public Fletching Fletching { get; init; }//goose, turkey, plastic. 3, 5, 10
    public Arrowhead Arrowhead { get; init; }//wood, obsidian, steel. 3, 5, 10
    public Arrow(Arrowhead arrowhead, Fletching fletching, float shaftLength)
    {
        Arrowhead = arrowhead;
        Fletching = fletching;
        ShaftLength = shaftLength;
    }
    public Arrow(): this(Arrowhead.wood, Fletching.goose, 60)
    {
        //defaults to the cheapest option if no parameters provided
    }
    public static Arrow CreateElieteArrow() => new(Arrowhead.steel, Fletching.plastic, 95);
    public static Arrow CreateBeginnerArrow() => new(Arrowhead.wood, Fletching.goose, 75);
    public static Arrow CreateMarksmanArrow() => new(Arrowhead.steel, Fletching.goose, 65);
}

//just shoving all them enums here
enum boxState {Open, Closed, Locked};
enum foodType { soup, stew, gumbo };
enum mainIngredient { mushroom, chicken, carrot, potato };
enum seasoning { spicy, salty, sweet };
public enum Arrowhead { wood = 0, obsidian, steel }; //wood, obsidian, steel. 3, 5, 10
public enum Fletching { goose = 0, turkey, plastic }; //goose, turkey, plastic. 3, 5, 10