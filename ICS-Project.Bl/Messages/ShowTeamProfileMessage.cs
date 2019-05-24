using System;
using System.Collections.Generic;
using System.Text;

namespace ICS_Project.Bl.Messages
{
    public class ShowTeamProfileMessage
    {
        public Guid Id { get; set; }

        public ShowTeamProfileMessage(Guid id)
        {
            Id = id;
        }
    }
}
