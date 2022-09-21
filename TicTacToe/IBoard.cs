namespace TicTacToe;

public interface IBoard
{
    uint Rows { get; }
    uint Cols { get; }
    uint Count { get; }
    Player? this[IBoardPosition position] { get; set; }
    IEnumerable<Player?> GetRow(uint row);
}