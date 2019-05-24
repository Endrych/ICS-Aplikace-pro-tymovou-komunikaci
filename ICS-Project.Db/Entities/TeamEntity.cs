using System.Collections;
using System.Collections.Generic;
using ICS_Project.Db.Entities.Base;

namespace ICS_Project.Db.Entities
{
    public class TeamEntity : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public virtual ICollection<UserTeamEntity> UserTeams { get; set; } = new List<UserTeamEntity>();
        public virtual ICollection<PostEntity> Posts { get; set; } = new List<PostEntity>();
    }
}