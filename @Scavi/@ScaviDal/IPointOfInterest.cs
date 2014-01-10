using _ScaviDataModel;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ScaviDal
{
    public interface IPointOfInterest
    {
        List<PointOfInterest> GetPointsOfInterest();
        void SetFeedback(int ID, Double vote, String Motivation);


        PointOfInterest GetPointOfInterestByPosition(GeoCoordinate coordinate);

    }
}
