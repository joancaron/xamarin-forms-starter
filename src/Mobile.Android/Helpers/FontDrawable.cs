using System.Linq;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Util;

namespace Mobile.Droid.Helpers
{
	public class FontDrawable : Drawable
	{
		readonly TextPaint _paint = new TextPaint();

		readonly int _size;

		readonly string _text;

		int _alpha = 255;

		const string IconFont = "appmeta.ttf";

		public FontDrawable(Context context, string text, Color iconColor, int iconSizeDp)
		{
			_text = text;

			_paint.SetTypeface(Typeface.CreateFromAsset(context.Assets, IconFont));
			_paint.SetStyle(Paint.Style.Fill);
			_paint.TextAlign = Paint.Align.Center;
			_paint.Color = iconColor;
			_paint.AntiAlias = true;
			_size = GetPx(context, iconSizeDp);
			SetBounds(0, 0, _size, _size);
		}

		public override int IntrinsicHeight => _size;

		public override int IntrinsicWidth => _size;

		public override bool IsStateful => true;

		public override int Opacity => _alpha;

		public override void ClearColorFilter()
		{
			_paint.SetColorFilter(null);
		}

		public override void Draw(Canvas canvas)
		{
			_paint.TextSize = Bounds.Height();
			var textBounds = new Rect();
			_paint.GetTextBounds(_text, 0, 1, textBounds);
			var textHeight = textBounds.Height();
			var textBottom = Bounds.Top + (_paint.TextSize - textHeight) / 2f + textHeight - textBounds.Bottom;
			canvas.DrawText(_text, Bounds.ExactCenterX(), textBottom, _paint);
		}

		public override void SetAlpha(int alpha)
		{
			_alpha = alpha;
			_paint.Alpha = alpha;
		}

		public override void SetColorFilter(ColorFilter colorFilter)
		{
			_paint.SetColorFilter(colorFilter);
		}

		public override bool SetState(int[] stateSet)
		{
			var oldValue = _paint.Alpha;
			var newValue = stateSet.Any(s => s == Android.Resource.Attribute.StateEnabled)
				? _alpha
				: _alpha / 2;
			_paint.Alpha = newValue;
			return oldValue != newValue;
		}

		static int GetPx(Context context, int sizeDp)
		{
			return (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, sizeDp, context.Resources.DisplayMetrics);
		}

		static bool IsEnabled(int[] stateSet)
		{
			return stateSet.Any(s => s == Android.Resource.Attribute.StateEnabled);
		}
	}
}
