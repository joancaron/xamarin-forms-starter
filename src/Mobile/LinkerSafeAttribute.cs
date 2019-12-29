using System;
using System.ComponentModel;

namespace Mobile
{
	[AttributeUsage(AttributeTargets.Assembly)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class LinkerSafeAttribute : Attribute
	{
		public LinkerSafeAttribute()
		{
		}
	}
}
