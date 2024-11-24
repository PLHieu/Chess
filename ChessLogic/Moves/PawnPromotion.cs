namespace ChessLogic
{
    public class PawnPromotion : Move
    {
        // Why need from pos?
        public override MoveType Type => MoveType.PawnPromotion;
        public override Position FromPos { get; }
        public override Position ToPos { get; }

        public readonly PieceType newType;
        public readonly bool isSentMove;
        public PawnPromotion(Position fromPos, Position toPos, PieceType newType, bool isSentMove)
        {
            FromPos = fromPos;
            ToPos = toPos;
            this.newType = newType;
            this.isSentMove = isSentMove;
        }

        private Piece CreatePromotionPiece(Player color)
        {
            return newType switch
            {
                PieceType.Knight => new Knight(color),
                PieceType.Bishop => new Bishop(color),
                PieceType.Rook => new Rook(color),
                _ => new Queen(color),  
            };
        }

        public override bool Execute(Board board)
        {
            Piece pawn = board[FromPos];
            board[FromPos] = null;

            Piece promotionPiece = CreatePromotionPiece(pawn.Color);
            promotionPiece.HasMoved = true;
            board[ToPos] = promotionPiece;

            return true;
        }
    }
}
