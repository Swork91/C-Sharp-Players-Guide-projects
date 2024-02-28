/* Create a Coordinate Struct that can represent a room coordinate with a row and column.
 * Ensure Coordinate is immutable.
 * Make a method to determine if one coordinate is adjacent to another (differing only by a sinle row or column).
 * Write a main method that creates a few coordinates and determines if they are adjacent to each other to prove that it is working correctly.
 */
Coordinate a = new(1, 2);
Coordinate b = new(2, 3);

if (IsAdjacent(a, b))
{
    Console.WriteLine("yes");
}
else
{
    Console.WriteLine("no");  
}

bool IsAdjacent(Coordinate a, Coordinate b)
{
    //same col, adjacent row
    if ((a.row + 1 == b.row && a.col == b.col) || (a.row - 1 == b.row && a.col == b.col))
    {
        return true;
    }
    //same row, adjacent col
    else if ((a.col + 1 == b.col && a.row == b.row) || (a.col - 1 == b.col && a.row == b.row))
    {
        return true;
    }
    //diagonal, or overlapping, or far away.
    return false;
}

struct Coordinate
{
    public int row { get; init; }
    public int col { get; init; }
    public Coordinate (int row, int col)
    {
        this.row = row;
        this.col = col;
    }
}