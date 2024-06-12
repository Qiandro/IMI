using FreshMvvm;
using Imi.Project.Mobile.Dto_s;
using Imi.Project.Mobile.Interfaces;
using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class CalendarViewModel : FreshBasePageModel
    {
        private Random rnd = new Random();
        const string GroupIdKey = "GroupId";
        const string SelectedDateKey = "SelectedDate";
        protected readonly IApiService _apiService;

        
        public ICommand SelectionChanged { get; set; }
        public ICommand AddEvent { get; set; }
        public ICommand Details { get; set; }
        public ICommand NextPage => new Command(async () =>
        {
            await CoreMethods.PushPageModel<EventDetailViewModel>();
        });

        public CalendarViewModel(IApiService apiService)
        {
            
            _apiService = apiService;
            SelectionChanged = new Command<Syncfusion.SfCalendar.XForms.SelectionChangedEventArgs>(UpdateSelectedDate);
            AddEvent = new Command(GoToCreatePage);
            Details = new Command<InlineItemTappedEventArgs>(ShowDetails);

        }

        public CalendarViewModel()
        {
        }

        public IEnumerable<EventDto> events { get; set; }

        public IEnumerable<EventDto> Events
        {
            get { return events; }
            set
            {
                events = value;
                RaisePropertyChanged();
            }
        }

        public CalendarEventCollection convertedEvents { get; set; }

        public CalendarEventCollection ConvertedEvents
        {
            
            get { return convertedEvents; }
            set
            {
                convertedEvents = value;
                RaisePropertyChanged();
            }
        }


        protected override async void ViewIsAppearing(object sender, EventArgs e)
        {
            Events = await _apiService.GetEvents(await SecureStorage.GetAsync(GroupIdKey));
            var test = await SecureStorage.GetAsync(SelectedDateKey);
            if (test == null)
            {
                await SecureStorage.SetAsync(SelectedDateKey, DateTime.Today.ToString());
            }
            

            

            ConvertedEvents = new CalendarEventCollection();
            foreach (var item in Events)
            {
                ConvertedEvents.Add(new CalendarInlineEvent()
                {
                    Subject = item.Name,
                    StartTime = item.StartDate,
                    EndTime = item.EndDate,
                    Color = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)),
            });
            }
        }

        public async void GoToCreatePage()
        {
                     
            await CoreMethods.PushPageModel<CreateEventViewModel>();
        }

        private void ShowDetails(InlineItemTappedEventArgs e)
        {
            var appointment = e.InlineEvent;
            
        }


        public void UpdateSelectedDate(Syncfusion.SfCalendar.XForms.SelectionChangedEventArgs obj)
        {
            var date = obj.DateAdded.FirstOrDefault().Date;
            SecureStorage.SetAsync(SelectedDateKey, date.ToString());
            
        }

    }
}
