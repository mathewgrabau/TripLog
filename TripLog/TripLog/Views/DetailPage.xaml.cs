﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLog.Models;
using TripLog.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace TripLog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        DetailViewModel ViewModel => BindingContext as DetailViewModel;

        public DetailPage()
        {
            InitializeComponent();

            BindingContext = new DetailViewModel();

            if (entry != null)
            {
                map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(ViewModel.Entry.Latitude, ViewModel.Entry.Longitude), Distance.FromMiles(0.5)));
                map.Pins.Add(new Pin
                {
                    Type = PinType.Place,
                    Label = ViewModel.Entry.Title,
                    Position = new Position(ViewModel.Entry.Latitude, ViewModel.Entry.Longitude)
                });
                //    title.Text = entry.Title;
                //    date.Text = entry.Date.ToString("M");
                //    rating.Text = $"{entry.Rating} stars";
                //    notes.Text = entry.Notes;
            }
        }
    }
}