
/* this file is generated by gen-animation-types.cs.  do not modify */

using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Markup;

namespace System.Windows.Media.Animation {


public class SingleKeyFrameCollection : Freezable, IList, ICollection, IEnumerable
{
	public SingleKeyFrameCollection ()
	{
	}

	public int Count {
		get { throw new NotImplementedException (); }
	}

	public static SingleKeyFrameCollection Empty {
		get { throw new NotImplementedException (); }
	}

	public bool IsFixedSize {
		get { throw new NotImplementedException (); }
	}

	public bool IsReadOnly {
		get { throw new NotImplementedException (); }
	}

	public bool IsSynchronized {
		get { throw new NotImplementedException (); }
	}

	public object SyncRoot {
		get { throw new NotImplementedException (); }
	}

	public SingleKeyFrame this[int index] {
		get { throw new NotImplementedException (); }
		set { throw new NotImplementedException (); }
	}

	object IList.this[int index] {
		get { return this[index]; }
		set { this[index] = (SingleKeyFrame)value; }
	}

	public int Add (SingleKeyFrame keyFrame)
	{
		throw new NotImplementedException ();
	}

	int IList.Add (object value)
	{
		return Add ((SingleKeyFrame) value);
	}

	public void Clear ()
	{
		throw new NotImplementedException ();
	}

	public new SingleKeyFrameCollection Clone ()
	{
		throw new NotImplementedException ();
	}

	protected override void CloneCore (Freezable sourceFreezable)
	{
		throw new NotImplementedException ();
	}

	protected override void CloneCurrentValueCore (Freezable sourceFreezable)
	{
		throw new NotImplementedException ();
	}

	public bool Contains (SingleKeyFrame keyFrame)
	{
		throw new NotImplementedException ();
	}

	bool IList.Contains (object value)
	{
		return Contains ((SingleKeyFrame)value);
	}

	public void CopyTo (SingleKeyFrame[] array, int index)
	{
		throw new NotImplementedException ();
	}

	void ICollection.CopyTo (Array array, int index)
	{
		CopyTo ((SingleKeyFrame[])array, index);
	}

	protected override Freezable CreateInstanceCore ()
	{
		throw new NotImplementedException ();
	}

	protected override bool FreezeCore (bool isChecking)
	{
		throw new NotImplementedException ();
	}

	protected override void GetAsFrozenCore (Freezable sourceFreezable)
	{
		throw new NotImplementedException ();
	}

	protected override void GetCurrentValueAsFrozenCore (Freezable sourceFreezable)
	{
		throw new NotImplementedException ();
	}

	public IEnumerator GetEnumerator()
	{
		throw new NotImplementedException ();
	}

	public int IndexOf (SingleKeyFrame keyFrame)
	{
		throw new NotImplementedException ();
	}

	int IList.IndexOf (object value)
	{
		return IndexOf ((SingleKeyFrame) value);
	}

	public void Insert (int index, SingleKeyFrame keyFrame)
	{
		throw new NotImplementedException ();
	}

	void IList.Insert (int index, object value)
	{
		Insert (index, (SingleKeyFrame)value);
	}

	public void Remove (SingleKeyFrame keyFrame)
	{
		throw new NotImplementedException ();
	}

	void IList.Remove (object value)
	{
		Remove ((SingleKeyFrame) value);
	}

	public void RemoveAt (int index)
	{
		throw new NotImplementedException ();
	}
}


}