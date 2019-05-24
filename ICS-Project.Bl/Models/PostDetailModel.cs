using System;
using System.Collections.Generic;
using System.Text;
using ICS_Project.Bl.Models.Base;

namespace ICS_Project.Bl.Models
{
    public class PostDetailModel : MessageModel
    {
        public string Title { get; set; }
        public ICollection<CommentDetailModel> Comments { get; set; } = new List<CommentDetailModel>();

        public CommentDetailModel NewComment { get; set; } = new CommentDetailModel();
    }
}