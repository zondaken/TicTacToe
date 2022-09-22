using System.Collections.Generic;
using TicTacToe;

namespace TicTacToe
{
    public interface IBoard
    {
        int Rows { get; }
        int Cols { get; }
        int Count { get; }
        IPlayer? this[IBoardPosition position] { get; set; }
        IPlayer? this[int index] { get; set; }
        IPlayer? this[int row, int col] { get; set; }
        IEnumerable<IPlayer?> GetRow(int row);
    }
}