﻿using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Mobile.iOS.Helpers
{
	public static class ImageHelper
	{
		const string IconFont = "appmeta";
		public static UIImage ImageFromFont(
			string text,
			UIColor iconColor,
			CGSize iconSize)
		{
			UIGraphics.BeginImageContextWithOptions(iconSize, false, 0);

			var textRect = new CGRect(CGPoint.Empty, iconSize);
			var path = UIBezierPath.FromRect(textRect);
			UIColor.Clear.SetFill();
			path.Fill();

			var font = UIFont.FromName(IconFont, iconSize.Width);
			using (var label = new UILabel() {Text = text, Font = font})
			{
				GetFontSize(label, iconSize, 500, 5);
				font = label.Font;
			}

			iconColor.SetFill();
			using (var nativeString = new NSString(text))
			{
				nativeString.DrawString(
					textRect,
					new UIStringAttributes
					{
						Font = font,
						ForegroundColor = iconColor,
						BackgroundColor = UIColor.Clear,
						ParagraphStyle = new NSMutableParagraphStyle {Alignment = UITextAlignment.Center}
					});
			}

			var image = UIGraphics.GetImageFromCurrentImageContext();
			UIGraphics.EndImageContext();
			return image;
		}

		static void GetFontSize(UILabel label, CGSize size, int maxFontSize, int minFontSize)
		{
			label.Frame = new CGRect(CGPoint.Empty, size);
			var fontSize = maxFontSize;
			var constraintSize = new CGSize(label.Frame.Width, nfloat.MaxValue);
			while (fontSize > minFontSize)
			{
				label.Font = UIFont.FromName(label.Font.Name, fontSize);
				using (var nativeString = new NSString(label.Text))
				{
					var textRect = nativeString.GetBoundingRect(
						constraintSize,
						NSStringDrawingOptions.UsesFontLeading,
						new UIStringAttributes {Font = label.Font},
						null);

					if (textRect.Size.Height <= label.Frame.Height)
					{
						break;
					}
				}

				fontSize -= 2;
			}
		}
	}
}
