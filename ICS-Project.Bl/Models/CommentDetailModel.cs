using System;
using System.Collections.Generic;
using System.Text;
using ICS_Project.Bl.Models.Base;

namespace ICS_Project.Bl.Models
{
    public class CommentDetailModel : MessageModel
    {
        public PostDetailModel Post { get; set; }
    }
}