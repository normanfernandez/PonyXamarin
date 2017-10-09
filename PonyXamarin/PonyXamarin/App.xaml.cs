using Prism.Unity;
using PonyXamarin.Views;
using Xamarin.Forms;
using PonyXamarin.Models;
using System.Collections.Generic;

namespace PonyXamarin
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<FormPage>();
            Container.RegisterTypeForNavigation<LoginPage>();
        }
    }
}
