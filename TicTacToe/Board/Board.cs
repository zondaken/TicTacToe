using System.Collections.Generic;
using System.Diagnostics;

namespace TicTacToe
{
    /*
     * Assumptions:
     * - board is quadratic
     */

    public sealed class Board : IBoard
    {
        public int Size { get; }
        public int Rows => Size;
        public int Cols => Size;
        public int Count => Rows * Cols;

        private readonly IPlayer?[] _board;

        public Board(int size)
        {
            Size = size;
            _board = new IPlayer?[Count];
        }

        public IPlayer? this[IBoardPosition position]
        {
            get => _board[position.Index];
            set => _board[position.Index] = value;
        }

        public IEnumerable<IPlayer?> GetRow(int row)
        {
            var start = row * Cols;
            var end = (row + 1) * Cols;

            Debug.Assert(start < int.MaxValue);
            Debug.Assert(end < int.MaxValue);

            return _board[start..end];
        }
    }
}