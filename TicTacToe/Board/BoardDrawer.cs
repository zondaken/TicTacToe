using System.Collections.Immutable;

namespace TicTacToe;

public sealed class BoardDrawer : IBoardDrawer
{
    private readonly IBoard _board;

    public BoardDrawer(IBoard board)
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
            var numbers = Enumerable.Range(row * _board.Cols + 1, _board.Cols);
            Console.Write(" ");
            Console.WriteLine(string.Join(" | ", numbers));
            Console.WriteLine(new string('=', _board.Cols * 3 + 2));
        }
    }

    private void DrawCurrentBoard()
    {
        for (int row = 0; row < _board.Rows; row++)
        {
            ImmutableArray<IPlayer?> players = _board.GetRow(row).ToImmutableArray();

            Console.Write(" ");

            for (int i = 0; i < players.Length; i++)
            {
                IPlayer? player = players[i];

                Console.Write(player?.ToString() ?? " ");

                if (i + 1 < players.Length)
                {
                    Console.Write(" | ");
                }
            }

            Console.WriteLine();

            if (row + 1 < _board.Rows)
            {
                Console.WriteLine(new string('=', _board.Rows * 3 + 2));
            }
        }
    }
}