namespace TicTacToe.MVC;

public class Model
{
    public IBoard Board { get; }
    public int TurnCount { get; set; }
    public IPlayer[] Players { get; }
    public int CurrentPlayer { get; set; }
    
    public Model(IBoard board)
    {
        Board = board;
        TurnCount = 0;
        Players = new IPlayer[] { new Player("X"), new Player("O") };
        CurrentPlayer = 0;
    }
}