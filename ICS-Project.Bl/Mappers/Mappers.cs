using System;
using System.Collections.Generic;
using System.Text;

namespace ICS_Project.Bl.Mappers
{
    public class Mappers
    {
        public CommentMapper CommentMapper { get; set; }
        public PostMapper PostMapper { get; set; }
        public TeamMapper TeamMapper { get; set; }
        public UserMapper UserMapper { get; set; }


        public Mappers()
        {
            CommentMapper = new CommentMapper(this);
            PostMapper = new PostMapper(this);
            TeamMapper = new TeamMapper(this);
            UserMapper = new UserMapper(this);
        }
    }
}
