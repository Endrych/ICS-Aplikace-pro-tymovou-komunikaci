using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ICS_Project.Db.Interfaces;

namespace ICS_Project.Db.Entities.Base
{
    public abstract class EntityBase:IEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
