
/* this file is generated by gen-animation-types.cs.  do not modify */

using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Markup;

namespace System.Windows.Media.Animation {


public abstract class BooleanKeyFrame : Freezable, IKeyFrame
{
	public static readonly DependencyProperty KeyTimeProperty
				= DependencyProperty.Register ("KeyTime", typeof (KeyTime), typeof (BooleanKeyFrame));

	public static readonly DependencyProperty ValueProperty
				= DependencyProperty.Register ("Value", typeof (bool), typeof (BooleanKeyFrame));

	protected BooleanKeyFrame ()
	{
	}

	protected BooleanKeyFrame (bool value)
	{
	}

	protected BooleanKeyFrame (bool value, KeyTime keyTime)
	{
	}

	public KeyTime KeyTime {
		get { return (KeyTime)GetValue (KeyTimeProperty); }
		set { SetValue (KeyTimeProperty, value); }
	}

	public bool Value {
		get { return (bool)GetValue (ValueProperty); }
		set { SetValue (ValueProperty, value); }
	}

	object IKeyFrame.Value {
		get { return Value; }
		set { Value = (bool)value; }
	}

	public bool InterpolateValue (bool baseValue, double keyFrameProgress)
	{
		throw new NotImplementedException ();
	}

	protected abstract bool InterpolateValueCore (bool baseValue, double keyFrameProgress);
}


}
