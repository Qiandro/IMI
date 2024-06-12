using FreshMvvm;
using Imi.Project.Mobile.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class LoginViewModel : FreshBasePageModel
    {
        protected readonly IApiService _apiService;
        
        public LoginViewModel(IApiService apiService)
        {
            _apiService = apiService;
        }

        private string email = "qiandro.claeys@gmail.com";
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                RaisePropertyChanged();
            }
        }

        private string password = "Test123?";
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged();
            }
        }

        public ICommand LoginCommand => new Command(async () =>
        {
            var test = await _apiService.Login(Email, Password);

            if (await _apiService.Login(Email, Password))
            {
                await CoreMethods.PushPageModel<GroupListViewModel>();
                
            }
            else
            {
                await CoreMethods.DisplayAlert("Something went wrong", "Woops something went wrong", "cancel");
            }
        });

    }
}
