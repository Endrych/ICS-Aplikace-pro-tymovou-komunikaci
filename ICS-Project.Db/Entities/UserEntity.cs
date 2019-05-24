using System;
using System.Collections.Generic;
using System.Text;
using ICS_Project.Db.Entities.Base;

namespace ICS_Project.Db.Entities
{
    public class UserEntity : EntityBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Nickname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<CommentEntity> Comments { get; set; } = new List<CommentEntity>();
        public virtual ICollection<PostEntity> Posts { get; set; } = new List<PostEntity>();
        public virtual ICollection<UserTeamEntity> UserTeams { get; set; } = new List<UserTeamEntity>();

    }
}
