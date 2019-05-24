using System;
using System.Collections.Generic;
using System.Text;
using ICS_Project.Bl.Models;
using ICS_Project.Db.Entities;

namespace ICS_Project.Bl.Mappers
{
    public class CommentMapper
    {
        private readonly Mappers _mappers;

        public CommentMapper()
        {
            _mappers = new Mappers();
        }

        public CommentMapper(Mappers mappers)
        {
            _mappers = mappers;
        }

        public CommentDetailModel MapToCommentDetailModel(CommentEntity entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new CommentDetailModel
            {
                Id = entity.Id,
                Timestamp = entity.Timestamp,
                Content = entity.Content,
                Author = _mappers.UserMapper.MapToUserDetailModel(entity.Author),
            };
        }

        public CommentEntity MapToCommentEntity(CommentDetailModel model)
        {
            if (model == null)
            {
                return null;
            }

            return new CommentEntity()
            {
                Id = model.Id,
                Timestamp = model.Timestamp,
                Content = model.Content,
                Author = _mappers.UserMapper.MapToUserEntity(model.Author),
            };
        }

    }
}
