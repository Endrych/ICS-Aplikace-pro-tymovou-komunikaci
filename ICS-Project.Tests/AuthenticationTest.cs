using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICS_Project.Bl;
using ICS_Project.Bl.Interfaces;
using ICS_Project.Bl.Models;
using ICS_Project.Bl.Repositories;
using Xunit;

namespace ICS_Project.Tests
{
    public class AuthenticationTest
    {
        private readonly UserRepository _userRepository = new UserRepository(new InMemoryDbContextFactory());

        [Fact]
        public void RegisterTest()
        {
            var authentication = new Authentication(new InMemoryDbContextFactory());
            const string password = "testtest";

            var user = new UserDetailModel()
            {
                Email = "test@gmail.com",
                FirstName = "David",
                LastName = "Endrych",
                Nickname = "david",
                Password = password,
            };

            var newUser = authentication.Registration(user);
            Assert.NotEqual(Guid.Empty, newUser.Id);
            Assert.NotNull(newUser.Salt);
            Assert.NotEqual(newUser.Password, password);

            using (var context = new InMemoryDbContextFactory().CreateDbContext())
            {
                var databaseUser = context.Users.FirstOrDefault(u => u.Id == newUser.Id);
                Assert.NotNull(databaseUser);
                Assert.Equal(newUser.Email, databaseUser.Email);
                Assert.Equal(newUser.Password, databaseUser.Password);
                Assert.Equal(newUser.FirstName, databaseUser.FirstName);
                Assert.Equal(newUser.LastName, databaseUser.LastName);
            }
        }

        [Fact]
        public void SuccessfullyLoginTest()
        {
            var authentication = new Authentication(new InMemoryDbContextFactory());
            const string password = "testtest";
            const string email = "test6@gmail.com";
            const string firstName = "David";
            const string lastName = "Endrych";

            var user = new UserDetailModel()
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Nickname = "david",
                Password = password,
            };

            var newUser = authentication.Registration(user);

            var loginModel = authentication.Login(new UserLoginModel()
            {
                Email = email,
                Password = password
            });

            Assert.NotNull(loginModel);
            Assert.Equal(loginModel.FirstName, firstName);
            Assert.Equal(loginModel.LastName, lastName);
        }

        [Fact]
        public void UnsuccessfullyLoginTest()
        {
            var authentication = new Authentication(new InMemoryDbContextFactory());
            var password = "testtest";
            var email = "test2@gmail.com";
            var firstName = "David";
            var lastName = "Endrych";

            var user = new UserDetailModel()
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Nickname = "david",
                Password = password,
            };

            var newUser = authentication.Registration(user);

            var loginModel = authentication.Login(new UserLoginModel()
            {
                Email = email,
                Password = "testtest1"
            });

            Assert.Null(loginModel);
            _userRepository.Remove(newUser.Id);
        }
    }
}
