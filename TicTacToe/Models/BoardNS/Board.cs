using System.Diagnostics;

namespace TicTacToe.Models.BoardNS
{
    /*
     * Assumptions:
     * - board is quadratic
     */

    public sealed class Board
    {
        public int Size { get; }
        public int Rows => Size;
        public int Cols => Size;
        public int Count => Rows * Cols;

        private readonly Player?[] _board;
        private readonly WinCheck _winCheck;

        public Board(int size)
        {
            Size = size;
            _board = new Player?[Count];
            _winCheck = new WinCheck(this);
        }

        public Player? this[BoardPosition position]
        {
            get => _board[position.Index];
            set => _board[position.Index] = value;
        }

        public Player? this[int index]
        {
            get => this[new BoardPosition(this, index)];
            set => this[new BoardPosition(this, index)] = value;
        }

        public Player? this[int row, int col]
        {
            get => this[new BoardPosition(this, row, col)];
            set => this[new BoardPosition(this, row, col)] = value;
        }

        public IEnumerable<Player?> GetRow(int row)
        {
            var start = row * Cols;
            var end = (row + 1) * Cols;

            Debug.Assert(start < int.MaxValue);
            Debug.Assert(end < int.MaxValue);

            return _board[start..end];
        }

        public bool CheckWin(out Player? player)
        {
            return _winCheck.HasWon(out player);
        }
    }
}