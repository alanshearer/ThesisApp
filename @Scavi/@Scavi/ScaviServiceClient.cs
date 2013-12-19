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
        //static _Scavi.ScaviServiceReference.ScaviServiceClient service = new _Scavi.ScaviServiceReference.ScaviServiceClient();
        ServiceReference1.GeoIPServiceSoap service = new ServiceReference1.GeoIPServiceSoapClient();
        ServiceReference1.GeoIP geoip = null;
        String stringToParse = "";
        public Pushpin GetPushpin()
        {
            Pushpin pushpinToBack = new Pushpin();

            object state = "stato";

            service.BeginGetGeoIP("64.233.160.0", MyCallback, service);
            

            while (geoip==null)
            {
                Thread.Sleep(1000);
            }

            //Console.WriteLine(stringToParse);
            //XDocument document = XDocument.Load(new StringReader(stringToParse));

            //var georss = XNamespace.Get("http://www.georss.org/georss");

            //IEnumerable<Pushpin> event1 = from ev1 in document.Descendants("channel").Elements("item")
            //                 .Where(e => e.Element(georss + "point") != null)
            //                                      select new Pushpin
            //             {
            //                 GeoCoordinate = new System.Device.Location.GeoCoordinate(Double.Parse(ev1.Element("geo:lat").Value),Double.Parse(ev1.Element("geo:long").Value)),
            //                 Name = ev1.Element("title").Value,
            //                 Content = ev1.Element("description").Value
            //             };

            //return event1.ElementAt(0);

            return new Pushpin { Name = geoip.IP };
        }

        public void MyCallback(IAsyncResult result)
        {
            geoip = service.EndGetGeoIP(result);
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
