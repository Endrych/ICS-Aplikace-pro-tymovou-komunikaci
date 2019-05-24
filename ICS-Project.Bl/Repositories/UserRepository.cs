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
        private readonly UserMapper _userMapper = new UserMapper();
        private readonly IDbContextFactory _dbContextFactory;

        public UserRepository(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
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
                        .FirstOrDefault(user => user.Id == id));
            }
        }

        public UserDetailModel GetUserByEmail(string email)
        {
            UserDetailModel userModel = null;

            using (var context = _dbContextFactory.CreateDbContext())
            {
                userModel = _userMapper.MapToUserDetailModel(context.Users.FirstOrDefault(user => user.Email == email));
            }

            return userModel;
        }

        public UserDetailModel Insert(UserDetailModel item)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var entity = _userMapper.MapToUserEntity(item);
                entity.Id = Guid.NewGuid();
                context.Users.Add(entity);
                context.SaveChanges();
                return _userMapper.MapToUserDetailModel(entity);
            }
        }

        public void Update(UserDetailModel item)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var entity = _userMapper.MapToUserEntity(item);
                context.Users.Update(entity);
                context.SaveChanges();
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
