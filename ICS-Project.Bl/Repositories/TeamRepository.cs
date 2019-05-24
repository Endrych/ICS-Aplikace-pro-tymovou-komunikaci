using System;
using System.Collections.Generic;
using System.Text;
using ICS_Project.Bl.Interfaces;
using ICS_Project.Bl.Models;

namespace ICS_Project.Bl.Repositories
{
    public class TeamRepository:IRepository<TeamDetailModel>
    {
        public TeamDetailModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public TeamDetailModel Insert(TeamDetailModel item)
        {
            throw new NotImplementedException();
        }

        public void Update(TeamDetailModel item)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
