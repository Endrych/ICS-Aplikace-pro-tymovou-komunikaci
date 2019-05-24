using System;
using System.Collections.Generic;
using System.Text;

namespace ICS_Project.Bl.Models.Base
{
    public abstract class MessageModel: ModelBase
    {
        public DateTime Timestamp { get; set; }
        public UserDetailModel Author { get; set; }
        public string Content { get; set; }
    }
}
