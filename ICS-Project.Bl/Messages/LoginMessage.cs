using System;
using System.Collections.Generic;
using System.Text;

namespace ICS_Project.Bl.Messages
{
    public class LoginMessage
    {
        public Guid Id { get; set; }

        public LoginMessage(Guid userId)
        {
            Id = userId;
        }
    }
}
