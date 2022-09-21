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
        DrawExampleBoard();
        Console.WriteLine();
        DrawCurrentBoard();
    }

    private void DrawExampleBoard()
    {
        Console.WriteLine(" 1 | 2 | 3 \n" +
                          "===========\n" +
                          " 4 | 5 | 6 \n" +
                          "===========\n" +
                          " 7 | 8 | 9 \n");
    }

    private void DrawCurrentBoard()
    {
        for (uint row = 0; row < _board.Rows; row++)
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
                Console.WriteLine(new string('=', (int) (_board.Rows * 3) + 2));
            }
        }
    }
}