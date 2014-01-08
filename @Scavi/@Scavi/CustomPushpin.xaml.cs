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
using System.Windows.Media;
using System.Windows.Threading;

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
            MouseEnter +=CustomPushpin_MouseEnter;
            

        }

        public void CustomPushpin_MouseEnter(object sender, RoutedEventArgs e)
        {
            var contextMenu = ContextMenuService.GetContextMenu(this);

            if (contextMenu == null)
            {
                contextMenu = new ContextMenu();
            }
            else
            {
                contextMenu.Items.Clear();
            }
            

            //var helloHermit = new MenuItem
            //{
            //    Header = "Hello Hermit"
            //};
            //helloHermit.Click += (o, args) => MessageBox.Show("Hello All");

            var rating = new Rating
            {
                Value=4.5,
                Background = new SolidColorBrush(Color.FromArgb(255,255,0,255))
            };

            var detail = new MenuItem
            {
                Header = "Visualizza Dettagli"
            };
            detail.Click += (o, args) => ShowDetail_Click(sender, e);
            
            CustomPushpin p = (CustomPushpin)sender;

            //contextMenu.Items.Add(helloHermit);
            contextMenu.Items.Add(p.name);
            contextMenu.Items.Add(rating);
            contextMenu.Items.Add(detail);

            ContextMenuService.SetContextMenu(this, contextMenu);

            contextMenu.IsOpen = true;
        }

        public void ShowDetail_Click(object sender, RoutedEventArgs e )
        {
            CustomPushpin p = (CustomPushpin)sender;
            ShowDetails(p);
        }

        public void ShowDetails(CustomPushpin p)
        {
            PhoneApplicationService.Current.State["currentpushpin"] = p;
            (Application.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/Detail.xaml", UriKind.Relative));
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
