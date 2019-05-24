using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ICS_Project.App.Commands;
using ICS_Project.App.ViewModels.Base;
using ICS_Project.Bl.Factories;
using ICS_Project.Bl.Interfaces;
using ICS_Project.Bl.Messages;
using ICS_Project.Bl.Models;
using ICS_Project.Bl.Repositories;

namespace ICS_Project.App.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;
        private readonly ViewModelLocator _locator;
        private readonly UserRepository _userRepository = new UserRepository(new DbContextFactory());
        private readonly TeamRepository _teamRepository = new TeamRepository(new DbContextFactory());
        private ViewModelBase _selectedViewModel;
        private TeamListModel _selectedTeam;
        public ICommand LogoutCommand { get; set; }
        public ICommand CreateTeamCommand { get; set; }
        public ICommand ShowTeamCommand { get; set; }
        public ICommand ShowProfileCommand { get; set; }
        public UserDetailModel User { get; set; }
        public ObservableCollection<TeamListModel> Teams { get; set; }

        public TeamListModel SelectedTeam
        {
            get => _selectedTeam;
            set
            {
                if (Equals(value, _selectedTeam)) return;
                _selectedTeam = value;
                OnPropertyChanged();
            }
        }

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

        public MenuViewModel(IMessenger messenger, ViewModelLocator locator)
        {
            _messenger = messenger;
            _locator = locator;
            LogoutCommand = new RelayCommand(Logout);
            CreateTeamCommand = new RelayCommand(CreateTeam);
            ShowProfileCommand = new RelayCommand(ShowProfile);
            _messenger.Register<ShowTeamProfileMessage>(ReactOnShowMessage);
            ShowTeamCommand = new RelayCommand(ReactOnShowTeamDetailCommand);
        }

        public void Load(Guid id)
        {
            User = _userRepository.GetById(id);
            Teams =  new ObservableCollection<TeamListModel>(_teamRepository.GetByUserId(id).ToList());
            SelectedViewModel = _locator.ProfileViewModel;
            _locator.ProfileViewModel.Load(id);
        }

        private void Logout()
        {
            this.User = new UserDetailModel();
            this._messenger.Send(new LogoutMessage());
        }

        private void CreateTeam()
        {
            var model = _locator.TeamEditViewModel;
            model.ResetScreen();
            SelectedViewModel = model;
        }

        private void ReactOnShowMessage(ShowTeamProfileMessage message)
        {
            ShowTeamProfile(message.Id);
        }

        private void ShowTeamProfile(Guid id)
        {
            SelectedViewModel = _locator.TeamViewModel;
            _locator.TeamViewModel.Load(User.Id, id);
        }

        private void ReactOnShowTeamDetailCommand()
        {
            ShowTeamProfile(SelectedTeam.Id);
        }

        private void ShowProfile()
        {
            var model = _locator.ProfileViewModel;
            SelectedViewModel = model;
            model.Load(User.Id);
        }
    }
}
