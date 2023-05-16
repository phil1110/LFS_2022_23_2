using Calculator.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Service.Shared
{
    /// <summary>
    /// Class handling the incoming new clients by creating a session handler instance for each client
    /// </summary>
    internal class ClientAcceptor
    {
        /// <summary>
        /// Listener socket for handling new incoming clients
        /// </summary>
        readonly Socket _listenerSocket;
        /// <summary>
        /// A subscriber that shall be informed about execution in the server
        /// </summary>
        readonly IServerSubscriber _subscriber;

        internal ClientAcceptor(Socket listenerSocket, IServerSubscriber subscriber)
        {
            _listenerSocket = listenerSocket;
            _subscriber = subscriber;
        }

        /// <summary>
        /// Handles new incoming clients by accepting the connection and creating 
        /// a session handler instance that does the communication with a single client
        /// </summary>
        internal void AcceptClients()
        {
            _listenerSocket.Listen(10);

            while (true)
			{
                Task.Run(() => new QuarantineSessionHandler(_listenerSocket.Accept(), _subscriber).HandleCommunication());
			}
        }

    }
}
