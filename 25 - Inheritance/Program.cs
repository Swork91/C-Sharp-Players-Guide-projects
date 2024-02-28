/*Level 25 
 * Arrow: Weight of 0.1, Volume of 0.05
 * Bow: Weight of 1, Volume of 4
 * Rope: Weight of 1, Volume of 1.5
 * Water: Weight of 2, Volume of 3,
 * Food: Weight of 1, Volume of 0.5
 * Sword: Weight of 5, Volume of 3.
 * Create an InventoryItem class that represents any of the different item types. 
 *  This class must represent the item's weight and volume, which it needs at creation time (constructor).
 * Create derived classes for each of the types of items above. 
 *  Each class should pass the correct weight and volume to the base class constructor, 
 *  but should be createable themselves with parameterless construtor (for example, new Rope() or new Sword().
 * Build a Pack class that can store an array of items.
 *  The total number of items, the maximum weight, and the maximum volume are provided at creation time and cannot change afterward.
 * Make a public bool Add(InventoryItem item) method to Pack that allows you to add items of any type to the pack's contents. 
 *  This method should fail (return false and not modify the pack's fields) if adding the item would cause it to exceed the pack's item count, 
 *  weight, and volume limit
 * Add properties to Pack that allow it to report the current item count, weight, and volume, and the limits of each.
 * Create a program that creates a new pack and them allow the user to add (or attempt to add) items chosen from a menu.
 */

/* Level 26 - Labeling Inventory
 * Override the existing ToString methond (from the object base class) on all of your inventory item subclasses to give them a name. 
 *  For example, new Rope().ToString() should return "Rope". 
 * Override ToString on the Pack class to display the contents of the pack. 
 *  If a pack contains water, rope, and two arrows, then calling ToString on that Pack object coukd look like "pack containing water rope arrow arrow".
 * Before the user chooses the next item add, display the pack's current contents via its new ToString method.
 */
using DocumentFormat.OpenXml.Office2010.Excel;

PackingInventory();

void PackingInventory()
{
    Pack pack = new Pack();
    int i = 0;
    while(true)
    {
        Menu(pack, i);
    }
}

void Menu(Pack pack, int i)
{
    Console.WriteLine("\nEnter an item to create and add or enter \"0\" for a list of options:");
    string? userInput = Console.ReadLine();
    switch (userInput)
    {
        case "0":
            Console.WriteLine("Options are \"Arrow\", \"Bow\", \"Rope\", \"Water\", \"Food\", \"Sword\", and \"Bag\".");
            break;
        case "Arrow":
            Arrow arrow = new();
            pack.Add(arrow, i);
            Console.WriteLine(pack.ToString()); // pack contents
            i++;
            break;
        case "Bow":
            Bow bow = new();
            pack.Add(bow, i);
            Console.WriteLine(pack.ToString()); // pack contents
            i++;
            break;
        case "Rope":
            Rope rope = new();
            pack.Add(rope, i);
            Console.WriteLine(pack.ToString()); // pack contents
            i++;
            break;
        case "Water":
            Water water = new();
            pack.Add(water, i);
            Console.WriteLine(pack.ToString()); // pack contents
            i++;
            break;
        case "Food":
            Food food = new();
            pack.Add(food, i);
            Console.WriteLine(pack.ToString()); // pack contents
            i++;
            break;
        case "Sword":
            Sword sword = new();
            pack.Add(sword, i);
            Console.WriteLine(pack.ToString()); // pack contents
            i++;
            break;
        default:
            Console.WriteLine("invalid option");
            break;
    }
}

public class InventoryItem
{
    public double Weight { get; set; }
    public double Volume { get; set; }
    public InventoryItem()
    {
        // will be called when creating derived class object.
    }
}
public class Arrow : InventoryItem
{
    public Arrow()
    {
        Weight = 0.1;
        Volume = 0.05;
    }

    public override string ToString()
    {
        return "Arrow";
    }
}
public class Bow : InventoryItem
{
    public Bow()
    {
        Weight = 1;
        Volume = 4;
    }
    public override string ToString()
    {
        return "Bow";
    }
}
public class Rope : InventoryItem
{
    public Rope()
    {
        Weight = 1;
        Volume = 1.5;
    }
    public override string ToString()
    {
        return "Rope";
    }
}
public class Water : InventoryItem
{
    public Water()
    {
        Weight = 2;
        Volume = 3;
    }
    public override string ToString()
    {
        return "Water";
    }
}
public class Food : InventoryItem
{
    public Food()
    {
        Weight = 1;
        Volume = 0.5;
    }
    public override string ToString()
    {
        return "Food";
    }
}
public class Sword : InventoryItem
{
    public Sword()
    {
        Weight = 5;
        Volume = 3;
    }
    public override string ToString()
    {
        return "Sword";
    }
}
public class Pack
{
    public int TotalItems { get; }
    public double MaxWeight { get; }
    public double MaxVolume { get; }
    public int CurrentItems { get; set; }
    public double CurrentWeight { get; set; }
    public double CurrentVolume { get; set; }
    public string Contents { get; set; }
    public InventoryItem[] ListOfItems { get; set; }
    public Pack()
    {
        // no idea what these should be so... R A N D O M
        TotalItems = 10;
        MaxWeight = 20;
        MaxVolume = 20;
        ListOfItems = new InventoryItem[TotalItems];
    }

    public override string ToString()
    {
        if (ListOfItems[0] != null)
        {
            foreach ( InventoryItem item in ListOfItems ) // iterates though all ten items
            {
                if (item != null)
                {
                    Contents = Contents + item.ToString() + " ";
                }
            }
            return "Pack contains: " + Contents;
        }
        else
        {
            return "Pack is empty!";
        }
    }

    public bool Add(InventoryItem item, int i)
    {
        if (CurrentItems + 1 > TotalItems || CurrentWeight + item.Weight > MaxWeight || CurrentVolume + item.Volume > MaxVolume)
        {
            Console.WriteLine("Too full, unable to add.");
            return false;
        }
        CurrentVolume += item.Volume;
        CurrentWeight += item.Weight;
        CurrentItems++;
        this.ListOfItems[i] = item;
        this.Report();
        return true;
    }
    public void Report()
    {
        Console.WriteLine("{0} / {1} Items", this.CurrentItems, this.TotalItems);
        Console.WriteLine("{0} / {1} Volume", this.CurrentVolume, this.MaxVolume);
        Console.WriteLine("{0} / {1} Weight", this.CurrentWeight, this.MaxWeight);
    }
}