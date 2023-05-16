using Calculator.Service.Contracts;
using Calculator.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calculator.Service.Shared
{
    class QuarantineSessionHandler : SessionHandler, ISession
    {
        const int MAX_ALLOWED_CALCULATIONS = 3;
        private bool _refused;
        private bool _allowed;
        private readonly object _lockRefused = new object();
        private readonly object _lockAllowed = new object();

        internal QuarantineSessionHandler(Socket clientSocket, IServerSubscriber subscriber) : base(clientSocket, subscriber)
        {
            SetRefused(false);
            SetAllowed(false);
        }

        internal override void HandleCommunication()
        {
            SetRefused(false);
            SetAllowed(false);

            _clientId = _reader.ReceiveString();

			for (int i = 1; i <= MAX_ALLOWED_CALCULATIONS; i++)
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

                if(i == MAX_ALLOWED_CALCULATIONS)
				{
                    _subscriber.SetQuarantine(this);
                    _writer.Send("Session is in Quarantine");

                    while (_refused == false && _allowed == false)
					{
                        string received = _reader.ReceiveString();

                        _writer.Send("Session is in Quarantine");
					}

					if (_refused)
					{
                        ClientShutdown("Further Requests have been refused!");
                        return;
					}
					if (_allowed)
					{
                        this.HandleCommunication();
					}
				}
            }
        }
        public void Refuse()
        {
            SetRefused(true);
        }

        public void Allow()
        {
            SetAllowed(true);
        }

        private void SetRefused(bool value)
		{
			lock (_lockRefused)
			{
                _refused = value;
            }
		}
        private void SetAllowed(bool value)
        {
			lock (_lockAllowed)
			{
                _allowed = value;
            }
        }
    }
}
