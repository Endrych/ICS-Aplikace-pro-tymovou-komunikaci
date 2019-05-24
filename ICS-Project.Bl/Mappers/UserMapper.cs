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
        private readonly TeamMapper _teamMapper;
        private readonly CommentMapper _commentMapper;
        private readonly PostMapper _postMapper;

        public UserMapper()
        {
            _teamMapper = new TeamMapper();
            _commentMapper = new CommentMapper();
            _postMapper = new PostMapper();
        }

        public UserListModel MapToUserListModel(UserEntity entity)
        {
            return new UserListModel
            {
                Id = entity.Id,
                Nickname = entity.Nickname,
            };
        }

        public UserLoginModel MapToUserLoginModel(UserEntity entity)
        {
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
            return new UserDetailModel
            {
                Id = entity.Id,
                Email = entity.Email,
                Nickname = entity.Nickname,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Password = entity.Password,
                Salt = entity.Salt,
                Comments = entity.Comments.AsEnumerable().Select(_commentMapper.MapToCommentDetailModelModel).ToList(),
                Posts = entity.Posts.AsEnumerable().Select(_postMapper.MapToPostDetailModel).ToList(),
                Teams = entity.UserTeams.AsEnumerable().Select(userTeam => _teamMapper.MapToTeamDetailModel(userTeam.Team)).ToList()
            };
        }

        public UserEntity MapToUserEntity(UserDetailModel modelAuthor)
        {
            var userEntity = new UserEntity()
            {
                Id = modelAuthor.Id,
                Password = modelAuthor.Password,
                Salt = modelAuthor.Salt,
                Email = modelAuthor.Email,
                Nickname = modelAuthor.Nickname,
                FirstName = modelAuthor.FirstName,
                LastName = modelAuthor.LastName,
                Comments = modelAuthor.Comments.AsEnumerable().Select(_commentMapper.MapToCommentEntity).ToList(),
                Posts = modelAuthor.Posts.AsEnumerable().Select(_postMapper.MapToPostEntity).ToList(),
            };

            userEntity.UserTeams = modelAuthor.Teams.AsEnumerable().Select(team => new UserTeamEntity()
            {
                UserId = modelAuthor.Id,
                User = userEntity,
                TeamId = team.Id,
                Team = _teamMapper.MapToTeamEntity(team)
            }).ToList();

            return userEntity;
        }
    }
}
