using TicTacToe.Unrelated;

namespace TicTacToe;

public static class Program
{
    public static void Main(string[] args)
    {
        var t = new Temperature();
        t.Celsius = 25;
        Console.WriteLine(t.Fahrenheit);
        
        IGame game = new Game();
        //game.Run();
    }
}