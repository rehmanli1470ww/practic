using practic.Commands;
using practic.Models;
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
    public class ViewModeEdit:INotifyPropertyChanged
    {
        private User? user1;

        public event PropertyChangedEventHandler? PropertyChanged;

        public User? user { get => user1; set { user1 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(user))); } }
        public ICommand? EditCommand { get; set; }
        public ObservableCollection<User> Users { get; }
        public int Index { get; }

        public ViewModeEdit(ObservableCollection<User>users,int index)
        {
            EditCommand = new Command(Editcomand, CanEditCommand);
            Users = users;
            Index = index;
            user= users[index]; 
        }
        public void Editcomand(object? param)
        {

            Users[Index] = new();
            Users[Index]=user!;
            File.WriteAllText("..//..//..//Database\\Users.json", JsonSerializer.Serialize(Users, new JsonSerializerOptions() { WriteIndented = true }));
            ((Page)param).NavigationService.GoBack();


        }
        public bool CanEditCommand(object? param)
        {
            return !string.IsNullOrWhiteSpace(user.name) &&
                      !string.IsNullOrWhiteSpace(user.username) &&
                      !string.IsNullOrWhiteSpace(user.email) &&
                      !string.IsNullOrWhiteSpace(user.id.ToString()) &&
                      !string.IsNullOrWhiteSpace(user.address.city) &&
                      !string.IsNullOrWhiteSpace(user.address.street) &&
                      !string.IsNullOrWhiteSpace(user.company.name) &&
                      !string.IsNullOrWhiteSpace(user.company.bs);
        }

    }
}
