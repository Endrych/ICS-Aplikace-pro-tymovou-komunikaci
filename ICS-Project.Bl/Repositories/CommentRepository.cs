using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ICS_Project.Bl.Interfaces;
using ICS_Project.Bl.Mappers;
using ICS_Project.Bl.Models;
using ICS_Project.Db;
using ICS_Project.Db.Entities;
using Microsoft.EntityFrameworkCore;
using ICS_Project.Bl.Factories;

namespace ICS_Project.Bl.Repositories
{
    public class CommentRepository:IRepository<CommentDetailModel>
    {
        private readonly Mappers.Mappers _mappers = new Mappers.Mappers();
        private readonly IDbContextFactory _dbContextFactory;

        public CommentRepository(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public CommentDetailModel GetById(Guid id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return _mappers.CommentMapper.MapToCommentDetailModel(
                    context.Comments
                        .FirstOrDefault(comment => comment.Id == id));
            }
        }

        public CommentDetailModel Insert(CommentDetailModel item)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var entity = _mappers.CommentMapper.MapToCommentEntity(item);
                entity.Id = Guid.NewGuid();
                context.Entry(entity.Author).State = EntityState.Unchanged;
                context.Comments.Add(entity);
                context.SaveChanges();
                return _mappers.CommentMapper.MapToCommentDetailModel(entity);
            }
        }

        public void Update(CommentDetailModel item)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var entity = _mappers.CommentMapper.MapToCommentEntity(item);
                context.Comments.Update(entity);
                context.SaveChanges();
            }
        }

        public void Remove(Guid id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var entity = new CommentEntity() { Id = id};
                context.Comments.Attach(entity);
                context.Comments.Remove(entity);
                context.SaveChanges();
            }
        }

        public ICollection<CommentDetailModel> GetUserLastComments(Guid id, int limit)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.Comments.Where(p => p.Author.Id == id).OrderByDescending(p => p.Timestamp).Take(limit).AsEnumerable().Select(_mappers.CommentMapper.MapToCommentDetailModel).ToList();
            }
        }
    }
}
