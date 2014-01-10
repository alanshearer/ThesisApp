using _Scavi;
using _Scavi.ScaviServiceReference;
using _ScaviDataModel;
using Microsoft.Phone.Maps.Toolkit;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Storage;

namespace _ScaviDal
{
    public class FilePointOfInterestGetter : IPointOfInterestGetter
    {
        public async Task<PointOfInterest> GetPointOfInterestByPosition(GeoCoordinate coordinate)
        {
            List<PointOfInterest> pois = await GetPointsOfInterest();
            foreach (PointOfInterest poi in pois)
            {
                if (poi.Polygon.IncludePoint(coordinate))
                {
                    return poi;
                }
            }

            return null;
        }

        public async Task<Stream> GetStream()
        {
            StorageFolder local = await Windows.Storage.StorageFolder.GetFolderFromPathAsync("./");

            if (local != null)
            {
                // Get the DataFolder folder.
                var dataFolder = await local.GetFolderAsync("GeoRSS");

                // Get the file.
                var file = await dataFolder.OpenStreamForReadAsync("GeoRssFile1.xml");

                return file;
            }
            return null;
        }
        public Task<String> GetString()
        {
            var tcs = new TaskCompletionSource<string>();

            _Scavi.ScaviServiceReference.ScaviServiceClient clientForTesting = new _Scavi.ScaviServiceReference.ScaviServiceClient();
            //clientForTesting.GetPointsOfInterestRSSCompleted += new EventHandler<_Scavi.ScaviServiceReference.GetPointsOfInterestRSSCompletedEventArgs>(calculateCallback);

            clientForTesting.GetPointsOfInterestRSSCompleted += (sender, args) =>
                {
                    tcs.SetResult(args.Result);
                };

            clientForTesting.GetPointsOfInterestRSSAsync();
            return tcs.Task;
        }

        private void calculateCallback(object sender, _Scavi.ScaviServiceReference.GetPointsOfInterestRSSCompletedEventArgs e)
        {

            //poisString = e.Result;
        }


        public async Task<List<PointOfInterest>> GetPointsOfInterest()
        {
            List<PointOfInterest> listToBack = new List<PointOfInterest>();

            try
            {
                //Stream stream = await GetStream();
                ////Pass the file path and file name to the StreamReader constructor
                //StreamReader sr = new StreamReader(stream);
                
                String str = await GetString();

                XNamespace georss = XNamespace.Get("http://www.georss.org/georss");
                
                XDocument document = XDocument.Parse(str);
                XElement mainel = document.Root;
                IEnumerable<XElement> elements = from el in mainel.Descendants("entry") select el;
               

                foreach (XElement el in elements)
                {
                    String ID="", name="", summary="";
                    Uri url= null;
                    PointOfInterestType tipology=null;
                    GeoPolygon realpolygon = new GeoPolygon();
                    GeoPolygon realpolygonwithmargin = new GeoPolygon();

                    if (el.Element("ID") != null)
                    {
                        ID = el.Element("ID").Value;
                    }

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

                    if (el.Element("polygon") != null)
                    {
                        XElement polygonEl = el.Element("polygon");
                        IEnumerable<XElement> points = from currentEl in polygonEl.Descendants("point") select currentEl;

                        foreach (XElement point in points)
                        {
                            Double lat = 0, lon = 0;
                            NumberFormatInfo numberFormat = new NumberFormatInfo();
                            numberFormat.NumberDecimalSeparator = ",";

                            if (point.Element("lat") != null)
                            {
                                lat = Convert.ToDouble(point.Element("lat").Value, numberFormat);
                            }
                            if (point.Element("lon") != null)
                            {
                                lon = Convert.ToDouble(point.Element("lon").Value, numberFormat);
                            }

                            realpolygon.Add(new GeoCoordinate(lat, lon));

                        }
                        //List<String> elementcoordinateStrings = el.Element(georss + "polygon").Value.Split(' ').ToList();
                        //for (int i = 0; i < elementcoordinateStrings.Count; i = i + 2)
                        //{
                        //    Double lat = Double.Parse(elementcoordinateStrings.ElementAt(i), CultureInfo.InvariantCulture);
                        //    Double lon = Double.Parse(elementcoordinateStrings.ElementAt(i + 1), CultureInfo.InvariantCulture);


                        //    realpolygon.Add(new GeoCoordinate(lat, lon));


                        //}
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

                //sr.Close();

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

        private CustomPushpin PoiToPushpin(PointOfInterest poi)
        {
            String name = poi.name;
            GeoCoordinate coordinate = poi.center;
            CustomPushpin pin = new CustomPushpin(poi);
           
            return pin;

        }


        private List<CustomPushpin> PoisToPushpins(List<PointOfInterest> pois)
        {
            List<CustomPushpin> listToBack = new List<CustomPushpin>();
            foreach (PointOfInterest poi in pois)
            {
                listToBack.Add(PoiToPushpin(poi));
            }

            return listToBack;
        }

        public async Task<List<CustomPushpin>> GetCustomPushpins()
        {
            List<PointOfInterest> listToParse = await GetPointsOfInterest();
            List<CustomPushpin> listToBack = PoisToPushpins(listToParse);
            return listToBack;
        }

    }
}
