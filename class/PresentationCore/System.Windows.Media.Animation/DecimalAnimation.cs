
/* this file is generated by gen-animation-types.cs.  do not modify */

using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Markup;

namespace System.Windows.Media.Animation {


public class DecimalAnimation : DecimalAnimationBase
{
	public static readonly DependencyProperty ByProperty; /* XXX initialize */
	public static readonly DependencyProperty FromProperty; /* XXX initialize */
	public static readonly DependencyProperty ToProperty; /* XXX initialize */

	public DecimalAnimation ()
	{
	}

	public DecimalAnimation (Decimal toValue, Duration duration)
	{
	}

	public DecimalAnimation (Decimal toValue, Duration duration, FillBehavior fillBehavior)
	{
	}

	public DecimalAnimation (Decimal fromValue, Decimal toValue, Duration duration)
	{
	}

	public DecimalAnimation (Decimal fromValue, Decimal tovalue, Duration duration, FillBehavior fillBehavior)
	{
	}

	public Decimal? By {
		get { return (Decimal?) GetValue (ByProperty); }
		set { SetValue (ByProperty, value); }
	}

	public Decimal? From {
		get { return (Decimal?) GetValue (FromProperty); }
		set { SetValue (FromProperty, value); }
	}

	public Decimal? To {
		get { return (Decimal?) GetValue (ToProperty); }
		set { SetValue (ToProperty, value); }
	}

	public bool IsAdditive {
		get { return (bool) GetValue (AnimationTimeline.IsAdditiveProperty); }
		set { SetValue (AnimationTimeline.IsAdditiveProperty, value); }
	}

	public bool IsCumulative {
		get { return (bool) GetValue (AnimationTimeline.IsCumulativeProperty); }
		set { SetValue (AnimationTimeline.IsCumulativeProperty, value); }
	}

	public new DecimalAnimation Clone ()
	{
		throw new NotImplementedException ();
	}

	protected override Freezable CreateInstanceCore ()
	{
		throw new NotImplementedException ();
	}

	protected override Decimal GetCurrentValueCore (Decimal defaultOriginValue, Decimal defaultDestinationValue, AnimationClock animationClock)
	{
		throw new NotImplementedException ();
	}
}


}