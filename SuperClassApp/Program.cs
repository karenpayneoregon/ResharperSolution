using System.Drawing;

namespace SuperClassApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        Console.ReadLine();
    }
}

/*
 * 1. Select 'Circle
 * 2. Alt+R
 * 3. r
 * 4. x
 * 5. r
 */

public class Circle : IDrawable
{
    public Point Center { get; private set; }
    public Color MyColor { get; private set; }
    public int Radius { get; private set; }
    public void Draw()
    {
        // draw...
    }
}
public interface IDrawable
{
    void Draw();
}