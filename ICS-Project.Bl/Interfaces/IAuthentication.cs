using System;
using System.Collections.Generic;
using System.Text;
using ICS_Project.Bl.Models;

namespace ICS_Project.Bl.Interfaces
{
    public interface IAuthentication
    {
        UserDetailModel Registration(UserDetailModel model);
        UserDetailModel Login(UserLoginModel model);
    }
}
