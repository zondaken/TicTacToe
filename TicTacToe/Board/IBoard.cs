namespace TicTacToe;

public interface IBoard
{
    int Rows { get; }
    int Cols { get; }
    int Count { get; }
    IPlayer? this[IBoardPosition position] { get; set; }
    IEnumerable<IPlayer?> GetRow(int row);
}