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
        private readonly Mappers _mappers;

        public PostMapper(Mappers mappers)
        {
            _mappers = mappers;
        }


        public PostListModel MapToPostListModel(PostEntity entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new PostListModel
            {
                Id = entity.Id,
                Title = entity.Title,
                Timestamp = entity.Timestamp,
                Author = _mappers.UserMapper.MapToUserDetailModel(entity.Author),                
            };
        }

        public PostDetailModel MapToPostDetailModel(PostEntity entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new PostDetailModel
            {
                Id = entity.Id,
                Title = entity.Title,
                Timestamp = entity.Timestamp,
                Content = entity.Content,
                Author = _mappers.UserMapper.MapToUserDetailModel(entity.Author),
                Comments = entity.Comments.AsEnumerable().Select(_mappers.CommentMapper.MapToCommentDetailModel).ToList()
            };
        }

        public PostEntity MapToPostEntity(PostDetailModel model)
        {
            if (model == null)
            {
                return null;
            }

            return new PostEntity()
            {
                Id = model.Id,
                Author = _mappers.UserMapper.MapToUserEntity(model.Author),
                Comments = model.Comments.AsEnumerable().Select(_mappers.CommentMapper.MapToCommentEntity).ToList(),
                Title = model.Title,
                Timestamp =  model.Timestamp,
                Content = model.Content,
            };
        }
    }
}