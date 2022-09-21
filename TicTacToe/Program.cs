namespace TicTacToe;

public static class Program
{
    public static void Main(string[] args)
    {
        IGame game = new Game();
        game.Run();
    }
}