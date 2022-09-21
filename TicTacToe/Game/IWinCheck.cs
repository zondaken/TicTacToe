namespace TicTacToe;

public interface IWinCheck
{
    bool HasWon(out IPlayer? player);
}