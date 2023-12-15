using practic.Commands;
using practic.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace practic.ViewModels.ViewModelPages
{
    public class ViewModelGetAll
    {
        public ICommand GoBack { get; set; }
        public ObservableCollection<User> users { get; set; }
        public ViewModelGetAll(ObservableCollection<User> users)
        {
            GoBack = new Command(GoBackCommand, _ => true);
            this.users = users;
        }

        private void GoBackCommand(object? obj)
        {
            ((Page)obj).NavigationService.GoBack();
        }
    }
}
