using System;
using System.Collections.Generic;
using System.Net.Http;
using Plugin.Share;
using Plugin.Share.Abstractions;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using App1.Models;
using Xamarin.Forms;
using Plugin.Geolocator;
using System.Threading;

namespace App1.ViewModels
{
    public class FoursquareViewModel : INotifyPropertyChanged
    {
        private const string clientId = "";//SelectYourKey
        private const string clientSecret = "";//SelectYourKey
        public static string constLat = "0";
        public static string constLtd = "0";
        private static string radius = "5000";
        private FoursquareVenues _foursquareVenues;
        public INavigation Navigation { get; set; }
        Venue _foursquareVenue;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public FoursquareVenues FoursquareVenues
        {
            get { return _foursquareVenues; }
            set { _foursquareVenues = value;OnPropertyChanged("FoursquareVenues"); }
        }

        public Venue SelectedVenue
        {
            get { return _foursquareVenue; }
            set
            {
                if (_foursquareVenue != value)
                {
                    Venue tempVenue = value;
                    _foursquareVenue = null;
                    string finalLocalLat = tempVenue.location.lat.ToString().Replace(',', '.');
                    string finalLocalLtd = tempVenue.location.lng.ToString().Replace(',', '.');
                    string mapsUrl = "http://maps.apple.com/?q=" +
                    $"{finalLocalLat},{finalLocalLtd}";
                    if (CrossShare.Current.CanOpenUrl(mapsUrl))
                        CrossShare.Current.OpenBrowser(mapsUrl);
                    OnPropertyChanged("SelectedValue");
                }
            }
        }

        public FoursquareViewModel()
        {
            InitDataAsync();
        }

        private async Task InitDataAsync()
        {
            HttpClient httpClient = new HttpClient();

            string s = constLat.Replace(',', '.');
            string s2 = constLtd.Replace(',', '.');

            string fourSquareApiUrlCheck = "https://api.foursquare.com/v2/venues/search?" +
            $"ll={s},{s2}" +
            $"&client_id={clientId}" +
            $"&client_secret={clientSecret}" +
            "&v=20181121" +
            "&venuePhotos=1" +
            $"&radius={radius}"+
            $"&categoryId=4bf58dd8d48988d17f941735";

            string json = await httpClient.GetStringAsync(fourSquareApiUrlCheck);

            FoursquareVenues = JsonConvert.DeserializeObject<App1.Models.FoursquareVenues>(json);
        }
    }
}