using ChessLogic.PVP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ChessLogic
{
    // Store the curr board configuration, player's turn, etc
    public class GameState
    {
        public GameState() { }
        public Board Board { get; set; }
        public Player CurrentPlayer { get; private set; }
        public Result Result { get; private set; } = null;

        private int noCaptureOrPawnMoves = 0;
        private string stateString;
        private readonly Dictionary<string, int> stateHistory = new Dictionary<string, int>();

        private PVP_Server server;
        private PVP_Client client;
        private string role;

        public int Score { get; set; } = 0; // Simplified score representation


        public GameState(Player player, Board board, string role, PVP_Server server, PVP_Client client,bool botmode)
        {
            CurrentPlayer = player;
            Board = board;

            this.role = role;
            this.server = server;
            this.client = client;

            stateString = new StateString(CurrentPlayer, board).ToString();
            stateHistory[stateString] = 1;
        }

        public GameState DeepCopyGameState()
        {
            // Deep copy each attribute manually
            GameState copy = new GameState();

            copy.Result = DeepCopyJSON(Result);
            copy.Board = Board.DeepCopyBoard();
            copy.CurrentPlayer = DeepCopyJSON(CurrentPlayer);

            // Copy primitive attributes
            copy.role = role;
            copy.noCaptureOrPawnMoves = noCaptureOrPawnMoves;


            return copy;
        }

        public static int EvaluatePiecePosition(Piece piece, Position pos)
        {
            int[,] positionValues =
      {
        { 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 5, 5, 5, 5, 5, 5, 0 },
        { 0, 5, 10, 10, 10, 10, 5, 0 },
        { 0, 5, 10, 20, 20, 10, 5, 0 },
        { 0, 5, 10, 20, 20, 10, 5, 0 },
        { 0, 5, 10, 10, 10, 10, 5, 0 },
        { 0, 5, 5, 5, 5, 5, 5, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0 } };
            return positionValues[pos.Row, pos.Column];
        }

        public int EvaluateBoard(GameState gameState)
        {
            int score = 0;

            foreach (var pos in gameState.Board.PiecePositions())
            {
                Piece piece = gameState.Board[pos];
                int pieceValue = GetPieceValue(piece.Type);

                // Add positional score
                pieceValue += EvaluatePiecePosition(piece, pos);

                // Reward center control
                if (IsCenter(pos))
                    pieceValue += 10;

                // Add or subtract score based on piece color
                score += (piece.Color == Player.Black ? pieceValue : -pieceValue);
            }

            // Penalize exposed kings
            score += EvaluateKingSafety(gameState, Player.Black) - EvaluateKingSafety(gameState, Player.White);

            //// Reward dynamic mobility
            //score += GetMobilityScore(gameState, Player.White) - GetMobilityScore(gameState, Player.Black);

            return score;
        }

        private bool IsCenter(Position pos) => (pos.Row >= 3 && pos.Row <= 4) && (pos.Column >= 3 && pos.Column <= 4);

        private int EvaluateKingSafety(GameState gameState, Player player)
        {

            IEnumerable<Position>  posss = gameState.Board.PiecePositionsFor(player);
            Position kingPos = null;
            foreach (var pos in posss)
            {
                if  (gameState.Board[pos].Type == PieceType.King)
                {
                    kingPos = pos;
                    break;
                }
            }

            // TODO convert to english: nếu ko tìm thấy vua => nước đi này thất bại -> trả về điểm âm 
            if (kingPos == null)
            {
                return -999999;
            }

            int safety = 0;

            // Penalize if the king is exposed
            foreach (var dir in Direction.dirs)
            {
                Position adjacent = kingPos + dir;
                if (Board.IsInside(adjacent) && gameState.Board.IsEmpty(adjacent))
                {
                    safety -= 5;
                }
            }

            return safety;
        }


        private static int GetPieceValue(PieceType type)
        {
            return type switch
            {
                PieceType.Pawn => 100,
                PieceType.Knight => 320,
                PieceType.Bishop => 330,
                PieceType.Rook => 500,
                PieceType.Queen => 900,
                PieceType.King => 10000, // Assign a very high value to the King.
                _ => 0
            };
        }
        //public int EvaluateBoard()
        //{
        //    // Improved evaluation function for chess board state
        //    int evaluation = 0;

        //    for (int i = 0; i < 8; i++)
        //    {
        //        for (int j = 0; j < 8; j++)
        //        {
        //            if (Board[i, j] == null ){
        //                continue;
        //            }

        //            int pieceValue = GetPieceValue(Board[i,j].Type);

        //            if (pieceValue != 0)
        //            {
        //                evaluation += pieceValue * (CurrentPlayer == Player.White ? 1 : -1);
        //            }
        //        }
        //    }

        //    return evaluation;
        //}
        public static T DeepCopyXML<T>(T input)
        {
            using var stream = new MemoryStream();

            var serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(stream, input);
            stream.Position = 0;
            return (T)serializer.Deserialize(stream);
        }

        public static T DeepCopyJSON<T>(T input)
        {
            var jsonString = JsonSerializer.Serialize(input);
            return JsonSerializer.Deserialize<T>(jsonString);
        }


        // Generate all legal moves for a specific piece
        public IEnumerable<Move> LegalMovesForPiece(Position pos)
        {
            if (Board.IsEmpty(pos) || Board[pos].Color != CurrentPlayer)
            {
                return Enumerable.Empty<Move>();
            }

            Piece piece = Board[pos];
            IEnumerable<Move> moveCandidates = piece.GetMoves(pos, Board);
            return moveCandidates.Where(move => move.IsLegal(Board));
        }
        
        public void MakeMove(Move move)
        {
            Board.SetPawnSkipPosition(CurrentPlayer, null);
            bool captureOrPawn = move.Execute(Board);

            if (captureOrPawn)
            {
                noCaptureOrPawnMoves = 0;
                stateHistory.Clear();
            }
            else
            {
                noCaptureOrPawnMoves++;
            }

            // Sending moves to the server/client
            if (CurrentPlayer == Player.White && role == "server")
            {
                server.SendMove(move);
                server.ResumeClientComm();
            }
            else if (CurrentPlayer == Player.Black && role == "client")
            {
                client.SendMove(move);
                client.ResumeServerComm();
            }   

            CurrentPlayer = CurrentPlayer.Opponent();
            UpdateStateString();
            CheckForGameOver();
        }

        // For the checking of checkmate or stalemate
        public IEnumerable<Move> AllLegalMovesFor(Player player)
        {
            // SelectMany: Connect sequences into one single sequence
            IEnumerable<Move> moveCandidates = Board.PiecePositionsFor(player).SelectMany(pos =>
            {
                Piece piece = Board[pos];
                return piece.GetMoves(pos, Board);
            });

            return moveCandidates.Where(move => move.IsLegal(Board));
        }

        private void CheckForGameOver()
        {
            if (!AllLegalMovesFor(CurrentPlayer).Any())
            {
                if (Board.IsInCheck(CurrentPlayer))
                {
                    Result = Result.Win(CurrentPlayer.Opponent());
                }
                else
                {
                    Result = Result.Draw(EndReason.Stalemate);
                }
            }
            else if (Board.InsufficientMaterial())
                Result = Result.Draw(EndReason.InsufficientMaterial);
            else if (FiftyMoveRule())
                Result = Result.Draw(EndReason.FiftyMoveRule);
            else if (ThreefoldRepetition())
                Result = Result.Draw(EndReason.ThreefoldRepetition);
        }

        public bool IsGameOver()
        {
            return Result != null;
        }

        private bool FiftyMoveRule()
        {
            int fullMoves = noCaptureOrPawnMoves / 2;
            return fullMoves == 50;
        }

        private void UpdateStateString()
        {
            stateString = new StateString(CurrentPlayer, Board).ToString();

            if (!stateHistory.ContainsKey(stateString))
                stateHistory[stateString] = 1;
            else
                stateHistory[stateString]++;
        }

        private bool ThreefoldRepetition()
        {
            return stateHistory[stateString] == 3;
        }
    }
}
