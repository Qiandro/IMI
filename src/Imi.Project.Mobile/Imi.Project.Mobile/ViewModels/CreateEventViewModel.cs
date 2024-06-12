using FreshMvvm;
using Imi.Project.Mobile.Dto_s.Events;
using Imi.Project.Mobile.Interfaces;
using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class CreateEventViewModel : FreshBasePageModel
    {
        const string GroupIdKey = "GroupId";
        const string SelectedDateKey = "SelectedDate";
        protected readonly IApiService _apiService;

        public CreateEventViewModel(IApiService apiService)
        {
            _apiService = apiService;


        }

        protected override async void ViewIsAppearing(object sender, EventArgs e)
        {
            Date = DateTime.Parse(SecureStorage.GetAsync(SelectedDateKey).Result);
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

        public ICommand SubmitCreate => new Command(async () =>
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


            var Dto = new CreateEventDto
            {
                Description = Description,
                Name = Name,
                GroupId = Guid.Parse(await SecureStorage.GetAsync(GroupIdKey)),
                StartDate = start,
                EndDate = end,
            };

            await _apiService.CreateEvent(Dto);
            Vibration.Vibrate();
            await CoreMethods.PopPageModel();

        });
    }
}
