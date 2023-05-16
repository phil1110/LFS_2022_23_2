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
    /// Helper class for writing information into the socket
    /// </summary>
    public class SocketWriter
    {
        /// <summary>
        /// The socket to be used for network communication
        /// </summary>
        private Socket _communicationSocket;

        /// <summary>
        /// Creates a new SocketWriter instance
        /// </summary>
        /// <param name="communicationSocket">Socket to be used for network communication</param>
        public SocketWriter(Socket communicationSocket)
        {
            _communicationSocket = communicationSocket;
        }

        public void Send(Calculation calculation)
        {
            string msg = calculation.ToNetworkString();

            Send(msg);
        }

        public void Send(string msg)
        {
            _communicationSocket.Send(Consts.ENCODING.GetBytes(msg));
        }
    }
}
