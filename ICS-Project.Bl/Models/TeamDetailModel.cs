using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICS_Project.Bl.Models.Base;

namespace ICS_Project.Bl.Models
{
    public class TeamDetailModel : ModelBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public UserDetailModel Admin { get; set; }
        public ICollection<UserDetailModel> Users { get; set; } = new List<UserDetailModel>();
        public ICollection<PostDetailModel> Posts { get; set; } = new List<PostDetailModel>();    
    }
}
