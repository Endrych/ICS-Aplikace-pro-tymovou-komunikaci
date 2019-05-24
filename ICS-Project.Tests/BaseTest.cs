using System;
using System.Collections.Generic;
using System.Linq;
using ICS_Project.Bl;
using ICS_Project.Bl.Factories;
using ICS_Project.Bl.Models;
using ICS_Project.Db;
using ICS_Project.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ICS_Project.Tests
{
    public class BaseTest
    {
        [Fact]
        public void SaveAndFindPostTest()
        {
            var dbContextFactory = new InMemoryDbContextFactory();

            var content = "Test";

            using (IcsDbContext context = dbContextFactory.CreateDbContext())
            {
                context.Posts.Add(new PostEntity() {Content = content, Timestamp = DateTime.Now});
                context.SaveChanges();
                var postFromDatabase = context.Posts.FirstOrDefault(post => post.Content == content);
                Assert.NotNull(postFromDatabase);
            }
        }

        [Fact]
        public void SavePostButNotFoundTest()
        {
            var dbContextFactory = new InMemoryDbContextFactory();

            var content = "Test1";

            using (IcsDbContext context = dbContextFactory.CreateDbContext())
            {
                context.Posts.Add(new PostEntity() { Content = content, Timestamp = DateTime.Now });
                context.SaveChanges();
                var postFromDatabase = context.Posts.FirstOrDefault(post => post.Content == "42");
                Assert.Null(postFromDatabase);
            }
        }

        [Fact]
        public void RegisterTest()
        {
            var dbContextFactory = new InMemoryDbContextFactory();
            var authentication = new Authentication(dbContextFactory);

            var user = new UserDetailModel()
            {
                Comments = new List<CommentDetailModel>(),
                Email = "test@gmail.com",
                FirstName = "David",
                LastName = "Endrych",
                Nickname = "david",
                Password = "testtest",
                Posts = new List<PostDetailModel>(),
                Teams = new List<TeamDetailModel>()
            };

            var newUser = authentication.Registration(user);
            Assert.NotEqual(Guid.Empty, newUser.Id);
            Assert.NotNull(newUser.Salt);
            Assert.NotEqual(newUser.Password, user.Password);

        }
    }
}
