using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICS_Project.Bl.Models;
using ICS_Project.Db.Entities;
using Microsoft.EntityFrameworkCore;


namespace ICS_Project.Bl.Mappers
{
    public class TeamMapper
    {
        private readonly Mappers _mappers;

        public TeamMapper(Mappers mappers)
        {
            _mappers = mappers;
        }

        public TeamListModel MapToTeamListModel(TeamEntity entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new TeamListModel
            {
                Id = entity.Id,
                Title = entity.Title,
                Admin = _mappers.UserMapper.MapToUserListModel(entity.Admin)
            };
        }

        public TeamDetailModel MapToTeamDetailModel(TeamEntity entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new TeamDetailModel
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Category = entity.Category,
                Posts = entity.Posts.AsEnumerable().Select(_mappers.PostMapper.MapToPostDetailModel).ToList(),
                Users = entity.Users.AsEnumerable().Select(_mappers.UserMapper.MapToUserDetailModel).ToList(),
                Admin = _mappers.UserMapper.MapToUserDetailModel(entity.Admin)
            };
        }

        public TeamEntity MapToTeamEntity(TeamDetailModel modelTeam)
        {
            if (modelTeam == null)
            {
                return null;
            }

            var teamEntity = new TeamEntity()
            {
                Id = modelTeam.Id,
                Category = modelTeam.Category,
                Description = modelTeam.Description,
                Posts = modelTeam.Posts.AsEnumerable().Select(_mappers.PostMapper.MapToPostEntity).ToList(),
                Title = modelTeam.Title,
                Admin = _mappers.UserMapper.MapToUserEntity(modelTeam.Admin),
                Users = modelTeam.Users.Select(_mappers.UserMapper.MapToUserEntity).ToList()
            };

            return teamEntity;
        }

        public TeamListModel MapDetailToList(TeamDetailModel team)
        {
            return new TeamListModel()
            {
                Admin = new UserListModel()
                {
                    Id = team.Admin.Id,
                    Nickname = team.Admin.Nickname
                },
                Id = team.Id,
                Title = team.Title
            };
        }
    }
}
