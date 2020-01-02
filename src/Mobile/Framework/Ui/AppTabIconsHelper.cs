using System.Collections.Generic;

namespace Mobile.Framework.Ui
{
	public static class TabIconsHelper
	{
		public static int Size = 24;
		public static IList<AppTab> GetTabs()
		{
			return new[]
			{
				new AppTab()
				{
					IconGlyph = AppIcons.Dashboard,
					IconSelectedGlyph = AppIcons.Dashboard2
				},
				new AppTab()
				{
					IconGlyph = AppIcons.BarChart,
					IconSelectedGlyph = AppIcons.BarChart2
				},
				new AppTab()
				{
					IconGlyph = AppIcons.Error,
					IconSelectedGlyph = AppIcons.Error2
				},
				new AppTab()
				{
					IconGlyph = AppIcons.Multichannel,
					IconSelectedGlyph = AppIcons.Multichannel2
				},
				new AppTab()
				{
					IconGlyph = AppIcons.Menu,
					IconSelectedGlyph = AppIcons.Menu2
				},
			};
		}

		public class AppTab
		{
			public string IconGlyph { get; set; }
			public string IconSelectedGlyph { get; set; }
		}
	}
}
