namespace TicTacToe;

public struct BoardPosition : IBoardPosition
{
    public uint Row { get; }
    public uint Col { get; }
    public uint Index { get; }

    public BoardPosition(IBoard board, uint row, uint col)
    {
        Row = row;
        Col = col;
        Index = Row * board.Cols + col;
    }

    public BoardPosition(IBoard board, uint index)
    {
        // index = row * Cols + col
        // col = index - (row * Cols)
        
        Index = index;
        Row = Index / board.Cols;
        Col = Index - (Row * board.Cols);
    }
}