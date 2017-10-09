using PonyXamarin.Models;
using PonyXamarin.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PonyXamarin.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private INavigationService NavigationService;
        private IPageDialogService PageDialogService;
        private RestClient restClient = new RestClient();
        private ObservableCollection<Pony> _observablePonies;
        public ObservableCollection<Pony> ObservablePonies
        {
            get { return _observablePonies; }
            set { SetProperty(ref _observablePonies, value); }
        }
        public DelegateCommand GoToForm { get; set; }
        public DelegateCommand TruncatePonies { get; set; }
        public DelegateCommand GetPonies { get; set; }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            NavigationService = navigationService;
            PageDialogService = pageDialogService;
            GoToForm = new DelegateCommand(GoToPonyForm);
            TruncatePonies = new DelegateCommand(TruncatePoniesList);
            GetPonies = new DelegateCommand(GetPoniesMethod);
            _observablePonies = new ObservableCollection<Pony>();
        }

        public async void GetPoniesMethod()
        {
            var response = await restClient.GetPonies();
            if (response == null)
            {
                await PageDialogService.DisplayAlertAsync("Error", "No se pudo descargar", "Close");
                return;
            }

            _observablePonies.Clear();
            foreach (var r in response)
                _observablePonies.Add(r);
        }

        public async void TruncatePoniesList()
        {
            var result = await restClient.TruncatePonies();
            if (result)
            {
                await PageDialogService.DisplayAlertAsync("Success", "TRUNCATED SUCCESSFULLY", "Close");
                GetPoniesMethod();
            }
            else
                await PageDialogService.DisplayAlertAsync("Error", "COULD NOT TRUNCATE", "Close");
        }

        public async void GoToPonyForm()
        {
            await NavigationService.NavigateAsync("NavigationPage/FormPage");
        }
    }
}
