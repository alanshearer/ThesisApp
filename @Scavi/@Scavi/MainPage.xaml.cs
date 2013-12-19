using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using _Scavi.Resources;
using Microsoft.Phone.Maps.Controls;
using System.Device.Location;
using Microsoft.Phone.Maps.Toolkit;
using Windows.Devices.Geolocation;
using System.Threading.Tasks;
using System.IO.IsolatedStorage;
using System.Windows.Media;

namespace _Scavi
{
    public partial class MainPage : PhoneApplicationPage
    {
        ScaviServiceClient client = new ScaviServiceClient();

        // Constructor
        public MainPage()
        {

            InitializeComponent();
            //Map myMap = new Map();
            //this.myMap = new Map();
            MapLayer layer0 = new MapLayer();

            this.myMap.Layers.Add(layer0);

            Pushpin pushpin0 = new Pushpin();
            //Pushpin pushpin0 = (Pushpin)this.FindName("pushpin0");
            //Pushpin pushpin0 = MapExtensions.GetChildren(myMap).OfType<Pushpin>().First(p => p.Name == "pushpin0");
            //if (pushpin0 == null) { pushpin0 = new Pushpin(); }
            pushpin0.GeoCoordinate = new GeoCoordinate(37.228510, -80.422860);
            MapOverlay overlay0 = new MapOverlay();
            overlay0.Content = pushpin0;
            overlay0.GeoCoordinate = pushpin0.GeoCoordinate;
            layer0.Add(overlay0);

            Pushpin pushpin1 = new Pushpin();
            pushpin1.GeoCoordinate = new GeoCoordinate(37.726399, -80.425271);
            MapOverlay overlay1 = new MapOverlay();
            overlay1.Content = pushpin1;
            overlay1.GeoCoordinate = pushpin1.GeoCoordinate;
            layer0.Add(overlay1);

            Pushpin pushpin2 = new Pushpin();
            pushpin2.GeoCoordinate = new GeoCoordinate(37.928900, -80.427450);
            MapOverlay overlay2 = new MapOverlay();
            overlay2.Content = pushpin2;
            overlay2.GeoCoordinate = pushpin2.GeoCoordinate;
            layer0.Add(overlay2);

            myMap.Center = new GeoCoordinate(40.916667, 14.416667);
            myMap.ZoomLevel = 13;

            //ContentPanel.Children.Add(this.myMap);


            // Sample code to localize the ApplicationBar
            BuildLocalizedApplicationBar();
        }


        // Sample code for building a localized ApplicationBar
        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton ZoomInButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/add.png", UriKind.Relative));
            ZoomInButton.Text = AppResources.ZoominButton;
            ApplicationBar.Buttons.Add(ZoomInButton);
            ZoomInButton.Click += ZoomInButton_Click;

            // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton ZoomOutButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/minus.png", UriKind.Relative));
            ZoomOutButton.Text = AppResources.ZoomoutButton;
            ApplicationBar.Buttons.Add(ZoomOutButton);
            ZoomOutButton.Click += ZoomOutButton_Click;

            ApplicationBarIconButton CenterMapButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/position.png", UriKind.Relative));
            CenterMapButton.Text = AppResources.CenterButton;
            ApplicationBar.Buttons.Add(CenterMapButton);
            CenterMapButton.Click += CenterMapButton_Click;

            ApplicationBarIconButton ShowPointsOfInterestButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/showpois.png", UriKind.Relative));
            ShowPointsOfInterestButton.Text = AppResources.ShowPointsOfInterestButton;
            ApplicationBar.Buttons.Add(ShowPointsOfInterestButton);
            ShowPointsOfInterestButton.Click += ShowPointsOfInterestButton_Click;

            // Create a new menu item with the localized string from AppResources.
            //ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            //ApplicationBar.MenuItems.Add(appBarMenuItem);
        }



        void ZoomInButton_Click(object sender, EventArgs e)
        {
            if (myMap.ZoomLevel < 20)
            {
                myMap.ZoomLevel = myMap.ZoomLevel + 1;
            }
        }

        void ZoomOutButton_Click(object sender, EventArgs e)
        {
            if (myMap.ZoomLevel > 1)
            {
                myMap.ZoomLevel = myMap.ZoomLevel - 1;
            }
        }



        async void CenterMapButton_Click(object sender, EventArgs e)
        {
            GeoCoordinate position = new GeoCoordinate();
            GeoCoordinate PositionGotten = await client.GetPosition();
            position = PositionGotten;

            Pushpin positionPushpin = new Pushpin();
            //positionPushpin.Background = new SolidColorBrush(Colors.Red);
            //positionPushpin.Content = "myposition";
            positionPushpin.GeoCoordinate = position;
            MapOverlay overlay0 = new MapOverlay();
            overlay0.Content = positionPushpin;
            overlay0.GeoCoordinate = positionPushpin.GeoCoordinate;
           
            MapLayer positionLayer = new MapLayer();
            positionLayer.Add(overlay0);
            myMap.Layers.Add(positionLayer);
            myMap.Center = positionPushpin.GeoCoordinate;


        }

        void ShowPointsOfInterestButton_Click(object sender, EventArgs e)
        {
            Pushpin positionPushpin = client.GetPushpin();
            //positionPushpin.Background = new SolidColorBrush(Colors.Red);
            //positionPushpin.Content = "myposition";
            //MapOverlay overlay0 = new MapOverlay();
            //overlay0.Content = positionPushpin;
            //overlay0.GeoCoordinate = positionPushpin.GeoCoordinate;

            //MapLayer positionLayer = new MapLayer();
            //positionLayer.Add(overlay0);
            //myMap.Layers.Add(positionLayer);
            //myMap.Center = positionPushpin.GeoCoordinate;

            MessageBox.Show(positionPushpin.Name);

        }
       
    }
}