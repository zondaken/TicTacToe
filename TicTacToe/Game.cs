using System.Diagnostics;

namespace TicTacToe;

public sealed class Game : IGame
{
    private readonly Player[] _players;
    private readonly IBoard _board;
    private readonly IBoardDrawer _drawer;
    
    private bool _isRunning;
    private uint _currentPlayer;
    private uint _turnCount;

    public Game()
    {
        _players = new[]
        {
            new Player("X"),
            new Player("O")
        };

        _board = new Board(3);
        InitializeBoard();
        
        _drawer = new BoardDrawer(_board);
    }

    public void Run()
    {
        _isRunning = true;
        _currentPlayer = 0;
        _turnCount = 0;
        
        while (true)
        {
            Console.Clear();
            _drawer.Draw();

            if (!_isRunning) break;
            
            Console.WriteLine();
            Console.Write("Input: ");
            string input = Console.ReadLine() ?? throw new ArgumentException("no input");
            uint index = uint.Parse(input);
            
            Debug.Assert(index - 1 < _board.Count);
            
            var position = new BoardPosition(_board, index - 1);
            _board[position] = _players[_currentPlayer];

            _currentPlayer = (uint)((_currentPlayer + 1u) % _players.Length);
            _turnCount++;

            if (_turnCount >= _board.Count)
            {
                _isRunning = false;
            }
        }
        
        Console.WriteLine("GAME OVER");
    }

    private void InitializeBoard()
    {
        for (uint row = 0; row < _board.Rows; row++)
        {
            for (uint col = 0; col < _board.Cols; col++)
            {
                var position = new BoardPosition(_board, row, col); 
                _board[position] = null;
            }
        }
    }
}