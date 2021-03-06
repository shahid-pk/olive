// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
// Copyright (c) 2008 Novell, Inc. (http://www.novell.com)
//
// Author:
//	Chris Toshok (toshok@ximian.com)
//

using System.Windows;
using System.IO;

namespace System.Windows.Media {

	public sealed class SolidColorBrush : Brush {

		public static readonly DependencyProperty ColorProperty = DependencyProperty.Register ("Color", typeof (Color), typeof (SolidColorBrush),
												       new PropertyMetadata (Color.FromArgb (0, 255, 255, 255)));

		public Color Color {
		    get { return (Color)GetValue (ColorProperty); }
		    set { SetValue (ColorProperty, value); }
		}

		public SolidColorBrush ()
		{
		}

		public SolidColorBrush (Color color)
		{
			this.Color = color;
		}

		public new SolidColorBrush Clone ()
		{
			throw new NotImplementedException ();
		}

		public new SolidColorBrush CloneCurrentValue ()
		{
			throw new NotImplementedException ();
		}

		protected override Freezable CreateInstanceCore ()
		{
			return new SolidColorBrush ();
		}

		public static object DeserializeFrom (BinaryReader reader)
		{
			throw new NotImplementedException ();
		}
	}

}
