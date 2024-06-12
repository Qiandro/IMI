using FreshMvvm;
using Imi.Project.Mobile.Dto_s;
using Imi.Project.Mobile.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class GroupListViewModel : FreshBasePageModel
    {
        const string GroupIdKey = "GroupId";
        protected readonly IApiService _apiService;

        public IEnumerable<GroupDto> groups { get; set; }

        public IEnumerable<GroupDto> Groups
        {
            get { return groups; }
            set
            {
                groups = value;
                RaisePropertyChanged();
            }
        }

        public ICommand OpenGroupHomePageCommand => new Command<ItemTappedEventArgs>(
            async (ItemTappedEventArgs e) => {
                var group = Groups.ElementAt(e.ItemIndex);
                await SecureStorage.SetAsync(GroupIdKey, group.Id.ToString());
                await CoreMethods.PushPageModel<CalendarViewModel>();
            }
        );

        public GroupListViewModel(IApiService apiService)
        {
            _apiService = apiService;
        }

        protected override async void ViewIsAppearing(object sender, EventArgs e)
        {
            Groups = await _apiService.GetGroups();
        }

    }
}
