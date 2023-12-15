using practic.Commands;
using practic.Models;
using practic.Views.ViewPages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace practic.ViewModels.ViewModelPages
{
    public class ViewModelEntry:INotifyPropertyChanged
    {
        private User? user1;

        public ObservableCollection<User>?users { get; set; }
        public User? user { get => user1; set { user1 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(user))); } }

        public ICommand ?AddCommand { get; set; }
        public ICommand ? RemoveCommand { get; set; }
        public ICommand ? EditCommand { get; set; }
        public ICommand ? GetAllCommand { get; set; }
        public ViewModelEntry()
        {
            user = new();
            users = new(JsonSerializer.Deserialize<List<User>>(File.ReadAllText("..//..//..//Database\\Users.json"))!);

            GetAllCommand = new Command(GetAllCom,CanGetAll);
            RemoveCommand = new Command(Removecomand, CanremoveCommand);
            AddCommand = new Command(AddComand,CanAddCommand);
            EditCommand = new Command(Editcomand, CanEditCommand);
           
        }

        private bool CanGetAll(object? obj)
        {
            return users?.Count != 0;
        }

        private void GetAllCom(object? obj)
        {
            Page page =new ViewGetAll();
            page.DataContext = new ViewModelGetAll(users);
            ((Page)obj!).NavigationService.Navigate(page);  
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void AddComand(object? param)
        {
            Page? page = ((Page)param);
            //var stackpanel = page.FindName("stackpanell");
            //var combo = ((StackPanel)stackpanel).FindName("combobox");
            //user = users[((ComboBox)combo).SelectedIndex];
            Page pagee = new ViewAddPage();
            var datacon = new ViewModelAddPage(users);
            pagee.DataContext = datacon;
            page.NavigationService.Navigate(pagee);
                
        }
        public bool CanAddCommand(object? param)
        {
            return true;
        }
        public void Removecomand(object? param)
        {
            users.RemoveAt((int)param);
            File.WriteAllText("..//..//..//Database\\Users.json", JsonSerializer.Serialize(users, new JsonSerializerOptions() { WriteIndented = true }));


        }
        public bool CanremoveCommand(object? param)
        {
            return (int)param!=-1;
        }
        public void Editcomand(object? param)
        {
            Page? page = ((Page)param);
            var stackpanel = page.FindName("stackpanell");
            var combo = ((StackPanel)stackpanel).FindName("combobox");
            user = users[((ComboBox)combo).SelectedIndex];
            Page pagee = new ViewEdit();
            var datacon = new ViewModeEdit(users, ((ComboBox)combo).SelectedIndex);
            pagee.DataContext = datacon;
            page.NavigationService.Navigate(pagee);


        }
        public bool CanEditCommand(object? param)
        {
            Page? page = ((Page)param);
            var stackpanel = page.FindName("stackpanell");
            var combo = ((StackPanel)stackpanel).FindName("combobox");
            return ((ComboBox)combo).SelectedIndex != -1;

        }
    }
}
