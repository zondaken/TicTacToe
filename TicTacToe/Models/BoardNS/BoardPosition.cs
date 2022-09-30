namespace TicTacToe.Models.BoardNS
{
    public struct BoardPosition
    {
        public int Row { get; }
        public int Col { get; }
        public int Index { get; }

        public BoardPosition(Board board, int row, int col)
        {
            Row = row;
            Col = col;
            Index = Row * board.Cols + col;
        }

        public BoardPosition(Board board, int index)
        {
            // index = row * Cols + col
            // col = index - (row * Cols)

            Index = index;
            Row = Index / board.Cols;
            Col = Index - (Row * board.Cols);
        }
    }
}