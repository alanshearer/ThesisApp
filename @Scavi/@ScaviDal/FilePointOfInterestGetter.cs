﻿using _ScaviDataModel;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _ScaviDal
{
    public class FilePointOfInterestGetter : IPointOfInterest
    {

        public PointOfInterest GetPointOfInterestByPosition(GeoCoordinate coordinate)
        {
            List<PointOfInterest> pois = GetPointsOfInterest();
            foreach (PointOfInterest poi in pois)
            {
                if (poi.Polygon.IncludePoint(coordinate))
                {
                    return poi;
                }
            }

            return null;
        }

        public List<PointOfInterest> GetPointsOfInterest()
        {
            List<PointOfInterest> listToBack = new List<PointOfInterest>();

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/GeoRssFile1.xml");
              
                XNamespace georss = XNamespace.Get("http://www.georss.org/georss");
                
                XDocument document = XDocument.Load(sr);
                XElement mainel = document.Root;
                IEnumerable<XElement> elements = from el in mainel.Descendants("entry") select el;
               

                foreach (XElement el in elements)
                {
                    String name="", summary="";
                    Uri url= null;
                    PointOfInterestType tipology=null;
                    GeoPolygon realpolygon = new GeoPolygon();
                    GeoPolygon realpolygonwithmargin = new GeoPolygon();
               
                    if (el.Element("name")!=null)
                    {
                        name = el.Element("name").Value;
                    }

                    if (el.Element("summary") != null)
                    {
                        summary = el.Element("summary").Value;
                    }

                    if (el.Element("url") != null)
                    {
                        String tempurl = el.Element("url").Value;
                        url = UtilityDal.GetUriFromString(tempurl);
                    }

                    if (el.Element("tipology") != null)
                    {
                        String temptipology = el.Element("tipology").Value;
                        tipology = UtilityDal.GetTypeFromString(temptipology);
                    }

                    if (el.Element(georss + "polygon") != null)
                    {
                        List<String> elementcoordinateStrings = el.Element(georss + "polygon").Value.Split(' ').ToList();
                        for (int i = 0; i < elementcoordinateStrings.Count; i = i + 2)
                        {
                            Double lat = Double.Parse(elementcoordinateStrings.ElementAt(i), CultureInfo.InvariantCulture);
                            Double lon = Double.Parse(elementcoordinateStrings.ElementAt(i + 1), CultureInfo.InvariantCulture);


                            realpolygon.Add(new GeoCoordinate(lat, lon));


                        }
                        GeoCoordinate center = realpolygon.GetCenter();
                        if (el.Element("margin") != null)
                        {
                            List<String> elementmarginStrings = el.Element("margin").Value.Split(' ').ToList();
                            List<Boolean> margin = new List<bool>();
                            foreach (String s in elementmarginStrings)
                            {
                                if (s == "Y")
                                {
                                    margin.Add(true);
                                }
                                else
                                {
                                    margin.Add(false);
                                }
                            }

                            foreach (Boolean m in margin)
                            {
                               
                                int polyLength = realpolygon.points.Count;
                                int polyIndex = 0;
                                if (m)
                                {
                                    realpolygonwithmargin.Add(GetFixedCoordinate(center, realpolygon.points.ElementAt(polyIndex)));
                                    realpolygonwithmargin.Add(GetFixedCoordinate(center, realpolygon.points.ElementAt(polyIndex + 1)));

                                }
                                else
                                {

                                    realpolygonwithmargin.Add(realpolygon.points.ElementAt(polyIndex));
                                    realpolygonwithmargin.Add(realpolygon.points.ElementAt(polyIndex + 1));
                                }
                                polyIndex++;
                            }
                        }
                    }

                    PointOfInterest tempPoint = new PointOfInterest{ name = name, uripage = url, summary = summary, type= tipology, Polygon = realpolygonwithmargin, center = realpolygon.GetCenter()};
                    listToBack.Add(tempPoint);

                }

                sr.Close();

                return listToBack;
            }
            catch (Exception e)
            {
            }
            return listToBack;

        }

        public GeoCoordinate GetFixedCoordinate(GeoCoordinate center, GeoCoordinate vertex)
        {
            double x1, x2, y1, y2;
            x1 = center.Latitude;
            y1 = center.Longitude;
            x2 = vertex.Latitude;
            y2 = vertex.Longitude;

            double XCoeff, AdditionalCoeff;
            if ((x2 - x1) != 0)
            {
                XCoeff = (y2 - y1) / (x2 - x1);
                AdditionalCoeff = (((-x1) * (y2 - y1)) / (x2 - x1)) + y1;
            }
            else
            {
                XCoeff = 0;
                AdditionalCoeff = 0;
            }

            double xToBack;
            if (vertex.Latitude > center.Latitude)
            {
                xToBack = vertex.Latitude + 0.000010d;
            }
            else if (vertex.Latitude < center.Latitude)
            {
                xToBack = vertex.Latitude - 0.000010d;
            }
            else
            {
                xToBack = vertex.Latitude;
            }
            double yToBack = XCoeff * xToBack + AdditionalCoeff;

            return new GeoCoordinate(xToBack, yToBack);
        }

    }
}