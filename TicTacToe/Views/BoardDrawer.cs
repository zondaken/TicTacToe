using System;
using System.Collections.Immutable;
using System.Linq;
using TicTacToe.Models;
using TicTacToe.Models.BoardNS;

namespace TicTacToe.Views
{
    public sealed class BoardDrawer
    {
        private readonly Board _board;

        public BoardDrawer(Board board)
        {
            _board = board;
        }

        public void Draw()
        {
            Console.Clear();
            DrawExampleBoard();
            Console.WriteLine();
            DrawCurrentBoard();
        }

        private void DrawExampleBoard()
        {
            Console.WriteLine("Example:");

            for (int row = 0; row < _board.Rows; row++)
            {
                // TODO: proper formatting with multidigit stuff
                
                string str;
                int maxsize = _board.Count.ToString().Length;
                int rowwidth = 0;

                for (int col = 0; col < _board.Cols; col++)
                {
                    int num = row * _board.Cols + col;
                    str = num.ToString().PadLeft(maxsize, ' ').PadRight(maxsize, ' ');
                    rowwidth += str.Length;
                    
                    Console.Write(str);

                    if (col + 1 < _board.Cols)
                    {
                        str = " | ";
                        Console.Write(str);
                        rowwidth += str.Length;
                    }
                }

                Console.WriteLine();
                
                if(row + 1 < _board.Rows) Console.WriteLine(new string('=', rowwidth + 1));
            }
        }

        private void DrawCurrentBoard()
        {
            for (int row = 0; row < _board.Rows; row++)
            {
                ImmutableArray<Player?> players = _board.GetRow(row).ToImmutableArray();

                Console.Write(" ");

                for (int i = 0; i < players.Length; i++)
                {
                    Player? player = players[i];

                    Console.Write(player?.ToString() ?? " ");

                    if (i + 1 < players.Length)
                    {
                        Console.Write(" | ");
                    }
                }

                Console.WriteLine();

                if (row + 1 < _board.Rows)
                {
                    Console.WriteLine(new string('=', _board.Cols * 3 + (_board.Cols - 1)));
                }
            }
        }
    }
}