using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ICS_Project.App.Commands;
using ICS_Project.App.ViewModels.Base;
using ICS_Project.Bl.Factories;
using ICS_Project.Bl.Interfaces;
using ICS_Project.Bl.Mappers;
using ICS_Project.Bl.Messages;
using ICS_Project.Bl.Models;
using ICS_Project.Bl.Repositories;

namespace ICS_Project.App.ViewModels
{
    public class TeamEditViewModel: ViewModelBase
    {
        private readonly TeamRepository _teamRepository = new TeamRepository(new DbContextFactory());
        private readonly Mappers _mappers = new Mappers();
        private readonly IMessenger _messenger;
        private readonly ViewModelLocator _locator;

        public TeamDetailModel Team { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public TeamEditViewModel(IMessenger messenger, ViewModelLocator locator)
        {
            _locator = locator;
            _messenger = messenger;
            SaveCommand = new RelayCommand(Save);
            DeleteCommand = new RelayCommand(Delete);
            Team = new TeamDetailModel();
        }

        public void ResetScreen()
        {
            Team = new TeamDetailModel();
        }

        public void Load(Guid id)
        {
            _teamRepository.GetById(id);
        }

        public void Save()
        {
            if (String.IsNullOrWhiteSpace(Team.Category) || String.IsNullOrWhiteSpace(Team.Title))
            {
                MessageBox.Show("Invalid credentials");
                return;
            }
            
            Team.Admin = _locator.MenuViewModel.User;
            if (Team.Id == Guid.Empty)
            {
                Team = _teamRepository.Insert(Team);
                _locator.MenuViewModel.Teams.Add(_mappers.TeamMapper.MapDetailToList(Team));
            }
            else
            {
                _teamRepository.Update(Team);
            }
            _messenger.Send(new ShowTeamProfileMessage(Team.Id));
        }

        public void Delete()
        {
            _teamRepository.Remove(Team.Id);
        }
    }
}
