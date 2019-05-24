using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICS_Project.App.ViewModels;
using ICS_Project.Bl;
using ICS_Project.Bl.Interfaces;

namespace ICS_Project.App
{
    public class ViewModelLocator
    {
        private readonly IMessenger _messenger = new Messenger();

        public MenuViewModel MenuViewModel { get; set; }
        public TeamEditViewModel TeamEditViewModel { get; set; }
        public AuthenticationViewModel AuthenticationViewModel { get; set; }
        public RootViewModel RootViewModel { get; set; }
        public ProfileViewModel ProfileViewModel { get; set; }
        public TeamViewModel TeamViewModel { get; set; }

        public ViewModelLocator()
        {
            MenuViewModel = new MenuViewModel(_messenger, this);
            TeamEditViewModel = new TeamEditViewModel(_messenger, this);
            AuthenticationViewModel = new AuthenticationViewModel(_messenger);
            RootViewModel = new RootViewModel(_messenger, this);
            ProfileViewModel = new ProfileViewModel(_messenger);
            TeamViewModel = new TeamViewModel(_messenger);
        }
    }
}
