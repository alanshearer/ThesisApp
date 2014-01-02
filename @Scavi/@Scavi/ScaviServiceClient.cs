using _Scavi.ScaviServiceReference;
using Microsoft.Phone.Maps.Toolkit;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;
using Windows.Devices.Geolocation;

namespace _Scavi
{
    public class ScaviServiceClient
    {

        String stringToParse = "";
        public Pushpin GetPushpin()
        {
            Pushpin pushpinToBack = new Pushpin();

            stringToParse = (new ScaviServiceStub()).GetStub();

            //Console.WriteLine(stringToParse);
            XDocument document = XDocument.Load(new StringReader(stringToParse));

            var georss = XNamespace.Get("http://www.georss.org/georss");

            var event1 = from ev1 in document.Descendants("channel").Elements("item")
                             .Where(e => e.Element(georss + "point") != null)
                                          select new  {
                     GeoCoordinate = new System.Device.Location.GeoCoordinate(Double.Parse(ev1.Element("geo:lat").Value), Double.Parse(ev1.Element("geo:long").Value)),
                     Name = ev1.Element("title").Value,
                     Content = ev1.Element("description").Value
                 };

            return new Pushpin { GeoCoordinate = event1.First().GeoCoordinate, Name = event1.First().Name, Content = event1.First().Content };

        }


        public async void GetStringToParseMethod()
        {
            Task<String> s = GetStringToParse();
            stringToParse = await s;
        }

        public static Task<String> GetStringToParse()
        {
            return null;
        }

       
        public async Task<GeoCoordinate> GetPosition()
        {
            GeoCoordinate coordinateToBack = new GeoCoordinate(0, 0);

            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;

            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync(
                    maximumAge: TimeSpan.FromMinutes(5),
                    timeout: TimeSpan.FromSeconds(10)
                    );

                coordinateToBack.Latitude = geoposition.Coordinate.Latitude;
                coordinateToBack.Longitude = geoposition.Coordinate.Longitude;
            }
            catch (ArgumentException AE)
            {
                MessageBox.Show(AE.StackTrace);
            }

            return coordinateToBack;
        }
    }

}
