using Calculator.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Client.Shared
{

    /// <summary>
    /// Abstract class that supplies a client template for communicating with the server 
    /// </summary>
    public abstract class AbstractClient
    {
        /// <summary>
        /// Server IP end point of the server to be connected
        /// </summary>
        protected readonly IPEndPoint _serverEndpoint;
        /// <summary>
        /// ID of the client, will be sent to the server and used in loggings
        /// </summary>
        protected readonly string _id;
        /// <summary>
        /// Object that does the network reads in the server->client communication
        /// </summary>
        SocketReader _socketReader;
        /// <summary>
        /// Object that does the network reads in the client->server communication
        /// </summary>
        SocketWriter _socketWriter;

        /// <summary>
        /// Creates an instance of the class
        /// </summary>
        /// <param name="endpoint">IP endpoint of the server</param>
        /// <param name="id">ID for the client</param>
        protected AbstractClient(IPEndPoint endpoint, string id)
        {
            _serverEndpoint = endpoint;
            _id = id;
        }

        /// <summary>
        /// Creates an instance of the class with abn endpoint at 127.0.0.1
        /// </summary>
        /// <param name="id">ID for the client</param>
        protected AbstractClient(string id) : this(new IPEndPoint(IPAddress.Parse("127.0.0.1"), Consts.PORT), id)
        {
        }

        /// <summary>
        /// Opens a socket to the server and handles the communication protocol with the server.
        /// </summary>
        public void Run()
        {
            using (Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                clientSocket.Connect(_serverEndpoint);
                ShowLog($"Connecting to Server {clientSocket.RemoteEndPoint}");

                _socketReader = new SocketReader(clientSocket);
                _socketWriter = new SocketWriter(clientSocket);

                _socketWriter.Send(_id);
                ShowLog(_id + ": connected to server.");

                string result;
                do
                {
                    Calculation c = new Calculation(InquireNumber(), InquireNumber(), InquireOperation());
                    _socketWriter.Send(c);
                    result = _socketReader.ReceiveString();
                    ShowResult(result);
                } while (! result.StartsWith(Consts.EXIT_PREFIX));

                clientSocket.Shutdown(SocketShutdown.Both);
            }
        }

        /// <summary>
        /// Inquires a arithmetic operation from any source
        /// </summary>
        /// <returns>The supplied operation</returns>
        protected abstract Operation InquireOperation();

        /// <summary>
        /// Inquires a number for the calculation from any source
        /// </summary>
        /// <returns>The supplied number</returns>
        protected abstract int InquireNumber();

        /// <summary>
        /// Informs about the progress of the program
        /// </summary>
        /// <param name="result">The logging to be shown</param>
        protected abstract void ShowLog(string log);

        /// <summary>
        /// Informs about the result of the calculation
        /// </summary>
        /// <param name="result">The result to be shown</param>
        protected abstract void ShowResult(string result);

    }
}
