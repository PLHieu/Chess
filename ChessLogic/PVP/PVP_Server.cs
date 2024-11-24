using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ChessLogic
{
    public class PVP_Server
    {
        private TcpListener server;
        private TcpClient client;
        private NetworkStream stream;
        private Thread listenerThread;
        IPAddress serverIP;
        private int assignedPort;

        private ManualResetEvent turnEvent = new ManualResetEvent(false);
        private ManualResetEvent formEvent;

        public void startServer(IPAddress ip, int port, ManualResetEvent turnEvent, ManualResetEvent formEvent, ref bool hasConnected)
        {
            serverIP = ip;
            assignedPort = port;
            server = new TcpListener(serverIP, assignedPort);
            server.Start();
            this.formEvent = formEvent;
            this.turnEvent = turnEvent;

            assignedPort = ((IPEndPoint)server.LocalEndpoint).Port;

            bool localHasConnected = false;
            listenerThread = new Thread(() => ListenForClients(ref localHasConnected));
            listenerThread.Start();

            listenerThread.Join(); // Wait for the thread to complete
            hasConnected = localHasConnected; // Update the ref parameter
        }

        private void ListenForClients(ref bool hasConnected)
        {
            try
            {
                client = server.AcceptTcpClient();
                stream = client.GetStream();
                hasConnected = true;
                Debug.WriteLine("\nClient has connected!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                hasConnected = false; // Ensure hasConnected is set to false in case of an exception
            }
        }
        public void SendMove(Move move)
        {
            // Called by another function to send moves to the client
            formEvent.WaitOne();
            if (stream != null && stream.CanWrite)
            {
                string moveString = ConvertMoveToString(move);
                byte[] data = Encoding.UTF8.GetBytes(moveString);
                stream.Write(data, 0, data.Length);
            }
            formEvent.Reset();
        }

        // Try parse the message then execute the move
        // Reset the stopExecutingMessage flag, preventing double moves from execution
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

        public void StopServer()
        {
            // "?" : null-conditional operator 
            // If the object is null, do nothing. Else, execute the member method
            stream?.Close();
            client?.Close();
            server?.Stop();
            listenerThread?.Abort();
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
        public void ResumeClientComm()
        {
            // Set the event to resume the client communication thread
            turnEvent.Set();
        }

        // Change from message to "Move" type
        // Encapsulate MoveType, FromPos, ToPos
        public Move returnMoveFromString(string message)
        {
            string[] subStrings = message.Split(',');
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
    }
}
