using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic.PVP
{
    public class PVP_Client
    {
        private TcpClient client;
        private NetworkStream stream;

        private ManualResetEvent turnEvent;
        private ManualResetEvent formEvent;
        public void connectToServer(IPAddress serverIP, int port, ManualResetEvent turnEvent, ManualResetEvent formEvent, ref bool hasConnected)
        {
            try
            {
                client = new TcpClient();
                client.Connect(serverIP, port);
                this.formEvent = formEvent;
                this.turnEvent = turnEvent;
                stream = client.GetStream();

                hasConnected = true;
                Debug.Print("Connected to Server");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to the server!");
            }
        }

        public void SendMove(Move move)
        {
            formEvent.WaitOne();
            if (stream != null && stream.CanWrite)
            {
                string moveString = ConvertMoveToString(move);
                byte[] data = Encoding.UTF8.GetBytes(moveString);
                stream.Write(data, 0, data.Length);
                formEvent.Reset();
            }
        }
        public string ReceiveMove()
        {
            if (stream != null && stream.CanRead)
            {
                byte[] data = new byte[256];
                int bytesRead = stream.Read(data, 0, data.Length);
                formEvent.Set();
                return Encoding.UTF8.GetString(data, 0, bytesRead);
            }
            return null;
        }
        private string ConvertMoveToString(Move move)
        {
            string moveString = "";
            if (move.Type == MoveType.CastleKS || move.Type == MoveType.CastleQS)
            {
                Position kingPos = move.FromPos;
                moveString = move.Type.ToString() + "," + kingPos.ToString();
            }
            else if (move.Type == MoveType.PawnPromotion)
            {
                PieceType newType = ((PawnPromotion)move).newType;
                moveString = move.Type.ToString() + "," + move.FromPos.ToString() + "," + move.ToPos.ToString() + "," + newType.ToString();
            }
            else
            {
                moveString = move.Type.ToString() + "," + move.FromPos.ToString() + "," + move.ToPos.ToString();
            }
            return moveString;
        }

        public Move returnMoveFromString(string message)
        {
            string[] subStrings = message.Split(',');
            Debug.WriteLine(message);
            MoveType moveType = (MoveType)Enum.Parse(typeof(MoveType), subStrings[0]);

            if (moveType == MoveType.CastleKS || moveType == MoveType.CastleQS)
            {
                Position kingPos = ParsePosition(subStrings[1]);
                return new Castle(moveType, kingPos);
            }
            else if (moveType == MoveType.PawnPromotion)
            {
                Position fromPos = ParsePosition(subStrings[1]);
                Position toPos = ParsePosition(subStrings[2]);
                PieceType newType = (PieceType)Enum.Parse(typeof(PieceType), subStrings[3]);
                return new PawnPromotion(fromPos, toPos, newType, true);
            }
            else
            {
                Position fromPos = ParsePosition(subStrings[1]);
                Position toPos = ParsePosition(subStrings[2]);

                if (moveType == MoveType.EnPassant)
                    return new EnPassant(fromPos, toPos);
                else if (moveType == MoveType.DoublePawn)
                    return new DoublePawn(fromPos, toPos);
                else if (moveType == MoveType.Normal)
                    return new NormalMove(fromPos, toPos);
            }
            // Filler case
            return new NormalMove(new Position(0, 0), new Position(0, 0));
        }

        public Position ParsePosition(string pos)
        {
            string[] subStrings = pos.Split(':');
            int row = int.Parse(subStrings[0]);
            int column = int.Parse(subStrings[1]);
            return new Position(row, column);
        }
        public void ResumeServerComm()
        {
            // Set the event to resume the server communication thread
            turnEvent.Set();
        }
        public void Disconnect()
        {
            stream?.Close();
            client?.Close();
        }
    }
}
