namespace TicTacToe.Models
{
    public sealed class Player
    {
        private string _toString;

        public Player(string toString)
        {
            _toString = toString;
        }

        public override string? ToString()
        {
            return _toString;
        }
    }
}