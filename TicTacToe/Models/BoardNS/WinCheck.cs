﻿using System.Diagnostics;

namespace TicTacToe.Models.BoardNS
{
    public class WinCheck
    {
        private readonly Board _board;

        public WinCheck(Board board)
        {
            _board = board;

            Debug.Assert(_board.Rows == _board.Cols);
        }

        public bool HasWon(out Player? player)
        {
            player = null;

            for (int row = 0; row < _board.Rows; row++)
            {
                Player? currentPlayer = _board[0];
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