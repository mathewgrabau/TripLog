using System;
using System.Collections.Generic;
using System.Text;
using TripLog.Models;
using Xamarin.Forms;

namespace TripLog.ViewModels
{
    public class NewEntryViewModel : BaseViewModel
    {
        string _title;
        double _latitude;
        double _longitude;
        DateTime _date;
        int _rating;
        string _notes;
        Command _saveCommand;

        public NewEntryViewModel()
        {
            Date = DateTime.Today;
            Rating = 1;
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
                SaveCommand.ChangeCanExecute();
            }
        }

        public double Latitude
        {
            get => _latitude;
            set
            {
                _latitude = value;
                OnPropertyChanged();
            }
        }

        public double Longitude
        {
            get => _longitude;
            set
            {
                _longitude = value;
                OnPropertyChanged();
            }
        }

        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        public int Rating
        {
            get => _rating;
            set
            {
                _rating = value;
                OnPropertyChanged();
            }
        }

        public string Notes
        {
            get => _notes;
            set
            {
                _notes = value;
                OnPropertyChanged();
            }
        }

        public Command SaveCommand => _saveCommand ?? (_saveCommand = new Command(Save, CanSave));

        void Save()
        {
            var newItem = new TripLogEntry
            {
                Title = Title,
                Longitude = Longitude,
                Latitude = Latitude,
                Date = Date,
                Rating = Rating,
                Notes = Notes
            };

            // TODO persist
        }

        bool CanSave() => !string.IsNullOrWhiteSpace(Title);
    }
}
