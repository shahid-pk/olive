// Author:
//   Rolf Bjarne Kvinge  (RKvinge@novell.com)
//
// Copyright 2007 Novell, Inc.
//
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

using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;
using System.Runtime.InteropServices;
using Mono;

namespace System.Windows.Media.Animation {
	
	public struct KeyTime
	{
		private KeyTimeType type;
		private double percent;
		private TimeSpan time_span;
	
		internal KeyTime (KeyTimeType type, double percent, TimeSpan time_span)
		{
			this.type = type;
			this.percent = percent;
			this.time_span = time_span;
		}
		
		public static KeyTime FromPercent(double percent)
		{
			return new KeyTime (KeyTimeType.Percent, percent, TimeSpan.Zero);
		}
		
		public static KeyTime FromTimeSpan(TimeSpan timeSpan)
		{
			return new KeyTime (KeyTimeType.TimeSpan, 0, timeSpan);
		}
		
		public static KeyTime Uniform { 
			get { return new KeyTime (KeyTimeType.Uniform, 0, TimeSpan.Zero); }
		}
		
		public static KeyTime Paced { 
			get { return new KeyTime (KeyTimeType.Paced, 0, TimeSpan.Zero); }
		}
		
		public static bool Equals (KeyTime keyTime1, KeyTime keyTime2)
		{
			return keyTime1 == keyTime2;
		}
		
		public static bool operator ==(KeyTime keyTime1, KeyTime keyTime2)
		{
			if (keyTime1.type != keyTime2.type)
				return false;
			
			switch (keyTime1.type)
			{
			case KeyTimeType.Paced:
			case KeyTimeType.Uniform:
				return true;
			case KeyTimeType.Percent:
				return keyTime1.percent == keyTime2.percent;
			case KeyTimeType.TimeSpan:
				return keyTime1.time_span == keyTime2.time_span;
			}
			return false;
		}
		
		public static bool operator !=(KeyTime keyTime1, KeyTime keyTime2)
		{
			return !(keyTime1 == keyTime2);
		}
		
		public bool Equals(KeyTime value)
		{
			return this == value;
		}
		
		public override bool Equals(object value)
		{
			if (value is KeyTime)
				return this == (KeyTime) value;
			
			return false;
		}
		
		public override int GetHashCode()
		{
			switch (type)
			{
			case KeyTimeType.Paced:
			case KeyTimeType.Uniform:
				return type.GetHashCode ();
			case KeyTimeType.Percent:
				return percent.GetHashCode ();
			case KeyTimeType.TimeSpan:
				return time_span.GetHashCode ();
			default:
				return base.GetHashCode ();
			}
		}
		
		public override string ToString()
		{
			switch (type)
			{
			case KeyTimeType.Paced:
				return "Paced";
			case KeyTimeType.Uniform:
				return "Uniform";
			case KeyTimeType.Percent:
				return (percent * 100).ToString () + "%";
			case KeyTimeType.TimeSpan:
				return time_span.ToString ();
			default:
				return "KeyTime";
			}
		}
		
		public static implicit operator KeyTime(TimeSpan timeSpan)
		{
			return KeyTime.FromTimeSpan (timeSpan);
		}
		
		public TimeSpan TimeSpan { 
			get { return time_span; }
		}
		
		public double Percent { 
			get { return percent; }
		}
		
		public KeyTimeType Type { 
			get { return type; }
		}
	}
}