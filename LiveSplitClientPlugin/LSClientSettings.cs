using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Threading;

namespace LiveSplit.ClientPlugin
{
	public partial class LSClientSettings : UserControl
	{
		LSClientInstance instance;

		public LSClientSettings(LSClientInstance instance)
		{
			InitializeComponent();
			this.instance = instance;
			txtIPAddress.Text = instance.IPAddress;
			txtPort.Text = instance.Port.ToString();
			lblServerStatus.Text = instance.ServerStatus;
		}

		public XmlNode GetSettings(XmlDocument document)
		{
			XmlElement settingsNode = document.CreateElement("Settings");
			return settingsNode;
		}

		public void SetSettings(XmlNode settings)
		{
			
		}

		static XmlElement ToElement<T>(XmlDocument document, string name, T value)
		{
			XmlElement str = document.CreateElement(name);
			str.InnerText = value.ToString();
			return str;
		}

		private async void btnConnect_Click(object sender, EventArgs e)
		{
			instance.SaveConfiguration(txtIPAddress.Text, txtPort.Text, cbAutosplit.Checked);
			lblServerStatus.Text = "Attempting connection...";
			await instance.ConnectToServer();
			lblServerStatus.Text = instance.ServerStatus;
		}

		private void cbAutosplit_CheckedChanged(object sender, EventArgs e)
		{
			instance.SaveConfiguration(txtIPAddress.Text, txtPort.Text, cbAutosplit.Checked);
		}
	}
}
