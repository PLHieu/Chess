
namespace ChessLogic
{
    // Store player's turn, the winner, and color of chess pieces
    public enum Player
    {
        None,
        White,
        Black
    }

    public static class PlayerExtensions
    {
        // "this" keyword signify extension method
        // Extension method allows you to add new methods to existing types
        // This is useful since we can't add methods directly into enum
        public static Player Opponent(this Player player)
        {
            switch (player)
            {
                case Player.White:
                    return Player.Black;
                case Player.Black:
                    return Player.White;
                default:
                    return Player.None;
            }
        }
    }
}
