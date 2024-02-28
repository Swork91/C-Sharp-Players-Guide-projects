/* Colored Items
 * 
 * Put the three class definitions above into a new project. 
 * Define a generic class to represent a colored item. It must have properties for the item itself(generic in type) and a ConsoleColor associtated with it. 
 * Add a void Display() method to your colored item type that changes the console's foregorund color to the item's color and displays the item in that color.
 *  It is sufficient to just call ToString() on the item to get a text representation.
 * In your main method, create a new colored item containg a blue sword, red bow, and a green axe. 
 *  Display all three items to see each item displayed in its color. 
 */

ColoredItem<Sword> BlueSword = new(ConsoleColor.Blue, new Sword());
ColoredItem<Bow> RedBow = new(ConsoleColor.Red, new Bow());
ColoredItem<Axe> GreenAxe = new(ConsoleColor.Green, new Axe());

BlueSword.Display();
RedBow.Display();
GreenAxe.Display();

public class Sword { }
public class Bow { }
public class Axe { }
public class ColoredItem<T>
{ 
    public T Item { get; set; }
    public ConsoleColor Color { get; set; }
    public ColoredItem (ConsoleColor color, T item)
    {
        Item = item;
        Color = color;
    }
    public void Display() 
    {
        Console.BackgroundColor = Color;
        Console.WriteLine(Item.ToString());
    }
}