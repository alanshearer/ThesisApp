using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using _ScaviDataModel;
using System.Windows.Media.Imaging;
using System.Device.Location;

namespace _Scavi
{
    public partial class CustomPushpin : UserControl
    {
        public String name { get; set; }
        public Uri uri { get; set; }
        public GeoCoordinate coordinate { get; set; }

        public CustomPushpin(PointOfInterest point)
        {
            InitializeComponent();
            PushpinImage.Source = GetImageFromPoiType(point.type);
            name = point.name;
            uri = point.uripage;
            coordinate = point.center;

        }

        public BitmapImage GetImageFromPoiType(PointOfInterestType type)
        {
            switch (type.type)
            {
                default:
                    return new BitmapImage(new Uri("/Assets/AppIcons/temple.png", UriKind.RelativeOrAbsolute));

            }
        }
 
    }
}
