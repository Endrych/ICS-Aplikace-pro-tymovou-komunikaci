using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICS_Project.Bl.Models;
using ICS_Project.Db.Entities;

namespace ICS_Project.Bl.Mappers
{
    public class UserMapper
    {
        private readonly Mappers _mappers;

        public UserMapper()
        {
            _mappers = new Mappers();
        }

        public UserMapper(Mappers mappers)
        {
            _mappers = mappers;
        }

        public UserListModel MapToUserListModel(UserEntity entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new UserListModel
            {
                Id = entity.Id,
                Nickname = entity.Nickname,
                Email = entity.Email
            };
        }

        public UserLoginModel MapToUserLoginModel(UserEntity entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new UserLoginModel
            {
                Id = entity.Id,
                Email = entity.Email,
                Password = entity.Password,
                Salt = entity.Salt,
            };
        }

        public UserDetailModel MapToUserDetailModel(UserEntity entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new UserDetailModel
            {
                Id = entity.Id,
                Email = entity.Email,
                Nickname = entity.Nickname,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Password = entity.Password,
                Salt = entity.Salt,
            };
        }

        public UserEntity MapToUserEntity(UserDetailModel modelAuthor)
        {
            if (modelAuthor == null)
            {
                return null;
            }

            var userEntity = new UserEntity()
            {
                Id = modelAuthor.Id,
                Password = modelAuthor.Password,
                Salt = modelAuthor.Salt,
                Email = modelAuthor.Email,
                Nickname = modelAuthor.Nickname,
                FirstName = modelAuthor.FirstName,
                LastName = modelAuthor.LastName,
            };

            return userEntity;
        }

        public UserListModel MapDetailToListModel(UserDetailModel model)
        {
            return new UserListModel() {Email = model.Email, Id = model.Id, Nickname = model.Nickname};
        }
    }
}
