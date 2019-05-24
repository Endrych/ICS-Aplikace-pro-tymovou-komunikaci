using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICS_Project.Bl.Factories;
using ICS_Project.Bl.Interfaces;
using ICS_Project.Bl.Mappers;
using ICS_Project.Bl.Models;
using ICS_Project.Db;
using ICS_Project.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace ICS_Project.Bl.Repositories
{
    public class UserRepository: IRepository<UserDetailModel>
    {
        private readonly UserMapper _userMapper;
        private readonly CommentMapper _commentMapper;
        private readonly PostMapper _postMapper;
        private readonly TeamMapper _teamMapper;
        private readonly IDbContextFactory _dbContextFactory;

        public UserRepository(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            //_teamMapper = new TeamMapper();
            //_userMapper = new UserMapper();
            //_commentMapper = new CommentMapper();
            //_postMapper = new PostMapper();
        }

        public IEnumerable<UserListModel> GetUserListModels()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.Users.AsEnumerable().Select(_userMapper.MapToUserListModel).ToList();
            }
        }

        public UserDetailModel GetById(Guid id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return _userMapper.MapToUserDetailModel(
                    context.Users
                        .Where(user => user.Id == id)
                        .Include(user => user.Posts)
                        .Include(user => user.Comments)
                        .Include(user => user.UserTeams)
                        .FirstOrDefault());
            }
        }

        public UserDetailModel GetUserByEmail(string email)
        {
            UserDetailModel userModel = null;

            using (var context = _dbContextFactory.CreateDbContext())
            {
                //userModel = _userMapper.MapToUserDetailModel(context.Users.FirstOrDefault(user => user.Email == email));
            }

            return userModel;
        }

        public UserDetailModel Insert(UserDetailModel item)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                //var entity = _userMapper.MapToUserEntity(item);
                //entity.Id = Guid.NewGuid();
                //context.Users.Add(entity);
                //context.SaveChanges();
                //return _userMapper.MapToUserDetailModel(entity);
            }
            return  new UserDetailModel();;
        }

        public void Update(UserDetailModel item)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                //var entity = context.Users.Include(user => user.UserTeams).Include(user => user.Posts).Include(user => user.Comments).First(user => user.Id == item.Id);
                //entity.Email = item.Email;
                //entity.Nickname = item.Nickname;
                //entity.FirstName = item.FirstName;
                //entity.LastName = item.LastName;
                //entity.Comments = item.Comments.Select(_commentMapper.MapToCommentEntity).ToList();
                //entity.Posts = item.Posts.Select(_postMapper.MapToPostEntity).ToList();
                //entity.UserTeams = item.Teams.Select(team => new UserTeamEntity { UserId = item.Id, User = entity, Team = _teamMapper.MapToTeamEntity(team), TeamId = team.Id }).ToList();
                //entity.UserTeams = item.Teams.Select(detailModel =>
                //{
                //    var teamEntity = _teamMapper.MapToTeamEntity(detailModel);
                //    if (context.Teams.Any(team => team.Id == teamEntity.Id))
                //    {
                //        teamEntity = context.Teams.Find(teamEntity.Id);
                //    }
                //    return teamEntity;
                //});
            }
        }

        public void Remove(Guid id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var entity = new UserEntity() { Id = id };
                context.Users.Attach(entity);
                context.Users.Remove(entity);
                context.SaveChanges();
            }
        }
    }
}
