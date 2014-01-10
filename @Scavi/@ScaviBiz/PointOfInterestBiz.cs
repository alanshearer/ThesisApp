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
        public String GetPointsOfInterest()
        {
            List<PointOfInterest> listToGeoRSS = dal.GetPointsOfInterest();

            return GeoRSSFromListPois(listToGeoRSS);
        }

        public void SetFeedback(int ID, Double vote, String Motivation)
        {
            dal.SetFeedback(ID, vote, Motivation);
        }

        private String GeoRSSFromListPois(List<PointOfInterest> list)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            StringBuilder builder = new StringBuilder();


            using (XmlWriter writer = XmlWriter.Create(builder, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("entries");
                writer.WriteAttributeString( "georss", "xmlns", "http://www.georss.org/georss");
                //if geoRSSds is not null and rows count >0 then
                //For each loop for geoRSSds starts here {
                foreach (PointOfInterest poi in list)
                {
                    writer.WriteStartElement("entry");
                    writer.WriteElementString("ID", poi.ID.ToString());
                    writer.WriteElementString("name", poi.name);
                    writer.WriteElementString("url", poi.uripage);
                    writer.WriteElementString("summary", poi.summary);
                    writer.WriteElementString("tipology", poi.type);
                    writer.WriteElementString("rating", poi.rating.ToString());
                    writer.WriteStartElement("polygon", "georss", "xmlns");
                    foreach (GeoCoordinate coordinate in poi.Polygon.points)
                    {
                        writer.WriteStartElement("point", "georss");
                        writer.WriteElementString("lat", "georss", coordinate.Latitude.ToString());
                        writer.WriteElementString("lon", "georss", coordinate.Longitude.ToString());
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                // } For each loop ends here
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
            return builder.ToString();
        }

    }
}
