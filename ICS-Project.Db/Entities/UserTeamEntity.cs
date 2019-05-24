using System;
using System.Collections.Generic;
using System.Text;
using ICS_Project.Db.Entities.Base;

namespace ICS_Project.Db.Entities
{
    public class UserTeamEntity
    {
        public Guid UserId { get; set; }
        public virtual UserEntity User { get; set; }
        public Guid TeamId { get; set; }
        public virtual TeamEntity Team { get; set; }
    }
}
