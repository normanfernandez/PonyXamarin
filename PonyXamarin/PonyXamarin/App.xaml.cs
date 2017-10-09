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

        public static List<Pony> ponies = new List<Pony>();
        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<FormPage>();
        }
    }
}
