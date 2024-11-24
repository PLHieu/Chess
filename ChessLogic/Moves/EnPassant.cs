namespace ChessLogic
{
    public class EnPassant : Move
    {
        public override MoveType Type => MoveType.EnPassant;
        public override Position FromPos { get; }
        public override Position ToPos { get; }

        private readonly Position capturePos;

        public EnPassant(Position from, Position to)
        {
            FromPos = from;
            ToPos = to;

            // Enpasant capture happens only when 2 pawns are in the same row
            capturePos = new Position(from.Row, to.Column);
        }

        public override bool Execute(Board board)
        {
            new NormalMove(FromPos, ToPos).Execute(board);
            board[capturePos] = null;

            return true;
        }
    }
}
