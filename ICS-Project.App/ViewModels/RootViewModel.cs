using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICS_Project.App.ViewModels.Base;
using ICS_Project.Bl.Interfaces;
using ICS_Project.Bl.Messages;

namespace ICS_Project.App.ViewModels
{
    public class RootViewModel: ViewModelBase
    {
        private readonly IMessenger _messenger;
        private readonly ViewModelLocator _locator;
        private ViewModelBase _selectedViewModel;

        public ViewModelBase SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                if (Equals(value, _selectedViewModel)) return;
                _selectedViewModel = value;
                OnPropertyChanged();
            }
        }

        public RootViewModel(IMessenger messenger, ViewModelLocator locator)
        {
            _messenger = messenger;
            _locator = locator;
            this._messenger.Register<LoginMessage>(ShowMainView);
            this._messenger.Register<LogoutMessage>(ShowAuthenticationView);
            SelectedViewModel = _locator.AuthenticationViewModel;
        }

        private void ShowMainView(LoginMessage message)
        {
            var model = _locator.MenuViewModel;
            model.Load(message.Id);
            SelectedViewModel = model;
            _locator.AuthenticationViewModel.ResetScreen();
        }

        private void ShowAuthenticationView(LogoutMessage message)
        {
            SelectedViewModel = _locator.AuthenticationViewModel;
        }

    }
}
