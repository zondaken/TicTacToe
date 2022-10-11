using TicTacToe.Models.BoardNS;

namespace TicTacToe.Models;

public class Model
{
    public Board Board { get; set; } = null!;
    public int TurnCount { get; set; } = 0;
    public Player[] Players { get; }
    public int CurrentPlayer { get; set; } = 0;
    
    public Model()
    {
        // TOOD: Konfiguration maybe von aussen?
        
        Players = new Player[]
        {
            new Player("X"), 
            new Player("O")
        };
    }
}