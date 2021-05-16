using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace NDViet.Ex.Pattern.CuriouserAndCuriouser
{
    class Program
    {
        static void Main(string[] args)
        {
            SVGSquare rect = new SVGSquare()
                .StrokeWidth(2)     //defined on SVGElement, returns an SVGSquare
                .Fill("blue")      //defined on SVGElement, returns an SVGSquare
                .X(30)              //defined on SVGSquare, returns an SVGSquare
                .Y(30)              //defined on SVGSquare, returns an SVGSquare
                .Width(100)         //defined on SVGSquare, returns an SVGSquare
                .Height(100);        //defined on SVGSquare, returns an SVGSquare



            var line = new SVGPolyLine()
               .StrokeWidth(2)      //defined on SVGElement, returns an SVGPolyLine
               .Stroke("blue")      //defined on SVGElement, returns an SVGPolyLine
               .Add(200, 200)       //defined on SVGPolyLine, returns an SVGPolyLine
               .Add(250, 300)       //defined on SVGPolyLine, returns an SVGPolyLine
               .Add(200, 300);      //defined on SVGPolyLine, returns an SVGPolyLine


            output(@"c:\mysvg.svg", rect, line); //writes our two objects to an SVG file
        }

        public static void output(string fileName, params ISVGElement[] elements)
        {
            XNamespace ns = @"http://www.w3.org/2000/svg";
            var root = new XElement(ns + "svg");

            root.Add(new XAttribute("version", "1.1"));
            root.Add(elements.Select(e => e.XElement).ToArray());
            using (XmlWriter writer = XmlWriter.Create(fileName))
            {
                root.WriteTo(writer);
            }
        }
    }


}
