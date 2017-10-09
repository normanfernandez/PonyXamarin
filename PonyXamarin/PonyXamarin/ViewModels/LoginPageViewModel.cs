using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PonyXamarin.ViewModels
{
    public class LoginPageViewModel : BindableBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DelegateCommand Login { get; set; }
        public INavigationService NavigationService;
        public IPageDialogService PageDialogService { get; set; }
        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            NavigationService = navigationService;
            PageDialogService = pageDialogService;
            Username = "";
            Password = "";
            Login = new DelegateCommand(ValidateLogin);
        }

        public async void ValidateLogin()
        {
            if (Username.Trim().ToUpper() == "PONY" && Password == "1234")
                await NavigationService.NavigateAsync("NavigationPage/MainPage");
            else
                await PageDialogService.DisplayAlertAsync("OOPS!", "WRONG CREDENTIALS!", "Close");
        }
    }
}
