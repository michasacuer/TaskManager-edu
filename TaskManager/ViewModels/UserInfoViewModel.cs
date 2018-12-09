using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using TaskManager.Models;

namespace TaskManager.ViewModels
{
    class UserInfoViewModel : Screen
    {
        public string LoggedUserFullName { get; set; }
        public string LoggedUserJob { get; set; }

        public UserInfoViewModel(LoggedUser loggedUser)
        {
            LoggedUserFullName = loggedUser.GetFullName();
            NotifyOfPropertyChange(() => LoggedUserFullName);

            LoggedUserJob = loggedUser.GetPosition();
            NotifyOfPropertyChange(() => LoggedUserJob);
        }

        public void LogoutButton() => TryClose();
    }
}
