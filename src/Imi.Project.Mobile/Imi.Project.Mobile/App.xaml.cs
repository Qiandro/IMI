using FreshMvvm;
using Imi.Project.Mobile.Interfaces;
using Imi.Project.Mobile.Pages;
using Imi.Project.Mobile.Services;
using Imi.Project.Mobile.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            FreshIOC.Container.Register<ITokenHandler, TokenHandler>();
            FreshIOC.Container.Register<IApiService, ApiService>();


            //MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<LoginViewModel>(), "Login");

            var page = FreshPageModelResolver.ResolvePageModel<LoginViewModel>();
            var basicNavContainer = new FreshNavigationContainer(page);
            MainPage = basicNavContainer;

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}