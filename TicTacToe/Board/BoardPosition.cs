namespace TicTacToe;

public struct BoardPosition : IBoardPosition
{
    public int Row { get; }
    public int Col { get; }
    public int Index { get; }

    public BoardPosition(IBoard board, int row, int col)
    {
        Row = row;
        Col = col;
        Index = Row * board.Cols + col;
    }

    public BoardPosition(IBoard board, int index)
    {
        // index = row * Cols + col
        // col = index - (row * Cols)
        
        Index = index;
        Row = Index / board.Cols;
        Col = Index - (Row * board.Cols);
    }
}