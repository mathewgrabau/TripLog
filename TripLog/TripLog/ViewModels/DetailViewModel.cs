using System;
using System.Collections.Generic;
using System.Text;
using TripLog.Models;

namespace TripLog.ViewModels
{
    public class DetailViewModel : BaseViewModel<TripLogEntry>
    {
        TripLogEntry _entry;

        public DetailViewModel()
        {
        }

        public TripLogEntry Entry
        {
            get => _entry;
            set
            {
                _entry = value;
                OnPropertyChanged();
            }
        }

        public override void Init(TripLogEntry parameter)
        {
            Entry = parameter;
        }

    }
}
