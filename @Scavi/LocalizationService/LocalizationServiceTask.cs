using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using System.Net.Http;
using System.IO;
using Windows.Devices.Geolocation;
using System.Runtime.InteropServices.WindowsRuntime;



namespace LocalizationService
{
    public sealed class LocalizationServiceTask : IBackgroundTask
    {
        public Geoposition currentPosition { get; set; }
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            BackgroundTaskDeferral deferral = taskInstance.GetDeferral();

            currentPosition = await GetPosition();
            deferral.Complete();
        }

        public Windows.Foundation.IAsyncOperation<Geoposition> GetPositionAsync()
        {
            return AsyncInfo.Run((Geoposition ge) => GetPosition());

        }
        public async Task<Geoposition> GetPosition()
        {
            Geoposition geoposition = null;

            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 50;

            try
            {
                geoposition = await geolocator.GetGeopositionAsync(
                    maximumAge: TimeSpan.FromMinutes(5),
                    timeout: TimeSpan.FromSeconds(10)
                    );

            }
            catch (ArgumentException AE)
            {
                throw AE;
            }

            return geoposition;
        }
    }
}
