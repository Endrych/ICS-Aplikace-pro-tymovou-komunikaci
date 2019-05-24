using ICS_Project.Bl.Models;
using ICS_Project.Db.Entities;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;


namespace ICS_Project.Bl.Mappers
{
    public class PostMapper
    {
        private readonly UserMapper _userMapper;
        private readonly TeamMapper _teamMapper;
        private readonly CommentMapper _commentMapper;

        public PostMapper()
        {
            _userMapper = new UserMapper();
            _teamMapper = new TeamMapper();
            _commentMapper = new CommentMapper();
        }

        public PostListModel MapToPostListModel(PostEntity entity)
        {
            return new PostListModel
            {
                Id = entity.Id,
                Title = entity.Title,
                Timestamp = entity.Timestamp,
                Author = _userMapper.MapToUserDetailModel(entity.Author),                
            };
        }

        public PostDetailModel MapToPostDetailModel(PostEntity entity)
        {
            return new PostDetailModel
            {
                Id = entity.Id,
                Title = entity.Title,
                Timestamp = entity.Timestamp,
                Content = entity.Content,
                Author = _userMapper.MapToUserDetailModel(entity.Author),
                Team =  _teamMapper.MapToTeamDetailModel(entity.Team),
                Comments = entity.Comments.AsEnumerable().Select(_commentMapper.MapToCommentDetailModelModel).ToList()
            };
        }

        public PostEntity MapToPostEntity(PostDetailModel model)
        {
            return new PostEntity()
            {
                Id = model.Id,
                Author = _userMapper.MapToUserEntity(model.Author),
                Comments = model.Comments.AsEnumerable().Select(_commentMapper.MapToCommentEntity).ToList(),
                Title = model.Title,
                Timestamp =  model.Timestamp,
                Content = model.Content,
                Team = _teamMapper.MapToTeamEntity(model.Team)
            };
        }
    }
}