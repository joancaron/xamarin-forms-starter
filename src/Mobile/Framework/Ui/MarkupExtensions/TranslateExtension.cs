using System;
using System.Globalization;
using EnsureThat;
using Mobile.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Framework.Ui
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
	    public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
	        EnsureArg.IsNotNullOrWhiteSpace(this.Text);
	        var value = AppResources.ResourceManager.GetString(this.Text, CultureInfo.CurrentUICulture);
	        return string.IsNullOrWhiteSpace(value) ? "[NOT TRANSLATED]" : value;
        }
    }
}
