using System.Diagnostics;

namespace TicTacToe;

public class WinCheck : IWinCheck
{
    private readonly IBoard _board;

    public WinCheck(IBoard board)
    {
        _board = board;
        
        Debug.Assert(_board.Rows == _board.Cols);
    }

    public bool HasWon(out IPlayer? player)
    {
        player = null;
        return false;
    }
}