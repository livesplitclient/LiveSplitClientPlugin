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

namespace LiveSplit.LiveSplitClientPlugin
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
			lblServerStatus.Text = instance.serverReturnData;
		}

		public XmlNode GetSettings(XmlDocument document)
		{
			XmlElement settingsNode = document.CreateElement("Settings");
			settingsNode.AppendChild(ToElement(document, "IPAddress", txtIPAddress.Text));
			settingsNode.AppendChild(ToElement(document, "Port", txtPort.Text));
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

		private void btnConnect_Click(object sender, EventArgs e)
		{
			instance.SaveConfiguration(txtIPAddress.Text, txtPort.Text);
			instance.ConnectToServer();
			Thread.Sleep(100);
			lblServerStatus.Text = instance.serverReturnData;
		}
	}
}
