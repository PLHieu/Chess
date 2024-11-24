namespace ChessLogic
{
    // Always move towards the opponent side
    // Can move 2 position in the first move, and 1 position otherwise
    // Can move 1 position diagonally only if the move captures a piece
    public class Pawn : Piece
    {
        // Return PieceType.Pawn
        public override PieceType Type => PieceType.Pawn;
        private readonly Direction forward;
        public override Player Color { get; }
        public Pawn(Player color) 
        {
            Color = color;
             
            // Specify which way the pawn can move
            if (color == Player.White)
                forward = Direction.North;
            else
                forward = Direction.South;
        }

        public override Piece Copy()
        {
            Pawn copy = new Pawn(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private static bool CanMoveTo(Position pos, Board board)
        {
            return Board.IsInside(pos) && board.IsEmpty(pos);
        }

        private bool CanCaptureAt(Position pos, Board board)
        { 
            if (!Board.IsInside(pos) || board.IsEmpty(pos))
                return false;

            return board[pos].Color != Color;
        }

        private IEnumerable<Move> ForwardMoves(Position from, Board board)
        {
            Position oneMovePos = from + forward;

            if (CanMoveTo(oneMovePos, board))
            {
                if (oneMovePos.Row == 0 || oneMovePos.Row == 7)
                {
                    foreach (Move promMove in PromotionMoves(from, oneMovePos))
                    {
                        yield return promMove;
                    }
                }
                else
                {
                    yield return new NormalMove(from, oneMovePos);
                }

                Position twoMovesPos = oneMovePos + forward;

                if (!HasMoved && CanMoveTo(twoMovesPos, board))
                {
                    yield return new DoublePawn(from, twoMovesPos);
                }
            }
        }

        private IEnumerable<Move> DiagonalMoves(Position from, Board board)
        {
            foreach (Direction dir in new Direction[] { Direction.West, Direction.East })
            {
                Position to = from + forward + dir;

                // For Enpassant
                if (to == board.GetPawnSkipPosition(Color.Opponent()))
                    yield return new EnPassant(from, to);
                else if (CanCaptureAt(to, board))
                {
                    if (to.Row == 0 || to.Row == 7)
                    {
                        foreach (Move promMove in PromotionMoves(from, to))
                        {
                            yield return promMove;
                        }
                    }
                    else
                    {
                        yield return new NormalMove(from, to);
                    }
                }
            }
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return ForwardMoves(from, board).Concat(DiagonalMoves(from, board));
        }

        public override bool CanCaptureOpponentKing(Position from, Board board)
        {
            // piece != null is redundant
            return DiagonalMoves(from, board).Any(move =>
            {
                Piece piece = board[move.ToPos];
                return piece != null && piece.Type == PieceType.King;
            });
        }

        private static IEnumerable<Move> PromotionMoves(Position from, Position to)
        {
            yield return new PawnPromotion(from, to, PieceType.Knight, false);
            yield return new PawnPromotion(from, to, PieceType.Bishop, false);
            yield return new PawnPromotion(from, to, PieceType.Rook, false);
            yield return new PawnPromotion(from, to, PieceType.Queen, false);
        }
    }
}
