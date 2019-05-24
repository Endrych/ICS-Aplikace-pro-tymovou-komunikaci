using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICS_Project.Bl.Models.Base;

namespace ICS_Project.Bl.Models
{
    public class TeamListModel: ModelBase
    {
        public string Title { get; set; }
        public UserListModel Admin { get; set; }
    }
}
