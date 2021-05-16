using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDViet.Ex.Pattern.CuriouserAndCuriouser
{
	public class SVGSquare : SVGElement<SVGSquare>
	{
		public SVGSquare X(int x)
		{
			return Attribute("x", x.ToString());
		}

		public SVGSquare Y(int y)
		{
			return Attribute("y", y.ToString());
		}

		public SVGSquare Width(int width)
		{
			return Attribute("width", width.ToString());
		}

		public SVGSquare Height(int height)
		{
			return Attribute("height", height.ToString());
		}

		public override string NodeName
		{
			get { return "rect"; }
		}
	}

	public class SVGPolyLine : SVGElement<SVGPolyLine>
	{

		public SVGPolyLine Add(int x, int y)
		{
			var pointsString = Attribute("points") ?? "";
			pointsString = pointsString + string.Format(" {0},{1}", x, y);
			return Attribute("points", pointsString.Trim());
		}


		public override string NodeName
		{
			get { return "polyline"; }
		}
	}
}
