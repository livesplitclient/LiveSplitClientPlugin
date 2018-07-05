using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Xml;

namespace LiveSplit.LiveSplitClientPlugin
{
	public class LSClient : LogicComponent
	{
		public override string ComponentName => "Live Split Client";
		private LiveSplitState state;
		private LSClientSettings settings;
		private LSClientInstance instance;

		public int IGT { get; set; }

		public LSClient(LiveSplitState state)
		{
			instance = new LSClientInstance();
			settings = new LSClientSettings(instance);

			this.state = state;
			this.state.IsGameTimePaused = true;
		}

		public override void Dispose()
		{
			instance.Disconnect();
		}

		public override XmlNode GetSettings(XmlDocument document)
		{
			return settings.GetSettings(document);
		}

		public override System.Windows.Forms.Control GetSettingsControl(LayoutMode mode)
		{
			return settings;
		}

		public override void SetSettings(XmlNode settings)
		{
			this.settings.SetSettings(settings);
		}

		public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
		{
			state.SetGameTime(new TimeSpan(0,0,0,0, instance.IGT));
		}
	}
}
