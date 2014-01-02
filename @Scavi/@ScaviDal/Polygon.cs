using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _ScaviDal
{
    public class Polygon
    {
        public List<Point> points { get; set; }

        public Polygon()
        {
            points = new List<Point>();
        }

        public void Add(Point point)
        {
            points.Add(point);
        }

        public Point GetCenter()
        {
            Double maxLat = Double.MinValue, maxLon = Double.MinValue, minLat = Double.MinValue, minLon = Double.MinValue;
            foreach (Point p in points)
            {
                if (maxLat == Double.MinValue)
                {
                    maxLat = p.X;
                }
                if (maxLon == Double.MinValue)
                {
                    maxLon = p.Y;
                }
                if (minLat == Double.MinValue)
                {
                    minLat = p.X;
                }
                if (minLon == Double.MinValue)
                {
                    minLon = p.Y;
                }
                if (p.X>maxLat)
                {
                    maxLat = p.X;
                }
                if (p.Y > maxLon)
                {
                    maxLon = p.Y;
                }
                if (p.X < minLat)
                {
                    minLat = p.X;
                }
                if (p.Y < minLon)
                {
                    minLon = p.Y;
                }
            }
            Double pX = (minLat + maxLat) / 2;
            Double pY = (minLon + maxLon) / 2;

            return new Point(pX, pY);
        }

        public Boolean IncludePoint(Point point)
        {
            int arrLength = points.Count;
            Double[] LatArray = new Double[arrLength];
            Double[] LonArray = new Double[arrLength];
            int i = 0;
            foreach (Point p in points)
            {
                LatArray[i] = p.X;
                LonArray[i] = p.Y;
                i++;
            }

            return pnpoly(arrLength, LatArray, LonArray, point.X, point.Y);
        }

        private Boolean pnpoly(int nvert, Double[] vertx, Double[] verty, Double testx, Double testy)
        {
            int i, j;
            Boolean c = true;
            for (i = 0, j = nvert - 1; i < nvert; j = i++)
            {
                if (((verty[i] > testy) != (verty[j] > testy)) &&
                 (testx < (vertx[j] - vertx[i]) * (testy - verty[i]) / (verty[j] - verty[i]) + vertx[i]))
                {
                    c = false && c;
                }

            }
            return !c;
        }


    }
}
