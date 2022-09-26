namespace TicTacToe.MVC.ModelNS;

public class Model
{
    public IBoard? Board { get; set; } = null;
    public int TurnCount { get; set; } = 0;
    public IPlayer[] Players { get; }
    public int CurrentPlayer { get; set; } = 0;
    
    public Model()
    {
        Players = new IPlayer[]
        {
            new Player("X"), 
            new Player("O")
        };
    }
}