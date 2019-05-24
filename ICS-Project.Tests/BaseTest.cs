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

            const string content = "Test";

            using (var context = dbContextFactory.CreateDbContext())
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

            const string content = "Test1";

            using (var context = dbContextFactory.CreateDbContext())
            {
                context.Posts.Add(new PostEntity() { Content = content, Timestamp = DateTime.Now });
                context.SaveChanges();
                var postFromDatabase = context.Posts.FirstOrDefault(post => post.Content == "42");
                Assert.Null(postFromDatabase);
            }
        }
    }
}
