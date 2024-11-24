using System;
using System.Collections.Generic;
using System.Drawing; // Sử dụng Image từ System.Drawing
using System.IO;
using ChessLogic;

namespace WF.ChessUI
{
    // Lớp static này dùng để quản lý hình ảnh các quân cờ
    public static class Images
    {
        // Từ điển chứa hình ảnh quân cờ trắng
        private static readonly Dictionary<PieceType, Image> whiteImages = new()
        {
            { PieceType.Pawn, LoadImage("Photos/PawnW.png") },
            { PieceType.Bishop, LoadImage("Photos/BishopW.png") },
            { PieceType.Knight, LoadImage("Photos/KnightW.png") },
            { PieceType.Rook, LoadImage("Photos/RookW.png") },
            { PieceType.Queen, LoadImage("Photos/QueenW.png") },
            { PieceType.King, LoadImage("Photos/KingW.png") }
        };

        // Từ điển chứa hình ảnh quân cờ đen
        private static readonly Dictionary<PieceType, Image> blackImages = new()
        {
            { PieceType.Pawn, LoadImage("Photos/PawnB.png") },
            { PieceType.Bishop, LoadImage("Photos/BishopB.png") },
            { PieceType.Knight, LoadImage("Photos/KnightB.png") },
            { PieceType.Rook, LoadImage("Photos/RookB.png") },
            { PieceType.Queen, LoadImage("Photos/QueenB.png") },
            { PieceType.King, LoadImage("Photos/KingB.png") }
        };

        // Hàm để nạp hình ảnh từ thư mục Photos
        private static Image LoadImage(string filePath)
        {
            // Đảm bảo sử dụng đường dẫn đầy đủ nếu cần thiết
            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);

            if (File.Exists(fullPath))
            {
                return Image.FromFile(fullPath);
            }
            else
            {
                throw new FileNotFoundException($"Không tìm thấy file hình ảnh tại: {fullPath}");
            }
        }

        // Lấy hình ảnh theo màu quân và loại quân
        public static Image GetImage(Player color, PieceType type)
        {
            return color switch
            {
                Player.White => whiteImages[type],
                Player.Black => blackImages[type],
                _ => null
            };
        }

        // Lấy hình ảnh từ đối tượng Piece
        public static Image GetImage(Piece piece)
        {
            if (piece == null)
                return null;
            return GetImage(piece.Color, piece.Type);
        }
    }
}
