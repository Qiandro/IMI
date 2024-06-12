using Imi.Project.Wpf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Group = Imi.Project.Wpf.Core.Entities.Group;

namespace Imi.Project.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public static readonly string url = "https://localhost:5001/api";

        public MainWindow()
        {
            InitializeComponent();
        }

        //methods for getting data 
        public void LoadData()
        {
            lstGroups.ItemsSource = null;
            var response = _httpClient.GetAsync(url + "/groups").Result;
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<Group> groups = response.Content.ReadAsAsync<IEnumerable<Group>>().Result;
                lstGroups.ItemsSource = groups;
            }

            IEnumerable<User> users = _httpClient.GetAsync(url + "/users").Result.Content.ReadAsAsync<IEnumerable<User>>().Result;

            cmbCreators.ItemsSource = users;
            cmbCreators.SelectedIndex = 0;
            btnCreate.IsEnabled = true;
        }

        public void SetCreator()
        {
            Group group = (Group)lstGroups.SelectedItem;
            var creatorsItemsource = (List<User>)cmbCreators.ItemsSource;
            var index = creatorsItemsource.IndexOf(creatorsItemsource.Where(a => a.Id == group.CreatorId).FirstOrDefault());
            cmbCreators.SelectedIndex = index;
        }

        public void EmptyControls()
        { 
            txtName.Text = "";

            lstCurrentAdmins.ItemsSource = null;
            lstCurrentMembers.ItemsSource = null;
            cmbCreators.ItemsSource = null;
            lstNonAdmins.ItemsSource = null;
            lstNonMembers.ItemsSource = null;
        }

        public void ToggleButtons(bool on)
        {
            if (!on)
            {
                btnSave.IsEnabled = false;
                btnDelete.IsEnabled = false;
            }
            else
            {
                btnSave.IsEnabled = true;
                btnDelete.IsEnabled = true;
            }
        }

        public void DisableMemberAdminButtons()
        {
            btnAddAdmin.IsEnabled = false;
            btnRemoveAdmin.IsEnabled = false;
            btnRemoveMember.IsEnabled = false;
            btnAddMember.IsEnabled = false;
        }

        public int GetGroupIndex()
        {
            Group group = (Group)lstGroups.SelectedItem;
            var GroupItemSource = (List<Group>)lstGroups.ItemsSource;
            var index = GroupItemSource.IndexOf(GroupItemSource.Where(a => a.Id == group.Id).FirstOrDefault());
            return index;
        }

        private List<User> FilterUsers(IEnumerable<User> Allusers, IEnumerable<User> FilterUsers)
        {
            var result = new List<User>();
            result.AddRange(Allusers);

            foreach (User user in FilterUsers)
            {
                result.Remove(result.Where(a => a.Id == user.Id).FirstOrDefault());
            }

            return result;
        }

        //wpf controls
        private void lstGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Group group = (Group)lstGroups.SelectedItem;

            if(group is null) 
            {
                EmptyControls();
                ToggleButtons(false);
            }
            else { 
            
                txtName.Text = group.Name;
                lstCurrentAdmins.ItemsSource = group.Admins;
                lstCurrentMembers.ItemsSource = group.Members;

                IEnumerable<User> users = _httpClient.GetAsync(url + "/users").Result.Content.ReadAsAsync<IEnumerable<User>>().Result;

                lstNonAdmins.ItemsSource = FilterUsers(group.Members, group.Admins);
                lstNonMembers.ItemsSource = FilterUsers(users, group.Members);

                ToggleButtons(true);
                SetCreator();
                DisableMemberAdminButtons();
            }
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Group group = (Group)lstGroups.SelectedItem;
            if (MessageBox.Show("Bent u zeker dat u dit event wilt verwijderen", "Verwijder Event", MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var response = await _httpClient.DeleteAsync(url + $"/Groups/{group.Id}");
                ToggleButtons(false);
                EmptyControls();
                LoadData();
            }
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bent u zeker dat u dit event wilt opslaan", "Sla Event op", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                User user = (User)cmbCreators.SelectedItem;
                Group group = (Group)lstGroups.SelectedItem;

                var index = GetGroupIndex();

                GroupUpdateRequestDto groupRequestDto = new GroupUpdateRequestDto
                {
                    Id = group.Id,
                    Img = "",
                    Name = txtName.Text,
                    CreatorId = user.Id,
                };
                var response = await _httpClient.PutAsJsonAsync(url + "/Groups", groupRequestDto);
                LoadData();

                lstGroups.SelectedIndex = index;
            }
        }

        private void btnGetData_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void lstCurrentMembers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnRemoveMember.IsEnabled = true;
        }

        private void lstNonMembers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnAddMember.IsEnabled = true;
        }

        private void lstCurrentAdmins_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnRemoveAdmin.IsEnabled = true;
        }

        private void lstNonAdmins_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnAddAdmin.IsEnabled = true;
        }


        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            User user = (User)cmbCreators.SelectedItem;

            var name = "";

            if (txtName.Text == "")
            {
                name = "New group";
            }
            else
            {
                name = txtName.Text;
            }

            GroupRequestDto groupRequestDto = new GroupRequestDto
            {
                CreatorId = user.Id,
                Img = "",
                Name = name

            };
            var response = await _httpClient.PostAsJsonAsync(url + "/Groups", groupRequestDto);

            LoadData();

        }

        private async void btnRemoveMember_Click(object sender, RoutedEventArgs e)
        {
            Group group = (Group)lstGroups.SelectedItem;
            User user = (User)lstCurrentMembers.SelectedItem;

            var index = GetGroupIndex();

            if (MessageBox.Show("Bent u zeker dat u deze user wilt verwijderen uit de groep", "Verwijder user uit groep", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var AdminResponse = await _httpClient.DeleteAsync(url + $"/Groups/{group.Id}/Admin/{user.Id}");
                var UserResponse = await _httpClient.DeleteAsync(url + $"/Groups/{group.Id}/User/{user.Id}");
                LoadData();
            }

            lstGroups.SelectedIndex = index; 
            //var response = await _httpClient.DeleteAsync(url + $"/Groups/{group.Id}/Admin/{user.Id}");


        }

        private async void btnRemoveAdmin_Click(object sender, RoutedEventArgs e)
        {
            Group group = (Group)lstGroups.SelectedItem;
            User user = (User)lstCurrentAdmins.SelectedItem;

            var index = GetGroupIndex();

            if (MessageBox.Show("Bent u zeker dat u deze user wilt verwijderen als admin", "Verwijder user als admin", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var response = await _httpClient.DeleteAsync(url + $"/Groups/{group.Id}/Admin/{user.Id}");
                LoadData();
            }

            lstGroups.SelectedIndex = index;

        }

        private async void btnAddMember_Click(object sender, RoutedEventArgs e)
        {
            User user = (User)lstNonMembers.SelectedItem;
            Group group = (Group)lstGroups.SelectedItem;

            var index = GetGroupIndex();

            GroupAddUserDto groupRequestDto = new GroupAddUserDto
            {
                UserId = user.Id,
                GroupId = group.Id,

            };
            var response = await _httpClient.PostAsJsonAsync(url + $"/Groups/{group.Id}/User/{user.Id}",groupRequestDto);
            LoadData();

            lstGroups.SelectedIndex = index;

        }

        private async void btnAddAdmin_Click(object sender, RoutedEventArgs e)
        {
            User user = (User)lstNonAdmins.SelectedItem;
            Group group = (Group)lstGroups.SelectedItem;

            var index = GetGroupIndex();

            GroupAddUserDto groupRequestDto = new GroupAddUserDto
            {
                UserId = user.Id,
                GroupId = group.Id,

            };
            var response = await _httpClient.PostAsJsonAsync(url + $"/Groups/{group.Id}/Admin/{user.Id}", groupRequestDto);
            LoadData();

            lstGroups.SelectedIndex = index;

        }
    }
}
