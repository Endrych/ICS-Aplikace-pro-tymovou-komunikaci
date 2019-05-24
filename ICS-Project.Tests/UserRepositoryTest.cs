using System;
using System.Collections.Generic;
using System.Linq;
using ICS_Project.Bl;
using ICS_Project.Bl.Factories;
using ICS_Project.Bl.Models;
using ICS_Project.Bl.Repositories;
using ICS_Project.Db;
using ICS_Project.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ICS_Project.Tests
{
    public class UserRepositoryTest
    {
        private readonly UserRepository _userRepository = new UserRepository(new InMemoryDbContextFactory());

        [Fact]
        public void InsertTest()
        {
            var user = new UserDetailModel()
            {
                Email = "jano@admin.cz",
                Password = "jelenovipivonelej",
                Salt = "jelenovipivonelej",
                Nickname = "Janci",
                FirstName = "Jan",
                LastName = "Pardavy"
            };
            var databaseUsr = _userRepository.Insert(user);

            Assert.NotNull(databaseUsr);
            Assert.Equal(databaseUsr.Email, user.Email);
            Assert.Equal(databaseUsr.Nickname, user.Nickname);
            Assert.Equal(databaseUsr.FirstName, user.FirstName);
            Assert.Equal(databaseUsr.LastName, user.LastName);

            _userRepository.Remove(databaseUsr.Id);
        }

        [Fact]
        public void GetUserByEmailTest()
        {
            var user = new UserDetailModel()
            {
                Email = "jano@admin.cz",
                Password = "jelenovipivonelej",
                Salt = "jelenovipivonelej",
                Nickname = "Janci",
                FirstName = "Jan",
                LastName = "Pardavy"
            };
            var databaseUsr = _userRepository.Insert(user);

            var checkUsr = _userRepository.GetUserByEmail(user.Email);

            Assert.Equal(databaseUsr.Email, checkUsr.Email);
            Assert.Equal(databaseUsr.Nickname, checkUsr.Nickname);
            Assert.Equal(databaseUsr.FirstName, checkUsr.FirstName);
            Assert.Equal(databaseUsr.LastName, checkUsr.LastName);
            _userRepository.Remove(databaseUsr.Id);
        }

        [Fact]
        public void GetUserByIdTest()
        {
            var user = new UserDetailModel()
            {
                Email = "jano@admin.cz",
                Password = "jelenovipivonelej",
                Salt = "jelenovipivonelej",
                Nickname = "Janci",
                FirstName = "Jan",
                LastName = "Pardavy"
            };
            var databaseUsr = _userRepository.Insert(user);

            var checkUsr = _userRepository.GetById(databaseUsr.Id);

            Assert.Equal(databaseUsr.Id, checkUsr.Id);
            Assert.Equal(databaseUsr.Email, checkUsr.Email);
            Assert.Equal(databaseUsr.Nickname, checkUsr.Nickname);
            Assert.Equal(databaseUsr.FirstName, checkUsr.FirstName);
            Assert.Equal(databaseUsr.LastName, checkUsr.LastName);
            _userRepository.Remove(databaseUsr.Id);
        }

        [Fact]
        public void GetUserListModelsTest()
        {
            var user = new UserDetailModel()
            {
                Email = "jano@admin.cz",
                Password = "jelenovipivonelej",
                Salt = "jelenovipivonelej",
                Nickname = "Janci",
                FirstName = "Jan",
                LastName = "Pardavy"
            };

            var users = _userRepository.GetUserListModels();
            foreach (var dbUser in users)
            {
                _userRepository.Remove(dbUser.Id);
            }

            _userRepository.Insert(user);
            _userRepository.Insert(user);

            var usersInDb = _userRepository.GetUserListModels();

            Assert.Equal(2,usersInDb.Count());
        }

    }
}
