using System.Diagnostics;
using TicTacToe;

namespace TicTacToe
{
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

            for (int row = 0; row < _board.Rows; row++)
            {
                IPlayer? currentPlayer = _board[0];
                if (currentPlayer == null) continue;
                
                for (int col = 1; col < _board.Cols; col++)
                {
                    if (currentPlayer != _board[row, col])
                    {
                        currentPlayer = null;
                        break;
                    }
                }

                if (currentPlayer != null)
                {
                    player = currentPlayer;
                    return true;
                }
            }

            return false;
        }
    }
}