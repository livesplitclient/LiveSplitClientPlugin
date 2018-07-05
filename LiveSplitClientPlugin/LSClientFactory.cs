using LiveSplit.Model;
using LiveSplit.UI.Components;
using LiveSplit.LiveSplitClientPlugin;
using System;
using System.Reflection;

[assembly: ComponentFactory(typeof(LSClientFactory))]
namespace LiveSplit.LiveSplitClientPlugin
{
	internal class LSClientFactory : IComponentFactory
	{
		public string ComponentName => "Live Split Client";
		public string Description => "Live Split Client";
		public string UpdateName => ComponentName;

		public ComponentCategory Category => ComponentCategory.Timer;
		public string UpdateURL => "";
		public string XMLURL => UpdateURL + "";

		public Version Version => Assembly.GetExecutingAssembly().GetName().Version;

		public IComponent Create(LiveSplitState state)
		{
			return new LSClient(state);
		}
	}
}
