using FreshMvvm;
using Imi.Project.Mobile.Dto_s;
using Imi.Project.Mobile.Interfaces;
using Newtonsoft.Json;
using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class EventDetailViewModel : FreshBasePageModel
    {
        const string GroupIdKey = "GroupId";
        const string SelectedDateKey = "SelectedDate";
        protected readonly IApiService _apiService;

        public EventDetailViewModel(IApiService apiService)
        {
            _apiService = apiService;
        }

  

        protected override async void ViewIsAppearing(object sender, EventArgs e)
        {
            Date = DateTime.Parse(SecureStorage.GetAsync(SelectedDateKey).Result);
            Apointment = JsonConvert.DeserializeObject<CalendarInlineEvent>(await SecureStorage.GetAsync("Appointment"));
            IEnumerable<EventDto> dto = await _apiService.GetEvents(await SecureStorage.GetAsync(GroupIdKey));
            Event = dto.FirstOrDefault(x=> x.StartDate == Apointment.StartTime && x.EndDate == Apointment.EndTime && x.Name == Apointment.Subject);
            Name = Event.Name;
            Description = Event.Description;
            StartTime = Event.StartDate.TimeOfDay;
            EndTime = Event.EndDate.TimeOfDay;
        }

        public EventDto evnt { get; set; }

        public EventDto Event
        {
            get { return evnt; }
            set
            {
                evnt = value;
                RaisePropertyChanged();
            }
        }

        public CalendarInlineEvent apointment { get; set; }

        public CalendarInlineEvent Apointment
        {
            get { return apointment; }
            set
            {
                apointment = value;
                RaisePropertyChanged();
            }
        }

        public DateTime date { get; set; }

        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                RaisePropertyChanged();
            }
        }

        public TimeSpan startTime { get; set; }
        public TimeSpan StartTime
        {
            get { return startTime; }
            set
            {
                startTime = value;
                RaisePropertyChanged();
            }
        }
        public TimeSpan endTime { get; set; }
        public TimeSpan EndTime
        {
            get { return endTime; }
            set
            {
                endTime = value;
                RaisePropertyChanged();

            }
        }

        public string name { get; set; }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged();

            }
        }
        public string description { get; set; }
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                RaisePropertyChanged();

            }
        }

        public string error { get; set; }
        public string Error
        {
            get { return error; }
            set
            {
                error = value;
                RaisePropertyChanged();

            }
        }

        public ICommand SubmitUpdate => new Command(async () =>
        {
            DateTime start = new DateTime(Date.Year, Date.Month, Date.Day, StartTime.Hours, StartTime.Minutes, StartTime.Seconds);
            DateTime end = new DateTime(Date.Year, Date.Month, Date.Day, EndTime.Hours, EndTime.Minutes, EndTime.Seconds);

            if (start.TimeOfDay > end.TimeOfDay)
            {
                Error = "Start time cannot be later than end time";
                return;
            }

            if (Description == null || Name == null)
            {
                Error = "Please fill in a name and a description";
                return;
            }

            var Dto = new UpdateEventDto
            {
                Description = Description,
                Name = Name,
                EventId = Event.EventId,
                StartDate = start,
                EndDate = end,
                GroupId = Event.GroupId,
                
            };

            await _apiService.UpdateEvent(Dto);
            await CoreMethods.PopPageModel();

        });

        public ICommand SubmitDelete => new Command(async () =>
        {
            await _apiService.DeleteEvent(Event.EventId.ToString());
            await CoreMethods.PopPageModel();
        });

        public ICommand TTS => new Command(async () =>
        {
           await TextToSpeech.SpeakAsync($"The name of this event is {Name}, the Description is {Description}. This event starts {Event.StartDate.ToString()} until {Event.EndDate.ToString()}");
        });

    }
}
