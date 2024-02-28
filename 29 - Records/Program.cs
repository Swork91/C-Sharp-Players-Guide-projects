/* War Preperations
 * Swords can be made out of any of the following materials: wood, bronze, Iron, steel and the rare binarium.
 *  Create an enumeration to represent the materal type.
 * Gemstones can be attatched to the sword, which gives them strange powers through Cygnus and Lyra's tough. 
 *  Gemmstone types include emerald, amber, sapphire, diamon, and the rare bitstone. Or no gemstones at all. 
 *  Create an enumeration to represent the gemstone type.
 * Create a Sword record with a materal, gemstone, length, and crossguard width.
 * In your main program, create a basic Sword instance made out of Iron and with no gemstones. 
 *  Then create two variations on the basic sword using with examples.
 * Display all three sword instances with code like Console.Writeline( original );
 */

main();

void main()
{
    Sword basic = new(Material.Iron, Gemstone.None, 1, 1);
    Sword piss = new(Material.Bronze, Gemstone.Diamond, 5, 6);
    Sword ass = new(Material.Steel, Gemstone.Diamond, 5, 7);

    Console.WriteLine(basic);
    Console.WriteLine(piss);
    Console.WriteLine(ass);

}
public record Sword(Material material, Gemstone gemstone, int length, int width);
public enum Material { Wood, Bronze, Iron, Steel, Binarium }
public enum Gemstone { None, Emerald, Amber, Sapphire, Diamond, Bitstone }