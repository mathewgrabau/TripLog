using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLog.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TripLog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewEntryPage : ContentPage
    {
        NewEntryViewModel ViewModel => BindingContext as NewEntryViewModel;

        public NewEntryPage()
        {
            InitializeComponent();
            BindingContextChanged += NewEntryPage_BindingContextChanged;
            BindingContext = new NewEntryViewModel();
        }

        private void NewEntryPage_BindingContextChanged(object sender, EventArgs e)
        {
            ViewModel.ErrorsChanged += ViewModel_ErrorsChanged;
        }

        /// <summary>
        /// Event handler for updating the errors.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            var propHasErrors = (ViewModel.GetErrors(e.PropertyName) as List<string>)?.Any() == true;
            switch (e.PropertyName)
            {
                case nameof(ViewModel.Title):
                    titleEntry.LabelColor = propHasErrors ? Color.Red : Color.Black;
                    break;

                case nameof(ViewModel.Rating):
                    ratingEntry.LabelColor = propHasErrors ? Color.Red : Color.Black;
                    break;

                default:
                    break;
            }
        }
    }
}