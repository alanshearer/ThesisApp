using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace _Scavi
{
    public class ScaviServiceStub
    {
        public String GetStub()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            StringBuilder builder = new StringBuilder();


            using (XmlWriter writer = XmlWriter.Create(builder, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("rss");
                writer.WriteAttributeString("version", "2.0");
                writer.WriteAttributeString("geo", "xmlns", "http://www.w3.org/2003/01/geo/wgs84_pos#");
                writer.WriteAttributeString("georss", "xmlns", "http://www.georss.org/georss");
                writer.WriteStartElement("channel");
                //if geoRSSds is not null and rows count >0 then
                //For each loop for geoRSSds starts here {
                writer.WriteStartElement("item");
                writer.WriteElementString("title", "tempio di era");
                writer.WriteElementString("description", "descrizione tempio di era");
                writer.WriteElementString("point", "georss", "40.41823585 15.0047305");
                writer.WriteEndElement();
                // } For each loop ends here
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
            return builder.ToString();
        }

    }
}
