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

namespace _Scavi
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            //Map myMap = new Map();
            //this.myMap = new Map();
            //MapLayer layer0 = new MapLayer();

            //this.myMap.Layers.Add(layer0);

            //Pushpin pushpin0 = new Pushpin();
            ////Pushpin pushpin0 = (Pushpin)this.FindName("pushpin0");
            ////Pushpin pushpin0 = MapExtensions.GetChildren(myMap).OfType<Pushpin>().First(p => p.Name == "pushpin0");
            ////if (pushpin0 == null) { pushpin0 = new Pushpin(); }
            //pushpin0.GeoCoordinate = new GeoCoordinate(37.228510, -80.422860);
            //MapOverlay overlay0 = new MapOverlay();
            //overlay0.Content = pushpin0;
            //overlay0.Content =
            //layer0.Add(overlay0);

            //Pushpin pushpin1 = new Pushpin();
            //pushpin1.GeoCoordinate = new GeoCoordinate(37.726399, -80.425271);
            //MapOverlay overlay1 = new MapOverlay();
            //overlay1.Content = pushpin1;
            //layer0.Add(overlay1);
            //Pushpin pushpin2 = new Pushpin();
            //pushpin2.GeoCoordinate = new GeoCoordinate(37.928900, -80.427450);
            //MapOverlay overlay2 = new MapOverlay();
            //overlay2.Content = pushpin2;
            //layer0.Add(overlay2);

            ////myMap.Layers.Add(layer0);
            //overlay0.GeoCoordinate = new GeoCoordinate(37.528510, -80.422860);

            myMap.Center = new GeoCoordinate(37.228900, -80.427450);


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
            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
            appBarButton.Text = AppResources.AppBarButtonText;
            ApplicationBar.Buttons.Add(appBarButton);

            // Create a new menu item with the localized string from AppResources.
            ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            ApplicationBar.MenuItems.Add(appBarMenuItem);
        }
    }
}