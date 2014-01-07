using _ScaviDataModel;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Spatial;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml.Linq;


namespace _ScaviDal
{
    public class Class1
    {
        public static void Main(String[] args)
        {
            FilePointOfInterestGetter dal = new FilePointOfInterestGetter();
            List<PointOfInterest> list = dal.GetPointsOfInterest();

            Console.WriteLine(list.Count);
            Console.ReadKey();

        }
    //        String line;
    //        try
    //        {
    //            //Pass the file path and file name to the StreamReader constructor
    //            StreamReader sr = new StreamReader(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/GeoRssFile1.xml");
    //            XNamespace aw = "http://www.adventure-works.com";
    //            XNamespace aw2 = "http://www.adventure-works.com";
    //            XNamespace georss1 = XNamespace.Get("http://www.georss.org/georss");
    //            XNamespace xmlns = XNamespace.Get("http://www.w3.org/2005/Atom");
    //            List<XNamespace> namespacesList = new List<XNamespace>();

    //            List<XAttribute> attributes = new List<XAttribute>();
    //            attributes.Add(new XAttribute("xmlns", xmlns));
    //            attributes.Add(new XAttribute(XNamespace.Xmlns + "georss", georss1));
    //            XElement xmlTree = new XElement("Root",
    //                new XAttribute(XNamespace.Xmlns + "georss", georss1),
    //                new XElement("Child",
    //                    new XText("Some text"),
    //                    new XElement("GrandChild", "element content")
    //                )
    //            );

    //            IEnumerable<XElement> de =
    //from el in xmlTree.Descendants("Child")
    //select el;
    //            //Console.WriteLine(xmlTree.ToString());
    //            foreach (XElement el in de)
    //                Console.WriteLine(el.Name);


    //            XDocument document = XDocument.Load(sr);
    //            XElement mainel = document.Root;
    //            XNamespace space = document.Root.GetDefaultNamespace();
    //            IEnumerable<XElement> de2 =
    //from el in mainel.Descendants("entry")
    //select el;
    //                                    List<GeoCoordinate> coor = new List<GeoCoordinate>();
    //                            PointCollection coll = new PointCollection();
    //                            GeoPolygon poly = new GeoPolygon();
    //                            GeoPolygon polymargin = new GeoPolygon();

    //            foreach (XElement el in de2)
    //            {
    //                if (el.Element(georss1+"polygon")!=null)
    //                {
    //                    List<String> str = el.Element(georss1 + "polygon").Value.Split(' ').ToList();
    //                    for (int i=0; i<str.Count; i=i+2)
    //                    {
    //                        Double lat = Double.Parse(str.ElementAt(i), CultureInfo.InvariantCulture);
    //                        Double lon = Double.Parse(str.ElementAt(i + 1), CultureInfo.InvariantCulture);

    //                        coor.Add(new GeoCoordinate(lat, lon));
    //                        coll.Add(new Point(lat, lon));
    //                        poly.Add(new GeoCoordinate(lat, lon));

    //                        Console.WriteLine(coor.ElementAt(i/2).Latitude);

    //                    }
    //                    Console.WriteLine();
    //                }
                    
    //            }
    //            foreach (XElement el in de2)
    //            {
    //                if (el.Element("margin")!=null)
    //                {
    //                    List<String> str = el.Element("margin").Value.Split(' ').ToList();
    //                    List<Boolean> margin = new List<bool>();
    //                    foreach (String s in str)
    //                    {
    //                        if (s=="Y")
    //                        {
    //                            margin.Add(true);
    //                        }
    //                        else
    //                        {
    //                            margin.Add(false);
    //                        }
    //                    }

    //                    foreach (Boolean m in margin)
    //                    {
    //                        int polyLength = poly.points.Count;
    //                        int polyIndex = 0;
    //                        if (m)
    //                        {
    //                            polymargin.Add(GetFixedCoordinate(poly.GetCenter(), poly.points.ElementAt(polyIndex)));
    //                            polymargin.Add(GetFixedCoordinate(poly.GetCenter(), poly.points.ElementAt(polyIndex + 1)));

    //                        }
    //                        else
    //                        {

    //                            polymargin.Add(poly.points.ElementAt(polyIndex));
    //                            polymargin.Add(poly.points.ElementAt(polyIndex + 1));
    //                        }
    //                        polyIndex++;
    //                    }
    //                }
    //            }

    //            Console.WriteLine(poly.GetCenter());

    //            Console.WriteLine(poly.IncludePoint(new GeoCoordinate(46.46,-109.47)));
    //            Console.WriteLine(poly.IncludePoint(new GeoCoordinate(86.46, -109.48)));
    //            Console.WriteLine(poly.IncludePoint(new GeoCoordinate(44.46, -109.78)));
    //            Console.WriteLine(polymargin.IncludePoint(new GeoCoordinate(44.460020, -109.47)));
    //            Console.WriteLine(polymargin.IncludePoint(new GeoCoordinate(86.46, -109.48)));
    //            Console.WriteLine(polymargin.IncludePoint(new GeoCoordinate(44.460010, -109.78)));
    //            Console.WriteLine(polymargin.IncludePoint(new GeoCoordinate(46.46, -109.48)));
    //            Console.WriteLine(polymargin.IncludePoint(new GeoCoordinate(46.460005, -109.480005)));
    //            Console.WriteLine(polymargin.IncludePoint(new GeoCoordinate(46.460005, -109.479995)));
    //            Console.WriteLine(polymargin.IncludePoint(new GeoCoordinate(46.459995, -109.480005)));
    //            Console.WriteLine(polymargin.IncludePoint(new GeoCoordinate(46.459995, -109.479995)));

               
    //            XNamespace georss = XNamespace.Get("http://www.georss.org/georss");
    //            XNamespace xmlns1 = XNamespace.Get("http://www.w3.org/2005/Atom");

    //            IEnumerable<XElement> elements1 = document.Root.Descendants("entry" + space + georss).ToList();

    //            IEnumerable<XElement> elements211 = document.Descendants("entry" + georss).ToList();

    //            IEnumerable<XElement> elements3 = document.Elements("entry").ToList();

    //            IEnumerable<XElement> elements = document.Root.Elements("entry").ToList();
    //            //elements.ForEach(entry => Console.WriteLine(entry.Value));

    //            List<String> event1 = elements.Select(n => n.ToString()).ToList();

    //            //Read the first line of text

    //            //Continue to read until you reach end of file
    //            foreach (String ev in event1)
    //            {
    //                //write the lie to console window
    //                Console.WriteLine(ev);
    //                //Read the next line
    //                line = sr.ReadLine();
    //            }

    //            //close the file
    //            sr.Close();
    //            Console.ReadLine();
    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine("Exception: " + e.Message);
    //        }
    //        finally
    //        {
    //            Console.WriteLine("Executing finally block.");
    //        }

    //        Console.ReadKey();
    //    }


    //    public static GeoCoordinate GetFixedCoordinate(GeoCoordinate center, GeoCoordinate vertex)
    //    {
    //        double x1, x2, y1, y2;
    //        x1 = center.Latitude;
    //        y1 = center.Longitude;
    //        x2 = vertex.Latitude;
    //        y2 = vertex.Longitude;

    //        double XCoeff, AdditionalCoeff;
    //        if ((x2-x1)!=0)
    //        {
    //            XCoeff = (y2 - y1) / (x2 - x1);
    //            AdditionalCoeff = (((-x1) * (y2 - y1)) / (x2 - x1)) + y1;
    //        }
    //        else
    //        {
    //            XCoeff = 0;
    //            AdditionalCoeff = 0;
    //        }

    //        double xToBack;
    //        if (vertex.Latitude>center.Latitude)
    //        {
    //            xToBack = vertex.Latitude + 0.000010d;
    //        }
    //        else if (vertex.Latitude<center.Latitude)
    //        {
    //            xToBack = vertex.Latitude - 0.000010d;
    //        }
    //        else
    //        {
    //            xToBack = vertex.Latitude;
    //        }
    //        double yToBack = XCoeff * xToBack + AdditionalCoeff;

    //        return new GeoCoordinate(xToBack, yToBack);
    //    }

    }
}
