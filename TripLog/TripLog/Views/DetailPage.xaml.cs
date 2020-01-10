using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLog.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TripLog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage(TripLogEntry entry)
        {
            InitializeComponent();

            if (entry != null)
            {
                map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(entry.Latitude, entry.Longitude), Distance.FromMiles(0.5)));
                map.Pins.Add(new Pin { Type = PinType.Place, Label = entry.Title, Position = new Position(entry.Latitude, entry.Longitude) });
                title.Text = entry.Title;
                date.Text = entry.Date.ToString("M");
                rating.Text = $"{entry.Rating} stars";
                notes.Text = entry.Notes;
            }
        }
    }
}