using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ICS_Project.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ICS_Project.Db
{
    public class IcsDbContext: DbContext
    {
        public IcsDbContext()
        {
        }

        public IcsDbContext(DbContextOptions<IcsDbContext> contextOptions)
            :base(contextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTeamEntity>()
                .HasKey(t => new { t.UserId, t.TeamId });
            modelBuilder.Entity<UserEntity>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TeamEntity> Teams { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
    }
}
