namespace Mobile.Framework.Core.Settings
{
	[Preserve(AllMembers = true)]
	public class AppConfiguration
	{
		public SyncfusionConfiguration Syncfusion { get; set; }
		public Stage Stage { get; set; }
		public AppCenterConfiguration AppCenter { get; set; }
		public bool IsInBackground { get; set; }

		public bool IsInDebugMode =
#if DEBUG
			true;
#else
            false;
#endif
	}
}
