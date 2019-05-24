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
using Remotion.Linq.Clauses;

namespace ICS_Project.Bl.Repositories
{
    public class TeamRepository:IRepository<TeamDetailModel>
    {
        private readonly Mappers.Mappers _mappers = new Mappers.Mappers();
        private readonly IDbContextFactory _dbContextFactory;

        public TeamRepository(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public TeamDetailModel GetById(Guid id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return _mappers.TeamMapper.MapToTeamDetailModel(
                    context.Teams.Where(t => t.Id == id)
                        .Include(t=>t.Users)
                        .Include(t => t.Posts)
                        .FirstOrDefault()
                );
            }
        }

        public TeamDetailModel Insert(TeamDetailModel item)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var entity = _mappers.TeamMapper.MapToTeamEntity(item);
                entity.Id = new Guid();
                context.Entry(entity.Admin).State = EntityState.Modified;
                foreach (var entityUser in entity.Users)
                {
                    context.Entry(entityUser).State = EntityState.Modified;
                }
                context.Teams.Add(entity);
                context.SaveChanges();
                return _mappers.TeamMapper.MapToTeamDetailModel(entity);
            }
        }

        public void Update(TeamDetailModel item)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var entity = _mappers.TeamMapper.MapToTeamEntity(item);
                context.Entry(entity.Admin).State = EntityState.Modified;

                foreach (var entityUser in entity.Users)
                {
                    context.Entry(entityUser).State = EntityState.Modified;
                }

                foreach (var postEntity in entity.Posts)
                {
                    context.Entry(postEntity).State = EntityState.Modified;
                    foreach (var postEntityComment in postEntity.Comments)
                    {
                        context.Entry(postEntityComment).State = EntityState.Modified;
                    }
                }

                context.Teams.Update(entity);
                context.SaveChanges();
            }
        }

        public void Remove(Guid id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var entity = new TeamEntity() { Id = id };
                context.Teams.Attach(entity);
                context.Teams.Remove(entity);
                context.SaveChanges();
            }
        }

        public ICollection<TeamListModel> GetByUserId(Guid id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.Teams.AsEnumerable().Where(t => t.Users.AsEnumerable().Any(u => u.Id == id) || t.Admin.Id == id).Select(_mappers.TeamMapper.MapToTeamListModel).ToList();
            }
        }
    }
}
