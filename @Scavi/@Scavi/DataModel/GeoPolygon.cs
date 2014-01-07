using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _ScaviDataModel
{
    public class GeoPolygon
    {
        public List<GeoCoordinate> points { get; set; }

        public GeoPolygon()
        {
            points = new List<GeoCoordinate>();
        }

        public void Add(GeoCoordinate point)
        {
            points.Add(point);
        }

        public GeoCoordinate GetCenter()
        {
            Double maxLat = Double.MinValue, maxLon = Double.MinValue, minLat = Double.MinValue, minLon = Double.MinValue;
            foreach (GeoCoordinate p in points)
            {
                if (maxLat == Double.MinValue)
                {
                    maxLat = p.Latitude;
                }
                if (maxLon == Double.MinValue)
                {
                    maxLon = p.Longitude;
                }
                if (minLat == Double.MinValue)
                {
                    minLat = p.Latitude;
                }
                if (minLon == Double.MinValue)
                {
                    minLon = p.Longitude;
                }
                if (p.Latitude>maxLat)
                {
                    maxLat = p.Latitude;
                }
                if (p.Longitude > maxLon)
                {
                    maxLon = p.Longitude;
                }
                if (p.Latitude < minLat)
                {
                    minLat = p.Latitude;
                }
                if (p.Longitude < minLon)
                {
                    minLon = p.Longitude;
                }
            }
            Double pX = (minLat + maxLat) / 2;
            Double pY = (minLon + maxLon) / 2;

            return new GeoCoordinate(pX, pY);
        }

        public Boolean IncludePoint(GeoCoordinate point)
        {
            int arrLength = points.Count;
            Double[] LatArray = new Double[arrLength];
            Double[] LonArray = new Double[arrLength];
            int i = 0;
            foreach (GeoCoordinate p in points)
            {
                LatArray[i] = p.Latitude;
                LonArray[i] = p.Longitude;
                i++;
            }

            return pnpoly(arrLength, LatArray, LonArray, point.Latitude, point.Longitude);
        }

        private Boolean pnpoly(int nvert, Double[] vertx, Double[] verty, Double testx, Double testy)
        {
            int i, j;
            Boolean c = true;
            for (i = 0, j = nvert - 1; i < nvert; j = i++)
            {
                if (((verty[i] >= testy) != (verty[j] >= testy)) &&
                 (testx <= (vertx[j] - vertx[i]) * (testy - verty[i]) / (verty[j] - verty[i]) + vertx[i]))
                {
                    c = false && c;

                }

            }
            return !c;
        }


    }
}
