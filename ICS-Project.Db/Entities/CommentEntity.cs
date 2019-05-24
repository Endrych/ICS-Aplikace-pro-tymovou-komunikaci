using System;
using System.Collections;
using ICS_Project.Db.Entities.Base;

namespace ICS_Project.Db.Entities
{
  public class CommentEntity: MessageEntity
  {
    public virtual PostEntity Post { get; set; }
  }
}
