using FreshMvvm;
using Imi.Project.Mobile.Interfaces;
using Imi.Project.Mobile.Services;
using Imi.Project.Mobile.ViewModels;
using Newtonsoft.Json;
using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarPage : ContentPage
    {
        
        public CalendarPage()
        {
            InitializeComponent();
            //calendar.InlineItemTapped += Calendar_InlineItemTapped;
        }
        
        private async void Calendar_InlineItemTapped(object sender, InlineItemTappedEventArgs e)
        {
            var appointment = e.InlineEvent;
            await SecureStorage.SetAsync("Appointment", JsonConvert.SerializeObject(appointment));
            //await Navigation.PushAsync(new EventDetailPage());
            var test = BindingContext;
            CalendarViewModel viewModel = (CalendarViewModel)BindingContext;
            viewModel.NextPage.Execute(null);


        }
    }
}