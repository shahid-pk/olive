//
// Authors:
//   Atsushi Enomoto
//
// Copyright 2007 Novell (http://www.novell.com)
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
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace System.Xml.Linq
{
	public class XAttribute : XObject
	{
		static readonly XAttribute [] empty_array = new XAttribute [0];

		public static IEnumerable <XAttribute> EmptySequence {
			get { return empty_array; }
		}

		XName name;
		string value;
		XAttribute next;
		XAttribute previous;

		public XAttribute (XAttribute other)
		{
			if (other == null)
				throw new ArgumentNullException ("other");
			name = other.name;
			value = other.value;
		}

		public XAttribute (XName name, object value)
		{
			if (name == null)
				throw new ArgumentNullException ("name");
			this.name = name;
			SetValue (value);
		}

		public bool IsNamespaceDeclaration {
			get { return name.Namespace == XNamespace.Xmlns || (name.LocalName == "xmlns" && name.Namespace == XNamespace.Blank); }
		}

		public XName Name {
			get { return name; }
		}

		public XAttribute NextAttribute {
			get { return next; }
			internal set { next = value; }
		}

		public override XmlNodeType NodeType {
			get { return XmlNodeType.Attribute; }
		}

		public XAttribute PreviousAttribute {
			get { return previous; }
			internal set { previous = value; }
		}

		public string Value {
			get { return XUtil.ToString (value); }
			set { this.value = value; }
		}

		public void Remove ()
		{
			if (Parent != null) {
				if (next != null)
					next.previous = previous;
				if (previous != null)
					previous.next = next;
				if (Parent.FirstAttribute == this)
					Parent.FirstAttribute = next;
				if (Parent.LastAttribute == this)
					Parent.LastAttribute = previous;
				SetOwner (null);
			}
			next = null;
			previous = null;
		}

		public void SetValue (object value)
		{
			if (value == null)
				throw new ArgumentNullException ("value");
			this.value = XUtil.ToString (value);
		}

		static readonly char [] escapeChars = new char [] {'<', '>', '&', '"'};

		public override string ToString ()
		{
			StringBuilder sb = new StringBuilder ();
			sb.Append (name.ToString ());
			sb.Append ("=\"");
			int start = 0;
			do {
				int idx = value.IndexOfAny (escapeChars, start);
				if (idx < 0) {
					if (start > 0)
						sb.Append (value, start, value.Length - start);
					else
						sb.Append (value);
					sb.Append ("\"");
					return sb.ToString ();
				}
				sb.Append (value, start, idx - start);
				switch (value [idx]) {
				case '&': sb.Append ("&amp;"); break;
				case '<': sb.Append ("&lt;"); break;
				case '>': sb.Append ("&gt;"); break;
				case '"': sb.Append ("&quot;"); break;
				}
				start = idx + 1;
			} while (true);
		}
	}
}
