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
    public class ViewModelAddPage:INotifyPropertyChanged
    {
        public int index { get; set; }
        public ObservableCollection<User> users { get; set; }
        public User user { get; set; }

        public ICommand AddCommand { get; set; }

        public ViewModelAddPage(ObservableCollection<User> users)
        {
            this.index = index;
            user = new();
            this.users = users;
            AddCommand = new Command(AddComand, CanAddCommand);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void AddComand(object? param)
        {
            users.Add(user);
            File.WriteAllText("..//..//..//Database\\Users.json", JsonSerializer.Serialize(users,new JsonSerializerOptions() { WriteIndented=true}));
            user = new();
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(user)));
        }
        public bool CanAddCommand(object? param)
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
