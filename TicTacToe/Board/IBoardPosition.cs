namespace TicTacToe
{
    public interface IBoardPosition
    {
        int Row { get; }
        int Col { get; }
        int Index { get; }
    }
}