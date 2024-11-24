using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    // Store how many pieces of each kind that two player have
    public class Counting
    {
        private readonly Dictionary<PieceType, int> whiteCount = new();
        private readonly Dictionary<PieceType, int> blackCount = new();

        public int TotalCount { get; private set; }

        // typeof(PieceType) will return "ChessLogic.PieceType"
        // This constructor will initialize all possible values of PieceType
        // for each count
        public Counting()
        {
            foreach(PieceType type in Enum.GetValues(typeof(PieceType)))
            {
                whiteCount[type] = 0;
                blackCount[type] = 0;
            }
        }

        // Readonly only ensures that the field is only assigned once
        // In this case it's when they're declared
        // The Dictionary object itself is mutable
        public void Increment(Player color, PieceType type)
        {
            if (color == Player.White)
                whiteCount[type]++;
            else
                blackCount[type]++;

            TotalCount++;
        }

        public int White(PieceType type)
        {
            return whiteCount[type];
        }

        public int Black(PieceType type)
        {
            return blackCount[type];
        }
    }
}
