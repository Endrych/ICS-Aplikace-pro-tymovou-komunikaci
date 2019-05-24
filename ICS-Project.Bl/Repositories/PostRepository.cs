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
    public class PostRepository: IRepository<PostDetailModel>
    {
        private readonly Mappers.Mappers _mappers = new Mappers.Mappers();
        private readonly IDbContextFactory _dbContextFactory;

        public PostRepository(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public IEnumerable<PostDetailModel> GetPostDetailModels()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.Posts.AsEnumerable().Select(_mappers.PostMapper.MapToPostDetailModel).ToList();
            }
        }

        public PostDetailModel GetById(Guid id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return _mappers.PostMapper.MapToPostDetailModel(
                    context.Posts
                        .Where(post => post.Id == id)
                        .Include(post => post.Comments)
                        .FirstOrDefault());
            }
        }

        public PostDetailModel Insert(PostDetailModel item)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var entity = _mappers.PostMapper.MapToPostEntity(item);
                entity.Id = Guid.NewGuid();
                context.Entry(entity.Author).State = EntityState.Unchanged;
                context.Posts.Add(entity);
                context.SaveChanges();
                return _mappers.PostMapper.MapToPostDetailModel(entity);
            }
        }

        public void Update(PostDetailModel item)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var entity = _mappers.PostMapper.MapToPostEntity(item);
                context.Entry(entity.Author).State = EntityState.Modified;

                foreach (var commentEntity in entity.Comments)
                {
                    context.Entry(commentEntity).State = EntityState.Modified;
                }
                context.Posts.Update(entity);
                context.SaveChanges();
            }
        }

        public void Remove(Guid id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var entity = new PostEntity() { Id = id };
                context.Posts.Attach(entity);
                context.Posts.Remove(entity);
                context.SaveChanges();
            }
        }

        public ICollection<PostDetailModel> GetUserLastPosts(Guid id, int limit)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.Posts.Where(p => p.Author.Id == id).OrderByDescending(p=> p.Timestamp).Take(limit).AsEnumerable().Select(_mappers.PostMapper.MapToPostDetailModel).ToList();
            }
        }
    }
}
