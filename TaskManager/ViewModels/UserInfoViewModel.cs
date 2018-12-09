using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;


namespace TaskManager.ViewModels
{
    class UserInfoViewModel : Screen
    {
        public void CancelButton()
        {
            TryClose();
        }
    }
}
