using System;
using System.Collections.Generic;
using System.Text;
using ICS_Project.Bl.Models;
using ICS_Project.Db.Entities;

namespace ICS_Project.Bl.Mappers
{
    public class CommentMapper
    {
        private readonly PostMapper _postMapper;
        private readonly UserMapper _userMapper;

        public CommentMapper()
        {
            _postMapper = new PostMapper();
            _userMapper = new UserMapper();
        }

        public CommentDetailModel MapToCommentDetailModelModel(CommentEntity entity)
        {
            return new CommentDetailModel
            {
                Id = entity.Id,
                Timestamp = entity.Timestamp,
                Content = entity.Content,
                Author = _userMapper.MapToUserDetailModel(entity.Author),
                Post = _postMapper.MapToPostDetailModel(entity.Post)
            };
        }

        public CommentEntity MapToCommentEntity(CommentDetailModel model)
        {
            return new CommentEntity()
            {
                Id = model.Id,
                Timestamp = model.Timestamp,
                Content = model.Content,
                Author = _userMapper.MapToUserEntity(model.Author),
                Post = _postMapper.MapToPostEntity(model.Post)
            };
        }

    }
}
