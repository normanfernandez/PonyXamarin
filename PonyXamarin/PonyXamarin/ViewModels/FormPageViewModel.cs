using PonyXamarin.Models;
using PonyXamarin.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PonyXamarin.ViewModels
{
    public class FormPageViewModel : BindableBase
    {
        private RestClient restClient = new RestClient();
        public IPageDialogService PageDialogService { get; set; }
        private Pony _pony;
        public Pony Pony
        {
            get { return _pony; }
            set { SetProperty(ref _pony, value); }
        }

        public DelegateCommand PostPony { get; set; }

        public FormPageViewModel(IPageDialogService pageDialogService)
        {
            Pony = new Pony
            {
                PonyStyle = new PonyStyle()
            };
            PostPony = new DelegateCommand(AddPonyToList);
            PageDialogService = pageDialogService;
        }

        public async void AddPonyToList()
        {
            var result = await restClient.PostPony(Pony);
            if (result)
                await PageDialogService.DisplayAlertAsync("Success", "POSTED SUCCESSFULLY", "Close");
            else
                await PageDialogService.DisplayAlertAsync("Error", "COULD NOT POST", "Close");
        }
    }
}
