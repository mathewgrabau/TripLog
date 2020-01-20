using System;
using System.ComponentModel;
using System.Threading.Tasks;
using TripLog.ViewModels;

namespace TripLog.Services
{
    public interface INavService
    {
        bool CanGoBack { get; set; }
        Task GoBack();
        Task NavigateTo<TViewModel>() where TViewModel : BaseViewModel;
        Task NavigateTo<TViewModel, TParameter>(TParameter parameter) where TViewModel : BaseViewModel;
        void RemoveLastView();
        void ClearBackStack();
        void NavigateToUri(Uri uri);
        event PropertyChangedEventHandler CanGoBackChanged;
    }
}
