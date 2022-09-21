using System.Diagnostics;

namespace TicTacToe;

/*
 * Assumptions:
 * - board is quadratic
 */

public sealed class Board : IBoard
{
    public uint Size { get; }
    public uint Rows => Size;
    public uint Cols => Size;
    public uint Count => Rows * Cols;

    private readonly Player?[] _board;
    
    public Board(uint size)
    {
        Size = size;
        _board = new Player?[Count];
    }

    public Player? this[IBoardPosition position]
    {
        get => _board[position.Index];
        set => _board[position.Index] = value;
    }
    
    public IEnumerable<Player?> GetRow(uint row)
    {
        var start = (int) (row * Cols);
        var end = (int) ((row + 1) * Cols);
        
        Debug.Assert(start < int.MaxValue);
        Debug.Assert(end < int.MaxValue);

        return _board[start..end];
    }
}