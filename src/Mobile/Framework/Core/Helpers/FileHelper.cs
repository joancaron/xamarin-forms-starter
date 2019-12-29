using System.IO;
using System.Reflection;

namespace Mobile.Framework.Core.Helpers
{
	static class FileHelper
	{
		internal static string ExtractAndSaveResourceFile(string filename, string location)
		{
			var a = Assembly.GetExecutingAssembly();
			using var resFilestream = a.GetManifestResourceStream(filename);

			if (resFilestream == null)
			{
				return null;
			}

			var fullPath = Path.Combine(location, filename);
			using var stream = File.Create(fullPath);
			resFilestream.CopyTo(stream);
			return fullPath;
		}
	}
}
