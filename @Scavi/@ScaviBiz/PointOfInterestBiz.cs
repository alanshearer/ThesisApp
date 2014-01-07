using _ScaviDal;
using _ScaviDataModel;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _ScaviBiz
{
    public class PointOfInterestBiz
    {

        private IPointOfInterest dal = null;

        public PointOfInterestBiz()
        {
            dal = new FilePointOfInterestGetter();
        }
        private List<PointOfInterest> GetPointsOfInterest()
        {
            return new List<PointOfInterest>();
        }

        public PointOfInterest GetPointOfInterest()
        {
            return new PointOfInterest { name = "tempio", summary = "sommario", center = new GeoCoordinate(0, 0), type = new PointOfInterestType(PointOfInterestTypeEnum.Casa), uripage = new Uri("http://www.google.it") };
        }

        public PointOfInterest GetPointOfInterestByPosition(GeoCoordinate coordinate)
        {
            return dal.GetPointOfInterestByPosition(coordinate);
        }

        //public String GetPointsOfInterestRSS()
        //{

        //    XmlWriterSettings settings = new XmlWriterSettings();
        //    settings.Indent = true;
        //    StringBuilder builder = new StringBuilder();

        //    using (XmlWriter writer = XmlWriter.Create(builder, settings))
        //    {
        //        writer.WriteStartDocument();
        //        writer.WriteStartElement("rss");
        //        writer.WriteAttributeString("version", "2.0");
        //        writer.WriteAttributeString("xmlns:geo", "http://www.w3.org/2003/01/geo/wgs84_pos#");
        //        writer.WriteStartElement("channel");
        //        //if geoRSSds is not null and rows count >0 then
        //        //For each loop for geoRSSds starts here {
        //        writer.WriteStartElement("item");
        //        writer.WriteElementString("title", pointName);
        //        writer.WriteElementString("description", pointDescription);
        //        writer.WriteElementString("geo:lat", geoLat);
        //        writer.WriteElementString("geo:long", geoLong);
        //        writer.WriteEndElement();
        //        // } For each loop ends here
        //        writer.WriteEndElement();
        //        writer.WriteEndDocument();
        //        writer.Close();
        //    }
        //}
    }
}
