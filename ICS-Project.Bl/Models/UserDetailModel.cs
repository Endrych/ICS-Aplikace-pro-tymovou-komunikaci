using System;
using System.Collections.Generic;
using System.Text;
using ICS_Project.Bl.Models.Base;

namespace ICS_Project.Bl.Models
{
    public class UserDetailModel : ModelBase
    {
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
