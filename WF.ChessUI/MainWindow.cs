using ChessLogic;
using ChessLogic.PVP;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Threading;
using System.Windows.Forms;
using System.Text.Json;
using System.Xml.Serialization;

namespace WF.ChessUI
{
    public partial class MainWindow : Form
    {
        private readonly PictureBox[,] pieceImages = new PictureBox[8, 8];
        private GameState gameState;
        private readonly Dictionary<Position, Move> moveCache = new Dictionary<Position, Move>();
        private Position selectedPos = null;

        private PVP_Server server = null;
        private PVP_Client client = null;
        private bool hasConnected = false;

        Player currentPlayer = Player.White;
        private ManualResetEvent turnEvent = new ManualResetEvent(false);
        private ManualResetEvent canExecuteEvent = new ManualResetEvent(true);
        private Thread ExecutionThread;

        // các biến này phục vụ cho việc chơi với bot
        private bool botMode = false;
        string botEngine = "minimax";

        public MainWindow(string role, IPAddress ipToConnect, int port, bool botmode = false)
        {
            InitializeComponent();
            LoadBoardImage();
            InitializeBoard();

            this.botMode = botmode;

            if (role == "server")
            {
                server = new PVP_Server();
                turnEvent = new ManualResetEvent(false);
                canExecuteEvent = new ManualResetEvent(true);
                server.startServer(ipToConnect, port, turnEvent, canExecuteEvent, ref hasConnected);
            }
            else if (role == "client")
            {
                client = new PVP_Client();
                turnEvent = new ManualResetEvent(true);
                canExecuteEvent = new ManualResetEvent(false);
                client.connectToServer(ipToConnect, port, turnEvent, canExecuteEvent, ref hasConnected);
            }

            // Look here AnhThu!
            while (!hasConnected && role != "other" && botmode == false)
            {
                // Replace these MessageBox with something more visually appealing 
                // Add the loading animation under the text too
                if (role == "server")
                    MessageBox.Show("Waiting for client to connect!");
                else if (role == "client")
                    MessageBox.Show("Connecting to server, please wait!");
            }

            gameState = new GameState(currentPlayer, Board.Initial(), role, server, client, botmode);

            ExecutionThread = new Thread(HandleExecution);
            ExecutionThread.Start();

            DrawBoard(gameState.Board);

            // Replace these MessageBox too
            if (role == "server")
                MessageBox.Show("You're on the white side!");
            else if (role == "client")
                MessageBox.Show("You're on the black side!");
        }

        private void HandleExecution()
        {
            while (true)
            {
                turnEvent.WaitOne();

                string message = (server != null) ? server.ReceiveMove() : client.ReceiveMove();

                if (message != null)
                {
                    Move move = (server != null) ? server.returnMoveFromString(message) : client.returnMoveFromString(message);

                    if (move.Type == MoveType.PawnPromotion)
                    {
                        HandlePromotion(move.FromPos, move.ToPos, (PawnPromotion)move);
                    }
                    else
                    {
                        HandleMove(move);
                    }
                    turnEvent.Reset();
                }
            }
        }
        private void InitializeBoard()
        {
            boardGrid.Controls.Clear();
            boardGrid.RowCount = 8;
            boardGrid.ColumnCount = 8;
            boardGrid.Padding = new Padding(0);
            boardGrid.Margin = new Padding(0);
            boardGrid.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;

            for (int i = 0; i < 8; i++)
            {
                boardGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5f));
                boardGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5f));
            }

            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    var pictureBox = new PictureBox
                    {
                        Dock = DockStyle.Fill,
                        BackgroundImageLayout = ImageLayout.Stretch,
                        BorderStyle = BorderStyle.None,
                        BackColor = Color.Transparent,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Margin = new Padding(0)
                    };

                    pictureBox.MouseDown += BoardGrid_MouseDown;
                    pieceImages[r, c] = pictureBox;
                    boardGrid.Controls.Add(pictureBox, c, r);
                }
            }
        }

        private void DrawBoard(Board board)
        {
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    Piece piece = board[r, c];
                    pieceImages[r, c].Image = piece != null ? Images.GetImage(piece) : null;
                }
            }
        }

        private void LoadBoardImage()
        {
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Photos", "Board.png");
            boardGrid.BackgroundImage = Image.FromFile(imagePath);
            boardGrid.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void CacheMoves(IEnumerable<Move> moves)
        {
            moveCache.Clear();

            foreach (Move move in moves)
            {
                moveCache[move.ToPos] = move;
            }
        }

        private void ShowHighlights()
        {
            foreach (Position to in moveCache.Keys)
            {
                var pictureBox = pieceImages[to.Row, to.Column];

                var overlay = new Bitmap(pictureBox.Width + 20, pictureBox.Height + 20);
                using (var g = Graphics.FromImage(overlay))
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(100, 255, 255, 255)), 4, 7, overlay.Width + 20, overlay.Height + 20);
                }

                pictureBox.BackgroundImage = overlay;
                pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void HideHighlights()
        {
            foreach (Position to in moveCache.Keys)
            {
                var pictureBox = pieceImages[to.Row, to.Column];
                pictureBox.BackgroundImage = null;
            }
        }

        private void BoardGrid_MouseDown(object sender, MouseEventArgs e)
        {
            Point clientPoint = boardGrid.PointToClient(Cursor.Position);
            Position pos = ToSquarePosition(clientPoint);

            if (selectedPos == null)
            {
                OnFromPositionSelected(pos);
            }
            else
            {
                OnToPositionSelected(pos);
            }
        }

        private void OnFromPositionSelected(Position pos)
        {
            if (canExecuteEvent.WaitOne(0) == false)
                return;

            Piece piece = gameState.Board[pos];

            if (piece == null) return;

            IEnumerable<Move> moves = gameState.LegalMovesForPiece(pos);

            if (moves.Any())
            {
                selectedPos = pos;
                CacheMoves(moves);
                ShowHighlights();
            }
        }

        private void OnToPositionSelected(Position pos)
        {
            selectedPos = null;
            HideHighlights();

            if (moveCache.TryGetValue(pos, out Move move))
            {
                if (move.Type == MoveType.PawnPromotion)
                    HandlePromotion(move.FromPos, move.ToPos, (PawnPromotion)move);
                else
                    HandleMove(move);
            }

            // nếu như đang chơi với bot thì lúc này cần bot đi bước tiếp theo 
            if (botMode)
            {
                Move nextBotMove = GetNextMoveFromBot();
                if (nextBotMove.Type == MoveType.PawnPromotion)
                    HandlePromotion(nextBotMove.FromPos, nextBotMove.ToPos, (PawnPromotion)nextBotMove);
                else
                    HandleMove(nextBotMove);
            }
        }

        // nhận vào state của bàn cờ, current player và outpput ra 1 move tiếp theo
        private Move GetNextMoveFromBot()
        {
            // nếu bot là minimaxAI thì gọi thuat toan minimax
            if (botEngine == "minimax")
            {
                return GetNextMoveFromMiniMaxEngine(gameState, 5000);
            }


            // TODO nếu bot là chatGPT thì gọi API chatGPT
            return null;
        }

        private Move GetNextMoveFromMiniMaxEngine(GameState gameState, int maxTimeMs)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int depth = 3; // Initial depth; you may want to increase this for better decisions.
            Move bestMove = null;
            int bestValue = int.MinValue;

            IEnumerable<Move> possibleMoves = gameState.AllLegalMovesFor(gameState.CurrentPlayer);
            foreach (Move move in possibleMoves)
            {
                GameState newState = gameState.DeepCopyGameState();
                newState.MakeMove(move);

                int moveValue = Minimax(newState, depth - 1, true, int.MinValue, int.MaxValue, stopwatch, maxTimeMs);

                if (moveValue > bestValue)
                {
                    bestValue = moveValue;
                    bestMove = move;
                }

                if (stopwatch.ElapsedMilliseconds >= maxTimeMs)
                {
                    break; // Stop if we run out of time
                }
            }

            stopwatch.Stop();
            return bestMove;
        }

        private int Minimax(GameState gameState, int depth, bool isMaximizingPlayer, int alpha, int beta, Stopwatch stopwatch, int maxTimeMs)
        {
            if (depth == 0 || gameState.IsGameOver() || stopwatch.ElapsedMilliseconds >= maxTimeMs)
            {
                return EvaluateBoard(gameState);
            }

            IEnumerable<Move> possibleMoves = gameState.AllLegalMovesFor(isMaximizingPlayer ? gameState.CurrentPlayer : gameState.CurrentPlayer.Opponent());

            if (isMaximizingPlayer)
            {
                int maxEval = int.MinValue;
                foreach (Move move in possibleMoves)
                {
                    GameState newState = gameState.DeepCopyGameState();
                    newState.MakeMove(move);
                    int eval = Minimax(newState, depth - 1, true, alpha, beta, stopwatch, maxTimeMs);
                    maxEval = Math.Max(maxEval, eval);
                    alpha = Math.Max(alpha, eval);
                    if (beta <= alpha)
                    {
                        break; // Beta cut-off
                    }

                    if (stopwatch.ElapsedMilliseconds >= maxTimeMs)
                    {
                        break; // Stop if we run out of time
                    }
                }
                return maxEval;
            }
            else
            {
                int minEval = int.MaxValue;
                foreach (Move move in possibleMoves)
                {
                    GameState newState = gameState.DeepCopyGameState();
                    newState.MakeMove(move);
                    int eval = Minimax(newState, depth - 1, false, alpha, beta, stopwatch, maxTimeMs);
                    minEval = Math.Min(minEval, eval);
                    beta = Math.Min(beta, eval);
                    if (beta <= alpha)
                    {
                        break; // Alpha cut-off
                    }

                    if (stopwatch.ElapsedMilliseconds >= maxTimeMs)
                    {
                        break; // Stop if we run out of time
                    }
                }
                return minEval;
            }
        }



        private int EvaluateBoard(GameState gameState)
        {
            // This is a placeholder evaluation function. You would need to implement a more detailed evaluation.
            // Positive values favor the maximizing player, negative values favor the minimizing player.
            return gameState.EvaluateBoard(gameState);
        }



        private void ShowGameOverMenu(Result result)
        {
            var gameOverMenu = new GameOverMenu(result.Winner, result.Reason);
            gameOverMenu.ShowDialog();
        }

        private void HandleMove(Move move)
        {
            gameState.MakeMove(move);
            DrawBoard(gameState.Board);

            // Need to check whether it's redudant 
            if (move is PawnPromotion promotionMove)
            {
                HandlePromotion(promotionMove.FromPos, promotionMove.ToPos, (PawnPromotion)move);
            }

            if (gameState.IsGameOver()) // Kiểm tra trò chơi đã kết thúc chưa
            {
                var result = gameState.Result;
                ShowGameOverMenu(result); // Hiển thị GameOverMenu khi kết thúc trò chơi
            }
        }

        private void HandlePromotion(Position from, Position to, PawnPromotion pawnPromotion)
        {
            // Xóa quân cờ cũ
            pieceImages[from.Row, from.Column].Image = null;

            // If the move is not made by local machine, skip the selection proces
            if (pawnPromotion.isSentMove)
            {
                pieceImages[to.Row, to.Column].Image = Images.GetImage(gameState.CurrentPlayer, pawnPromotion.newType);
                gameState.MakeMove(new PawnPromotion(from, to, pawnPromotion.newType, false));
                DrawBoard(gameState.Board);
                if (gameState.IsGameOver())
                {
                    ShowGameOverMenu(gameState.Result);
                }
                return;
            }
            // Tạo menu phong cấp cho người chơi hiện tại
            PromotionMenu promMenu = new PromotionMenu(gameState.CurrentPlayer);

            // Hiển thị menu phong cấp dưới dạng modal trong giao diện
            try
            {
                // Đăng ký sự kiện khi người chơi chọn quân cờ
                promMenu.PieceSelected += type =>
                {
                    try
                    {
                        // Cập nhật quân cờ mới tại vị trí 'to' theo quân cờ người chơi chọn
                        pieceImages[to.Row, to.Column].Image = Images.GetImage(gameState.CurrentPlayer, type);

                        // Thực hiện nước đi thăng cấp
                        Move promMove = new PawnPromotion(from, to, type, false);
                        gameState.MakeMove(promMove);

                        // Vẽ lại bàn cờ
                        DrawBoard(gameState.Board);

                        // Kiểm tra nếu trò chơi kết thúc sau khi thăng cấp
                        if (gameState.IsGameOver())
                        {
                            ShowGameOverMenu(gameState.Result);  // Hiển thị menu khi trò chơi kết thúc
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Đã xảy ra lỗi trong khi thăng cấp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                // Mở menu phong cấp dưới dạng cửa sổ modal
                promMenu.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi mở menu phong cấp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Position ToSquarePosition(Point point)
        {
            double squareWidth = (double)boardGrid.ClientSize.Width / 8;
            double squareHeight = (double)boardGrid.ClientSize.Height / 8;

            int row = (int)(point.Y / squareHeight);
            int col = (int)(point.X / squareWidth);

            row = Math.Clamp(row, 0, 7);
            col = Math.Clamp(col, 0, 7);

            return new Position(row, col);
        }
    }
}
