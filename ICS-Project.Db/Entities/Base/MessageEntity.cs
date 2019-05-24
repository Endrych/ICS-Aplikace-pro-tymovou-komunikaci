using System;
using System.Collections.Generic;
using System.Text;

namespace ICS_Project.Db.Entities.Base
{
    public abstract class MessageEntity: EntityBase
    {
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public virtual UserEntity Author { get; set; }
    }
}
