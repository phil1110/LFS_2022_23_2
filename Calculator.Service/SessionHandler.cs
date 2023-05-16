using Calculator.Service.Contracts;
using Calculator.Shared;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calculator.Service.Shared
{
    /// <summary>
    /// Class that handles the communciation in the server with a single client.
    /// An isntance of the class is created for every connected client.
    /// </summary>
    internal class SessionHandler
    {
        protected readonly Socket _clientSocket;
        protected readonly SocketReader _reader;
        protected readonly SocketWriter _writer;
        protected readonly EndPoint _clientRemoteEndPoint;
        protected readonly IServerSubscriber _subscriber;
        protected string _clientId;

        internal SessionHandler(Socket clientSocket, IServerSubscriber subscriber)
        {
            _clientSocket = clientSocket;
            _reader = new SocketReader(clientSocket);
            _writer = new SocketWriter(clientSocket);
            _clientRemoteEndPoint = clientSocket.RemoteEndPoint;
            _subscriber = subscriber;
        }

        /// <summary>
        /// Handles allcommunication with a specific client
        /// </summary>
        internal virtual void HandleCommunication()
        {
            _clientId = _reader.ReceiveString();

            while (true)
			{
                Calculation calc = _reader.ReceiveCalculation();

				if (!calc.IsValid())
				{
                    ClientShutdown("Invalid Calculation!");
                    return;
				}

                _subscriber.Log($"{this.ToString()}: {calc.ToString()}");
                int result = Calculator.Calculate(calc);
                _writer.Send(Convert.ToString(result));
			}
        }

        /// <summary>
        /// Handles the end of a client session.
        /// At the end of a client session, the server sends a last message to the client.
        /// This message has a commonly known prefix and a optional text containing the reason the server has to finish the communication.
        /// After the message was sent, the client socket will be closed.
        /// </summary>
        /// <param name="reason"></param>
        protected void ClientShutdown(string reason = "")
        {
            StringBuilder textToSend = new StringBuilder(Consts.EXIT_PREFIX);
            if (!string.IsNullOrWhiteSpace(reason))
            {
                textToSend.Append(" - ");
                textToSend.Append(reason);
            }
            _writer.Send(textToSend.ToString());
            Task.Delay(100).Wait();
            _clientSocket.Shutdown(SocketShutdown.Both);
            _clientSocket.Close();
        }

        /// <summary>
        /// Creates a textual representation of the session
        /// </summary>
        /// <returns>The textual representation of the session containing the ID and the remoted endpoint</returns>
        public override string ToString()
        {
            return $"{_clientId} ({_clientRemoteEndPoint})";
        }
    }
}
