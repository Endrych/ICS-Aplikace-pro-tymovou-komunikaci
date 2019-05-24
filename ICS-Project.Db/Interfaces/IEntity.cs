using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICS_Project.Db.Interfaces
{
    interface IEntity
    {
        [Key]
        Guid Id { get; set; }
    }
}
