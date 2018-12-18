using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public class FoursquareVenues
    {
        public Meta meta { get; set; }
        public Response response { get; set; }
    }

    public class Meta
    {
        public int code { get; set; }
        public string requestId { get; set; }
    }

    public class Response
    {
        public Venue[] venues { get; set; }
        public bool confident { get; set; }
    }

    public class Venue
    {
        public string id { get; set; }
        public string name { get; set; }
        public Location location { get; set; }
        public Category[] categories { get; set; }
        public string referralId { get; set; }
        public bool hasPerk { get; set; }
        public Venuepage venuePage { get; set; }
    }

    public class Location
    {
        public string address { get; set; } = "Unknown Address";
        public string crossStreet { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        public Labeledlatlng[] labeledLatLngs { get; set; }
        public int distance { get; set; }
        public string postalCode { get; set; }
        public string cc { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; } = "Unknown Country";
        public string[] formattedAddress { get; set; }
    }

    public class Labeledlatlng
    {
        public string label { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Venuepage
    {
        public string id { get; set; }
    }

    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }
        public string pluralName { get; set; }
        public string shortName { get; set; }
        public Icon icon { get; set; }
        public bool primary { get; set; }
    }

    public class Icon
    {
        public string prefix { get; set; }
        public string suffix { get; set; }
    }
}
