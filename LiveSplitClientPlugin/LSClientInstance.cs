using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Xml;
using System.Xml.Linq;

namespace LiveSplit.ClientPlugin
{
	public class LSClientInstance
	{
		DispatcherTimer t;
		DateTime start;
		TcpClient client;

		public static string AppDataRoamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\LiveSplitClient";
		public static string ConfigurationFile = AppDataRoamingPath + @"\Config.xml";

		public string ServerReturnData { get; set; }
		public string ServerStatus { get; set; }
		public string IPAddress { get; set; }
		public int Port { get; set; }
		public bool Autosplit { get; set; }
		public int SplitIndex { get; set; }

		public int IGT
		{
			get
			{
				return TimeStringToMili(ServerReturnData);
			}
		}
	
		public LSClientInstance()
		{
			t = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 10), DispatcherPriority.Background, t_Tick, Dispatcher.CurrentDispatcher);
			SplitIndex = 0;
			start = DateTime.Now;
			CreateConfiguration();
			VerifyConfig();
			ReadConfiguration();
			ConnectToServer();
		}

		private void t_Tick(object sender, EventArgs e)
		{
			try
			{
				StreamWriter sw = new StreamWriter(client.GetStream());
				StreamReader sr = new StreamReader(client.GetStream());
				sw.WriteLine("getcurrenttime");
				sw.Flush();
				ServerReturnData = sr.ReadLine();
				sw.WriteLine("getsplitindex");
				sw.Flush();
				SplitIndex = int.Parse(sr.ReadLine());
			}
			catch
			{
				ServerStatus = "Error";
			}
		}

		public int TimeStringToMili(string time)
		{
			if(time == null)
			{
				return 0;
			}

			if (Regex.Matches(time, @"[a-zA-Z]").Count > 0)
			{
				return 0;
			}

			int milliseconds = 0;
			int seconds = 0;
			int minutes = 0;
			int hours = 0;

			switch(time.Count(f => f == ':'))
			{
				case 0:
					seconds = int.Parse(time.Substring(0, time.IndexOf('.')));
					time = time.Substring(time.IndexOf('.') + 1);
					milliseconds = 10 * int.Parse(time);
					break;
				case 1:
					minutes = int.Parse(time.Substring(0, time.IndexOf(':')));
					time = time.Substring(time.IndexOf(':') + 1);
					seconds = int.Parse(time.Substring(0, time.IndexOf('.')));
					time = time.Substring(time.IndexOf('.') + 1);
					milliseconds = 10 * int.Parse(time);
					break;
				case 2:
					hours = int.Parse(time.Substring(0, time.IndexOf(':')));
					time = time.Substring(time.IndexOf(':') + 1);
					minutes = int.Parse(time.Substring(0, time.IndexOf(':')));
					time = time.Substring(time.IndexOf(':') + 1);
					seconds = int.Parse(time.Substring(0, time.IndexOf('.')));
					time = time.Substring(time.IndexOf('.') + 1);
					milliseconds = 10 * int.Parse(time);
					break;
			}

			milliseconds = milliseconds +(hours * 60 * 60 * 1000) + (minutes * 60 * 1000) + (seconds * 1000);

			return milliseconds;
		}

		public void CreateConfiguration()
		{
			if (!File.Exists(ConfigurationFile))
			{
				Directory.CreateDirectory(AppDataRoamingPath);
				XmlTextWriter Writer = new XmlTextWriter(ConfigurationFile, Encoding.UTF8);
				Writer.Formatting = Formatting.Indented;
				Writer.WriteStartElement("Configs");

				Writer.WriteStartElement("IPAddress");
				Writer.WriteString("0.0.0.0");
				Writer.WriteEndElement();

				Writer.WriteStartElement("Port");
				Writer.WriteString("16834");
				Writer.WriteEndElement();

				Writer.WriteStartElement("Autosplit");
				Writer.WriteString("False");
				Writer.WriteEndElement();

				Writer.WriteEndElement();
				Writer.Close();
			}
		}

		public void ReadConfiguration()
		{
			if (File.Exists(ConfigurationFile))
			{
				XDocument xml = XDocument.Load(ConfigurationFile);
				XElement ipElement = xml.Element("Configs").Element("IPAddress");
				IPAddress = ipElement.Value;
				XElement portElement = xml.Element("Configs").Element("Port");
				Port = int.Parse(portElement.Value);
				XElement autoSplitElement = xml.Element("Configs").Element("Autosplit");
				Autosplit = bool.Parse(autoSplitElement.Value);
			}
		}


		private void VerifyConfig()
		{
			XDocument xml = XDocument.Load(ConfigurationFile);
			XElement ipElement = xml.Element("Configs").Element("IPAddress");
			XElement portElement = xml.Element("Configs").Element("Port");
			XElement autoSplitElement = xml.Element("Configs").Element("Autosplit");
			if (ipElement == null)
			{
				xml.Descendants("Configs").FirstOrDefault().Add(new XElement("IPAddress","0.0.0.0"));
			}
			if (portElement == null)
			{
				xml.Descendants("Configs").FirstOrDefault().Add(new XElement("Port", "16834"));
			}
			if (autoSplitElement == null)
			{
				xml.Descendants("Configs").FirstOrDefault().Add(new XElement("Autosplit", "False"));
			}
			xml.Save(ConfigurationFile);
		}

		public void SaveConfiguration(string ip, string port, bool autoSplit)
		{
			XDocument xml = XDocument.Load(ConfigurationFile);
			xml.Element("Configs").Element("IPAddress").Value = ip;
			xml.Element("Configs").Element("Port").Value = port.ToString();
			xml.Element("Configs").Element("Autosplit").Value = autoSplit.ToString();
			xml.Save(ConfigurationFile);
			ReadConfiguration();
		}

		public async Task ConnectToServer()
		{
			try
			{
				if(client != null)
				{
					client.Close();
				}
				client = new TcpClient();
				await client.ConnectAsync(IPAddress, Port);
				ServerStatus = "Connected";
				t.IsEnabled = true;
			}
			catch
			{
				ServerStatus = "Connection Error\nPlease check settings and restart LiveSplit server";
				t.IsEnabled = false;
			}
		}

		public void Disconnect()
		{

		}
	}
}
