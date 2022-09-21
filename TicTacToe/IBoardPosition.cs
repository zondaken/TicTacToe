namespace TicTacToe;

public interface IBoardPosition
{
    uint Row { get; }
    uint Col { get; }
    uint Index { get; }
}