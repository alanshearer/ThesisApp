using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        //PointOfInterestBiz biz = null;

        //public Service1()
        //{
        //    biz = new PointOfInterestBiz();
        //}

        public String GetPointsOfInterestRSS()
        {

            //XmlWriterSettings settings = new XmlWriterSettings();
            //settings.Indent = true;
            //StringBuilder builder = new StringBuilder();

            //PointOfInterest point = biz.GetPointOfInterest();

            //using (XmlWriter writer = XmlWriter.Create(builder, settings))
            //{
            //    writer.WriteStartDocument();
            //    writer.WriteStartElement("rss");
            //    writer.WriteAttributeString("version", "2.0");
            //    writer.WriteAttributeString("xmlns:geo", "http://www.w3.org/2003/01/geo/wgs84_pos#");
            //    writer.WriteStartElement("channel");
            //    //if geoRSSds is not null and rows count >0 then
            //    //For each loop for geoRSSds starts here {
            //    writer.WriteStartElement("item");
            //    writer.WriteElementString("title", point.name);
            //    writer.WriteElementString("description", point.summary);
            //    writer.WriteElementString("geo:lat", point.geocoordinate.Latitude.ToString());
            //    writer.WriteElementString("geo:long", point.geocoordinate.Longitude.ToString());
            //    writer.WriteEndElement();
            //    // } For each loop ends here
            //    writer.WriteEndElement();
            //    writer.WriteEndDocument();
            //    writer.Close();
            //}
            //return builder.ToString();

            return "eccoqui";
        }

        public IAsyncResult BeginGetPointOfInterestRSS(AsyncCallback callback, object state)
        {
            Func<String> invokeOperation = () => GetPointsOfInterestRSS();
            return invokeOperation.BeginInvoke(callback, state);

        }
        public string EndGetPointOfInterestRSS(IAsyncResult result)
        {
            var asyncResult = (System.Runtime.Remoting.Messaging.AsyncResult)result;

            var func = (Func<String>)asyncResult.AsyncDelegate;

            return func.EndInvoke(result);
        }

    }
}
