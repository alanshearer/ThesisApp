using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Devices.Geolocation;

namespace _Scavi
{
    public partial class Detail : PhoneApplicationPage
    {
        public Detail()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (App.Geolocator == null)
            {
                App.Geolocator = new Geolocator();
                App.Geolocator.DesiredAccuracy = PositionAccuracy.High;
                App.Geolocator.MovementThreshold = 100; // The units are meters.
                App.Geolocator.PositionChanged += geolocator_PositionChanged;
            }
        }

        protected override void OnRemovedFromJournal(System.Windows.Navigation.JournalEntryRemovedEventArgs e)
        {
            App.Geolocator.PositionChanged -= geolocator_PositionChanged;
            App.Geolocator = null;
        }

        void geolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {


            if (!App.RunningInBackground)
            {
                Dispatcher.BeginInvoke(() =>
                {
                    LatitudeTextBlock.Text = args.Position.Coordinate.Latitude.ToString("0.00");
                    LongitudeTextBlock.Text = args.Position.Coordinate.Longitude.ToString("0.00");
                    WebBrowserBlock.Navigate(new Uri(""));
                });
            }
            else
            {
                Microsoft.Phone.Shell.ShellToast toast = new Microsoft.Phone.Shell.ShellToast();
                toast.Content = args.Position.Coordinate.Latitude.ToString("0.00");
                toast.Title = "Location: ";
                toast.NavigationUri = new Uri("/Detail.xaml", UriKind.Relative);
                toast.Show();

            }
        }


    }
}