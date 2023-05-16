using Calculator.Service.Contracts;
using Calculator.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Service.Shared
{

    /// <summary>
    /// Main class for the TCP/IP server that handles the clients and does the calculations
    /// </summary>
    public class Server
    {
        /// <summary>
        /// A subscriber that shall be informed about execution in the server
        /// </summary>
        readonly IServerSubscriber _subscriber;
        /// <summary>
        /// IP end point of the server
        /// </summary>
        readonly IPEndPoint _endPoint;
        /// <summary>
        /// Listener socket for handling new incoming clients
        /// </summary>
        readonly Socket _listenerSocket;
        /// <summary>
        /// Client Acceptor that handles the client requests
        /// </summary>
        ClientAcceptor _clientAcceptor;

        /// <summary>
        /// Constructor preparing the TCP/IP server by setting the instance variables
        /// Server will run on 127.0.0.1 on the port defined in the Consts class
        /// </summary>
        /// <param name="subscriber">Subscriber that shall be informed about execution in the server (Dependency injection)</param>
        public Server(IServerSubscriber subscriber)
        {
            _subscriber = subscriber;
            _endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Consts.PORT);
            _listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _clientAcceptor = new ClientAcceptor(_listenerSocket, _subscriber);
        }

        public void Run()
        {
            _listenerSocket.Bind(_endPoint);

            _clientAcceptor.AcceptClients();
        }

    }
}
