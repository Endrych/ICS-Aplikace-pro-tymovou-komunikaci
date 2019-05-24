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
    public class TeamRepositoryTest
    {
        [Fact]
        public void InsertTest()
        {
            var teamRepository = new TeamRepository(new InMemoryDbContextFactory());
            var userRepository = new UserRepository(new InMemoryDbContextFactory());

            var user1 = new UserDetailModel()
            {
                Email = "jano@admin.cz",
                Password = "jelenovipivonelej",
                Salt = "jelenovipivonelej",
                Nickname = "Janci",
                FirstName = "Jan",
                LastName = "Pardavy"
            };

            var user2 = new UserDetailModel()
            {
                Email = "kamos@janov.com",
                Password = "1234567890",
                Salt = "0987654321",
                Nickname = "ololko",
                FirstName = "Oliver",
                LastName = "Luppolo"
            };

            var dbUser1 = userRepository.Insert(user1);
            var dbUser2 = userRepository.Insert(user2);


            var comment = new CommentDetailModel()
            {
                Timestamp = DateTime.Now,
                Author = dbUser2,
                Content = "Dneska som mala na obed kuraci steak"
            };

            var post = new PostDetailModel()
            {
                Title = "First post",
                Comments = new List<CommentDetailModel>() { comment }
            };

            var team = new TeamDetailModel()
            {
                Title = "Alfalfa Team",
                Description = "Our first team",
                Category = "ISC",
                Admin = dbUser1,
                Users = new List<UserDetailModel> { dbUser2 },
                Posts = new List<PostDetailModel>() { post }
            };

            var insertedModel = teamRepository.Insert(team);
            var teamDatabase = teamRepository.GetById(insertedModel.Id);

            Assert.NotNull(teamDatabase);
            Assert.Equal(team.Title, teamDatabase.Title);
            Assert.Equal(team.Description, teamDatabase.Description);
            Assert.Equal(team.Category, teamDatabase.Category);
            Assert.Equal(team.Users.Count, teamDatabase.Users.Count);
            Assert.Equal(team.Posts.Count, teamDatabase.Posts.Count);

            teamRepository.Remove(insertedModel.Id);
        }

        [Fact]
        public void UpdateTest()
        {
            var teamRepository = new TeamRepository(new InMemoryDbContextFactory());
            var userRepository = new UserRepository(new InMemoryDbContextFactory());


            var user = new UserDetailModel()
            {
                Email = "kamos@janov.com",
                Password = "1234567890",
                Salt = "0987654321",
                Nickname = "ololko",
                FirstName = "Oliver",
                LastName = "Luppolo"
            };

            var dbUser = userRepository.Insert(user);

            var team = new TeamDetailModel()
            {
                Title = "Alfalfa Team",
                Description = "Our first team",
                Category = "ISC",
                Admin = dbUser,
                Users = new List<UserDetailModel>(),
                Posts = new List<PostDetailModel>()
            };

            var insertedModel = teamRepository.Insert(team);

            insertedModel.Title = "Beta Team";
            insertedModel.Description = "Our SECOND team";
            insertedModel.Category = "Testovanie a dynamicka analyza";

            teamRepository.Update(insertedModel);

            var teamDatabase = teamRepository.GetById(insertedModel.Id);
            Assert.NotNull(teamDatabase);
            Assert.Equal(insertedModel.Title, teamDatabase.Title);
            Assert.Equal(insertedModel.Description, teamDatabase.Description);
            Assert.Equal(insertedModel.Category, teamDatabase.Category);
            Assert.Equal(insertedModel.Users.Count, teamDatabase.Users.Count);
            Assert.Equal(insertedModel.Posts.Count, teamDatabase.Posts.Count);

            teamRepository.Remove(insertedModel.Id);
        }

        [Fact]
        public void RemoveTest()
        {
            var teamRepository = new TeamRepository(new InMemoryDbContextFactory());
            var userRepository = new UserRepository(new InMemoryDbContextFactory());

            var user = new UserDetailModel()
            {
                Email = "kamos@janov.com",
                Password = "1234567890",
                Salt = "0987654321",
                Nickname = "ololko",
                FirstName = "Oliver",
                LastName = "Luppolo"
            };

            var dbUser = userRepository.Insert(user);

            var team = new TeamDetailModel()
            {
                Title = "Alfalfa Team",
                Description = "Our first team",
                Category = "ISC",
                Admin = dbUser,
                Users = new List<UserDetailModel>(),
                Posts = new List<PostDetailModel>()
            };

            var insertedModel = teamRepository.Insert(team);

            var teamDatabase = teamRepository.GetById(insertedModel.Id);
            Assert.NotNull(teamDatabase);
            Assert.Equal(team.Title, teamDatabase.Title);
            Assert.Equal(team.Description, teamDatabase.Description);
            Assert.Equal(team.Category, teamDatabase.Category);
            Assert.Equal(team.Users.Count, teamDatabase.Users.Count);
            Assert.Equal(team.Posts.Count, teamDatabase.Posts.Count);

            teamRepository.Remove(insertedModel.Id);
            teamDatabase = teamRepository.GetById(insertedModel.Id);
            Assert.Null(teamDatabase);
        }

        [Fact]
        public void GetUserTeamsByIdTest()
        {
            var teamRepository = new TeamRepository(new InMemoryDbContextFactory());
            var userRepository = new UserRepository(new InMemoryDbContextFactory());

            var user = new UserDetailModel()
            {
                Email = "jano@admin.cz",
                Password = "jelenovipivonelej",
                Salt = "jelenovipivonelej",
                Nickname = "Janci",
                FirstName = "Jan",
                LastName = "Pardavy"
            };  

            var databaseUsr = userRepository.Insert(user);

            var team1 = new TeamDetailModel()
            {
                Title = "Alfalfa Team",
                Description = "Our first team",
                Category = "ISC",
                Admin = databaseUsr,
                Users = new List<UserDetailModel>(),
                Posts = new List<PostDetailModel>()
            };


            var team2 = new TeamDetailModel()
            {
                Title = "BetaBeta Team",
                Description = "Our first team",
                Category = "ISC",
                Admin = databaseUsr,
                Users = new List<UserDetailModel>(),
                Posts = new List<PostDetailModel>()
            };

            teamRepository.Insert(team1);
            teamRepository.Insert(team2);

            var usersTeams = teamRepository.GetByUserId(databaseUsr.Id);

            Assert.Equal(2, usersTeams.Count());
            userRepository.Remove(databaseUsr.Id);
            teamRepository.Remove(team1.Id);
            teamRepository.Remove(team2.Id);
        }
    }
}
