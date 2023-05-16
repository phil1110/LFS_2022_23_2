using Calculator.Service.Contracts;
using Calculator.Service.Shared;
using Calculator.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator.Service;

namespace Calculator.Service.GUI
{
    public partial class MainForm : Form, IServerSubscriber
    {
		Action<string> aLog;
		Action aClearLog;
		Action<ISession> aSetQuarantine;
		Server _server;

		public MainForm()
		{
			aLog = Log;
			aClearLog = ClearLog;
			aSetQuarantine = SetQuarantine;

			InitializeComponent();

			_server = new Server(this);
			Task.Run(() => _server.Run());
		}

		public void Log(string calc)
		{
			if (lbxLogs.InvokeRequired)
			{
				lbxLogs.Invoke(aLog, calc);
			}
			else
			{
				lbxLogs.Items.Insert(0, calc);
			}
		}

		public void SetQuarantine(ISession session)
		{
			if (lbxQuarantine.InvokeRequired)
			{
				lbxQuarantine.Invoke(aSetQuarantine, session);
			}
			else
			{
				lbxQuarantine.Items.Add(session);
			}
		}

		private void ClearLog()
		{
			if (lbxLogs.InvokeRequired)
			{
				lbxLogs.Invoke(aClearLog);
			}
			else
			{
				lbxLogs.Items.Clear();
			}
		}

		private void lbxLogs_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			Task.Run(() => ClearLog());
		}

		private void btnAllow_Click(object sender, EventArgs e)
		{
			ISession session = (ISession)lbxQuarantine.SelectedItem;
			Task.Run(() => session.Allow());

			lbxQuarantine.Items.Remove(session);
		}

		private void btnRefuse_Click(object sender, EventArgs e)
		{
			ISession session = (ISession)lbxQuarantine.SelectedItem;
			Task.Run(() => session.Refuse());

			lbxQuarantine.Items.Remove(session);
		}
	}
}
