using System.Collections;
using System.Collections.Generic;
using ICS_Project.Db.Entities.Base;

namespace ICS_Project.Db.Entities
{
  public class PostEntity: MessageEntity
  {
    public string Title { get; set; }
    public virtual ICollection<CommentEntity> Comments { get; set; } = new List<CommentEntity>();
  }
}
