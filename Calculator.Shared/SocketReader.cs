using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Calculator.Shared
{
    /// <summary>
    /// Helper class for reading information from a  socket
    /// </summary>

    public class SocketReader
    {
        /// <summary>
        /// The socket to be used for network communication
        /// </summary>
        private Socket _communicationSocket;

        /// <summary>
        /// Creates a new SocketReader instance
        /// </summary>
        /// <param name="communicationSocket">Socket to be used for network communication</param>
        public SocketReader(Socket communicationSocket)
        {
            _communicationSocket = communicationSocket;
        }

        public Calculation ReceiveCalculation()
        {
            return Calculation.FromNetworkString(ReceiveString());
        }

        public string ReceiveString()
        {
            byte[] msg = new byte[1024];

            int bytes = _communicationSocket.Receive(msg);

            return Consts.ENCODING.GetString(msg, 0, bytes);
        }
    }
}
