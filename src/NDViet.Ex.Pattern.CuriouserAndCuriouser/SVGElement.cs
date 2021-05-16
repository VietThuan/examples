using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NDViet.Ex.Pattern.CuriouserAndCuriouser
{
	public abstract class SVGElement<T> : ISVGElement where T : SVGElement<T>
	{
		public static readonly XNamespace SVGNameSpace = @"http://www.w3.org/2000/svg";

		public virtual XElement XElement { get; private set; }


		public SVGElement()
		{
			XElement = new XElement(SVGNameSpace + NodeName);
		}

		public abstract string NodeName { get; }

		public T Attribute(string key, string value)
		{
			var attribute = XElement.Attribute(key);
			if (attribute != null)
			{
				attribute.Value = value;
			}
			else
			{
				XElement.Add(new XAttribute(key, value));
			}
			return (T)this;
		}

		public string Attribute(string key)
		{
			var attribute = XElement.Attribute(key);
			if (attribute != null)
				return attribute.Value;
			return null;
		}

		public T Fill(string color)
		{
			return Attribute("fill", color);
		}

		public T Stroke(string color)
		{
			return Attribute("stroke", color);
		}

		public T StrokeWidth(int width)
		{
			return Attribute("stroke-width", width.ToString());
		}
	}
}
