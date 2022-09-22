using System;
using System.Diagnostics;
using TicTacToe;

namespace TicTacToe
{
    public sealed class Game : IGame
    {
        private readonly IPlayer[] _players;
        private readonly IBoard _board;
        private readonly IBoardDrawer _drawer;
        private readonly IWinCheck _winCheck;

        private int _currentPlayer;
        private int _turnCount;

        public Game()
        {
            _players = new IPlayer[]
            {
                new Player("X"),
                new Player("O")
            };

            _board = new Board(3);

            _drawer = new BoardDrawer(_board);

            _winCheck = new WinCheck(_board);
        }

        public void Run()
        {
            _currentPlayer = 0;
            _turnCount = 0;

            while (true)
            {
                _drawer.Draw();

                Console.WriteLine();
                Console.WriteLine("Turns: {0}", _turnCount);
                IBoardPosition position = GetInput();

                if (_board[position] != null) continue;

                _board[position] = _players[_currentPlayer];

                _currentPlayer = (int) ((_currentPlayer + 1u) % _players.Length);
                _turnCount++;

                if (_turnCount >= _board.Count) break;
                if (_winCheck.HasWon(out _)) break;
            }

            Console.WriteLine();
            Console.WriteLine("GAME OVER");
            Console.WriteLine("Turns: {0}", _turnCount);
        }

        private IBoardPosition GetInput()
        {
            Console.Write("Input: ");
            string input = Console.ReadLine() ?? throw new ArgumentException("no input");

            int index = int.Parse(input);
            Debug.Assert(index < _board.Count);

            var position = new BoardPosition(_board, index);

            return position;
        }
    }
}