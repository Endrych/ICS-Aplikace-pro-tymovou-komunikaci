using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ICS_Project.App.Commands;
using ICS_Project.Bl;
using ICS_Project.Bl.Factories;
using ICS_Project.Bl.Interfaces;
using ICS_Project.Bl.Models;
using System.Windows;
using ICS_Project.App.ViewModels.Base;
using ICS_Project.Bl.Messages;
using ICS_Project.Bl.Repositories;

namespace ICS_Project.App.ViewModels
{
    public class AuthenticationViewModel: ViewModelBase
    {
        private readonly IMessenger _messenger;
        private readonly IAuthentication _authentication = new Authentication(new DbContextFactory());
        private readonly UserRepository _userRepository = new UserRepository(new DbContextFactory());

        public UserLoginModel LoginModel { get; set; }
        public UserDetailModel RegisterModel { get; set; }

        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        public AuthenticationViewModel(IMessenger messenger)
        {
            _messenger = messenger;
            LoginModel = new UserLoginModel();
            RegisterModel = new UserDetailModel();
            LoginCommand = new RelayCommand(Login);
            RegisterCommand = new RelayCommand(Register);
        }

        private void Login()
        {
            var user = _authentication.Login(LoginModel);
            if (user == null)
            {
                MessageBox.Show("Invalid credentials");
                return;
            }
            _messenger.Send(new LoginMessage(user.Id));
        }

        public void Register()
        {
            if (!String.IsNullOrWhiteSpace(RegisterModel.Email) && !String.IsNullOrWhiteSpace(RegisterModel.Password))
            {
                var userExists = _userRepository.GetUserByEmail(RegisterModel.Email);
                if (userExists != null)
                {
                    MessageBox.Show("User already exists");
                    return;
                }
                
                var user = _authentication.Registration(RegisterModel);
                _messenger.Send(new LoginMessage(user.Id));
                return;
            }
            
            MessageBox.Show("Some information are missing");            
        }

        public void ResetScreen()
        {
            LoginModel = new UserLoginModel();
            RegisterModel = new UserDetailModel();
        }
    }
}
