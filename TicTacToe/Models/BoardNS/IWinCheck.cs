namespace TicTacToe.Models.BoardNS
{
    public interface IWinCheck
    {
        bool HasWon(out Player? player);
    }
}