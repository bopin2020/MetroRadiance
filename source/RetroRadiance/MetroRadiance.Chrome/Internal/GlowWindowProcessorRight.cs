﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MetroRadiance.Core.Win32;
#pragma warning disable 612

namespace MetroRadiance.Chrome.Internal
{
	internal class GlowWindowProcessorRight : GlowWindowProcessor
	{
		public override Orientation Orientation => Orientation.Vertical;

		public override HorizontalAlignment HorizontalAlignment => HorizontalAlignment.Left;

		public override VerticalAlignment VerticalAlignment => VerticalAlignment.Stretch;

		public override double GetLeft(double ownerLeft, double ownerWidth)
		{
			return ownerLeft + ownerWidth;
		}

		public override double GetTop(double ownerTop, double ownerHeight)
		{
			return ownerTop - GlowSize;
		}

		public override double GetWidth(double ownerLeft, double ownerWidth)
		{
			return GlowSize;
		}

		public override double GetHeight(double ownerTop, double ownerHeight)
		{
			return ownerHeight + GlowSize * 2;
		}

		public override HitTestValues GetHitTestValue(Point point, double actualWidht, double actualHeight)
		{
			var rightTop = new Rect(0, 0, actualWidht, EdgeSize);
			var rightBottom = new Rect(0, actualHeight - EdgeSize, actualWidht, EdgeSize);

			return rightTop.Contains(point)
				? HitTestValues.HTTOPRIGHT
				: rightBottom.Contains(point) ? HitTestValues.HTBOTTOMRIGHT : HitTestValues.HTRIGHT;
		}

		public override Cursor GetCursor(Point point, double actualWidht, double actualHeight)
		{
			var rightTop = new Rect(0, 0, actualWidht, EdgeSize);
			var rightBottom = new Rect(0, actualHeight - EdgeSize, actualWidht, EdgeSize);

			return rightTop.Contains(point)
				? Cursors.SizeNESW
				: rightBottom.Contains(point) ? Cursors.SizeNWSE : Cursors.SizeWE;
		}
	}
}
