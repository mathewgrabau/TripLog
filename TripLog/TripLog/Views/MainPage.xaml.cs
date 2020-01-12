using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TripLog.Models;
using TripLog.ViewModels;

namespace TripLog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void New_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewEntryPage());
        }

        private async void trips_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TripLogEntry entry = e.CurrentSelection.FirstOrDefault() as TripLogEntry;
            if (entry != null)
            {
                await Navigation.PushAsync(new DetailPage(entry));
            }

            // Clear selection after
            trips.SelectedItem = null;
        }
    }
}