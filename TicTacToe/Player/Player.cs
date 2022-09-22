namespace TicTacToe
{
    public sealed class Player : IPlayer
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