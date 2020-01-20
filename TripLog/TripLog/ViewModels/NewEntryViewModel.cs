using System;
using System.Collections.Generic;
using System.Text;
using TripLog.Models;
using Xamarin.Forms;

namespace TripLog.ViewModels
{
    public class NewEntryViewModel : BaseValidationViewModel
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
                Validate(() => !string.IsNullOrWhiteSpace(_title), "Title must be provided.");
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
                Validate(() => _rating >= 1 && _rating <= 5, "Rating must be between 1 and 5.");
                OnPropertyChanged();
                SaveCommand.ChangeCanExecute();
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

        /// <summary>
        /// Cannot execute unless validation has passed successfully.
        /// </summary>
        /// <returns></returns>
        bool CanSave() => !string.IsNullOrWhiteSpace(Title) && !HasErrors;
    }
}
