using System;
using System.Collections.Generic;
using System.Text;
using ICS_Project.Bl;
using ICS_Project.Bl.Interfaces;
using ICS_Project.Bl.Models;
using Xunit;

namespace ICS_Project.Tests
{
    public class AuthenticationTest
    {
        [Fact]
        public void RegisterTest()
        {
            var authentication = new Authentication(new InMemoryDbContextFactory());

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
