using System;
using System.Collections.Generic;
using System.Text;
using ICS_Project.Bl.Models.Base;

namespace ICS_Project.Bl.Models
{
    public class UserLoginModel: ModelBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
