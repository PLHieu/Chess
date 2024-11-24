namespace ChessLogic
{
    public abstract class Move
    {
        public abstract MoveType Type { get; }
        public abstract Position FromPos {  get; }
        public abstract Position ToPos { get; }
        
        // Return true when a piece is captured or a pawn is moved
        public abstract bool Execute(Board board);  

        public virtual bool IsLegal(Board board)
        {
            bool resetState = board[FromPos].HasMoved;
            Player player = board[FromPos].Color;
            Board boardCopy = board.Copy();
            Execute(boardCopy);
            board[FromPos].HasMoved = resetState;
            return !boardCopy.IsInCheck(player);
        }
    }
}
