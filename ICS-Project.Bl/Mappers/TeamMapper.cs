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
        private readonly PostMapper _postMapper;
        private readonly UserMapper _userMapper;

        public TeamMapper()
        {
            _postMapper = new PostMapper();
            _userMapper = new UserMapper();
        }

        public TeamListModel MapToTeamListModel(TeamEntity entity)
        {
            return new TeamListModel
            {
                Id = entity.Id,
                Title = entity.Title,
            };
        }

        public TeamDetailModel MapToTeamDetailModel(TeamEntity entity)
        {
            return new TeamDetailModel
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Category = entity.Category,
                Posts = entity.Posts.AsEnumerable().Select(_postMapper.MapToPostDetailModel).ToList(),
                Users = entity.UserTeams.AsEnumerable().Select(userTeam => _userMapper.MapToUserDetailModel(userTeam.User)).ToList()
            };
        }

        public TeamEntity MapToTeamEntity(TeamDetailModel modelTeam)
        {
            var teamEntity = new TeamEntity()
            {
                Id = modelTeam.Id,
                Category = modelTeam.Category,
                Description = modelTeam.Description,
                Posts = modelTeam.Posts.AsEnumerable().Select(_postMapper.MapToPostEntity).ToList(),
                Title = modelTeam.Title,
            };

            teamEntity.UserTeams = modelTeam.Users.AsEnumerable().Select(user => new UserTeamEntity()
            {
                User = _userMapper.MapToUserEntity(user),
                UserId = user.Id,
                TeamId = modelTeam.Id,
                Team = teamEntity
            }).ToList();

            return teamEntity;
        }
    }
}
